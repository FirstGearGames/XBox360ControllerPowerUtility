using SharpDX.XInput;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Xbox360ControllerPowerUtility
{
    public partial class Form1 : Form
    {
        [DllImport("XInput1_3.dll", CharSet = CharSet.Auto, EntryPoint = "#103")]
        internal static extern int FnOff(int i);

        /// <summary>
        /// List of all possible controllers.
        /// </summary>
        private List<Controller> m_controllers = new List<Controller>();
        /// <summary>
        /// Array of held duration for each controller, in order of the controllers list.
        /// </summary>
        private int[] m_powerHeldDurations;

        //How long in milliseconds the 'power' button must be held to turn off the controller.
        private const int POWER_OFF_HELD_DURATION = 2000;

        public Form1()
        {
            InitializeComponent();
            BuildControllersCollection();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }

        /// <summary>
        /// Populates controllers collection and initializes held durations.
        /// </summary>
        private void BuildControllersCollection()
        {
            m_powerHeldDurations = new int[4];
            /* Add all controllers to the controllers list.
             * Couldn't determine what UserIndex.Any does.
             * Is adding each controller actually required? */
            m_controllers.Add(new Controller(UserIndex.One));
            m_controllers.Add(new Controller(UserIndex.Two));
            m_controllers.Add(new Controller(UserIndex.Three));
            m_controllers.Add(new Controller(UserIndex.Four));
        }


        /// <summary>
        /// Turns off a specified controller.
        /// </summary>
        /// <param name="controller"></param>
        private void TurnOffController(Controller controller)
        {
            int result = FnOff(ReturnControllerIndex(controller));
            Debug.Print("TurnOffController result: " + result.ToString());
        }

        /// <summary>
        /// Returns the index to pass into FnOff based on controller UserIndex. This is untested with multiple controllers.
        /// </summary>
        /// <param name="controller"></param>
        /// <returns></returns>
        private int ReturnControllerIndex(Controller controller)
        {
            switch (controller.UserIndex)
            {

                case UserIndex.One:
                    return 0;
                case UserIndex.Two:
                    return 1;
                case UserIndex.Three:
                    return 2;
                case UserIndex.Four:
                    return 3;
                case UserIndex.Any:
                default:
                    return (int)controller.UserIndex;
            }
        }

        private void TmrCheckInput_Tick(object sender, System.EventArgs e)
        {
            for (int i = 0; i < m_controllers.Count; i++)
            {
                //If controller is connected.
                if (m_controllers[i].IsConnected)
                {
                    //Gets state of all buttons for controller.
                    State state = m_controllers[i].GetState();

                    //If start is held.
                    if (state.Gamepad.Buttons == (GamepadButtonFlags.Start | GamepadButtonFlags.Back))
                    {
                        m_powerHeldDurations[i] += TmrCheckInput.Interval;
                        //If held long enough to power off controller.
                        if (m_powerHeldDurations[i] > POWER_OFF_HELD_DURATION)
                        {
                            m_powerHeldDurations[i] = 0;
                            TurnOffController(m_controllers[i]);
                        }
                    }
                    //Start isn't held.
                    else
                    {
                        m_powerHeldDurations[i] = 0;
                    }
                }
                //Not connected.
                else
                {
                    //Reset held duration.
                    m_powerHeldDurations[i] = 0;
                }
            }
        }

        /// <summary>
        /// Hides the form after a specified interval.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrHideForm_Tick(object sender, System.EventArgs e)
        {
            //Disable timer then hide form.
            TmrHideForm.Enabled = false;
            this.Visible = false;
        }
    }
}
