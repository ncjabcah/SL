@echo off
echo ====================================
echo SCP-Infinity initialising...
echo Copying new config to preconfigurated location...
xcopy /Y /S "%cd%\Infinity-Config.ini" "%USERPROFILE%\documents\"
echo Copying finished.
echo ====================================
timeout 1 >nul
cls

:searchSCP
tasklist /nh /fi "imagename eq SCPSL.exe" | find /i "SCPSL.exe" >nul && (echo SCPSL.exe IS RUNNING) && GOTO found || (echo ============================) && (echo SCPSL.exe IS NOT RUNNING) && (echo ============================)
timeout 1 >nul
cls
GOTO searchSCP

:found
cls
echo ====================================
echo SCP-Infinity found SCPSL.exe
echo Injecting in 3 seconds.
echo ====================================
timeout 1 >nul
cls
echo ====================================
echo SCP-Infinity found SCPSL.exe
echo Injecting in 2 seconds.
echo ====================================
timeout 1 >nul
cls
echo ====================================
echo SCP-Infinity found SCPSL.exe
echo Injecting in 1 seconds.
echo ====================================
timeout 1 >nul
cls
echo ====================================
echo SCP-Infinity found SCPSL.exe
echo Injecting in now.
echo ====================================
timeout 1 >nul
cls
call "%cd%\injector.exe"
cls
echo ====================================
echo SCP-Infinity initialising finished.
echo Have fun!
echo ====================================
timeout 3 >nul
exit