@echo
echo COPY FILES FROM GAME

xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\Assembly-CSharp.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\Assembly-CSharp-firstpass.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\UnityEngine.AnimationModule.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\UnityEngine.CoreModule.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\UnityEngine.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\UnityEngine.IMGUIModule.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\UnityEngine.Networking.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\UnityEngine.PhysicsModule.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\UnityEngine.UI.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\UnityEngine.UIModule.dll" "%cd%\Lib"
xcopy /Y /S "C:\Program Files (x86)\Steam\steamapps\common\SCP Secret Laboratory\SCPSL_Data\Managed\UnityEngine.AudioModule.dll" "%cd%\Lib"

pause