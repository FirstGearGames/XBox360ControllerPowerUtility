@echo off

echo Launching utility in remove from startup mode...
echo.

Xbox360ControllerPowerUtility.exe removestartup

echo Xbox 360 Controller Power Utility has been removed from startup.
echo If this process failed manually remove the key at LOCAL_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
echo.

pause