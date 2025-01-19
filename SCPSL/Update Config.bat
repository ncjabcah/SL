@echo off
echo ====================================
echo Updating Configs...
echo Copying new config to preconfigurated location...
xcopy /Y /S "%cd%\Infinity-Config.ini" "%USERPROFILE%\documents\"
echo Copying finished.
echo ====================================
cls
echo ====================================
echo Configs Updated!
echo Press the PAUSE Key ING to
echo Reload the config!
echo Have fun!
echo ====================================
timeout 5 >nul
exit