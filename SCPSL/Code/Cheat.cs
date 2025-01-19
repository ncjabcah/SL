using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Reflection;
using System.Configuration;
using RemoteAdmin;
using System.Globalization;

namespace Cheat
{
    public class Cheat : NetworkBehaviour
    {
        private int _blinkCd;
        private bool _isDebug;
        private bool _isBlink;
        private bool _isEndDown;
        private bool _isNDown;
        private bool _isNoclip;
        //private bool _isSpeedhack;
        private bool _isTrace;

        private static bool _Door;
        private List<Door> disabledDoors;
        private static bool _B;
        private static bool _S;

        private bool GUIEnabled = true;

        private float _x = 0;
        private float _y = 0;

        private bool TpPlayer;

        //MENU
        public static KeyCode kcUI = KeyCode.Insert; //<-- Default KeyCodes

         //ESP
        public static KeyCode kcChamsWallhack = KeyCode.F1;
        public static KeyCode kcPlayerESP = KeyCode.F2;
        public static KeyCode kcItemESP = KeyCode.K;
        public static KeyCode kcLocationESP = KeyCode.G;
        public static float dItemESP = 50.0f;
        public static float dLocationESP = 75.0f;
        public static float dPlayerESP = 350.0f;
        public static bool dLocation_SCP914 = true;
        public static bool dLocation_Generator079 = true;
        public static bool dLocation_PocketExit = true;
        public static bool dLocation_TeslaGate = true;
        public static bool dLocation_Lift = true;

        //AIMBOT
        public static KeyCode kcSelectPlayer = KeyCode.E;
        public static KeyCode kcClearSelectPlayer = KeyCode.Q;
        public static KeyCode kcAttack = KeyCode.Mouse4;
        public static KeyCode kcRageAttack = KeyCode.V;

        //MISC
        public static KeyCode kcNoClip = KeyCode.Mouse2;
        public static KeyCode kcNoClipMode = KeyCode.Z;
        public static KeyCode kcListenAll = KeyCode.F5;
        public static KeyCode kcDebug = KeyCode.LeftControl;
        public static KeyCode kcScpMode = KeyCode.End;
        public static KeyCode kcAntiDoor = KeyCode.Keypad0;
        public static KeyCode kcTpPlayer = KeyCode.CapsLock;
        public static KeyCode ReloadConfig = KeyCode.Pause;

        //Movment Cheat
        public static KeyCode kcMovementCheat = KeyCode.B;
        public static float RunningSpeed = 1.15f;
        public static float JumpHight = 1.2f;
        public static float WalkSpeed = 1.25f;

        //private const KeyCode Key_noRecoil = KeyCode.Mouse1; //??
        public static KeyCode Key_noRecoil = KeyCode.Mouse1;

        public static bool Enable939Chams = true;


        private void Start()
        {
            this.disabledDoors = new List<Door>();
            ReadIniFile(); //Kann sein dass du die ini nen ordner höher oder den path ändern musst

            Memory.Init();
        }

        void ReadIniFile()
        {
           
          
            //Load/Create DefaultIni
            /*string defaultHotkeys = 
                "[Menu]@ToggleMenu=" + (int)kcUI +
                "@[ESP]@ChamsWallhack=" + (int)kcChamsWallhack + "@PlayerESP=" + (int)kcPlayerESP + "@ItemESP=" + (int)kcItemESP + "@LocationESP=" + (int)kcLocationESP +
                "@[Aimbot]@SelectPlayer=" + (int)kcSelectPlayer + "@ClearSelectPlayer=" + (int)kcClearSelectPlayer + "@Attack="+ (int)kcAttack + "@RageAttack=" + (int)kcRageAttack +
                "@[Misc]@Noclip="+ (int)kcNoClip + "@NoclipMode=" + (int)kcNoClipMode + "@MovmentCheat=" + (int)kcMovementCheat + "@ListenAll=" + (int)kcListenAll + "@Debug=" + (int)kcDebug + "@ScpMode=" + (int)kcScpMode + "@AntiDoor=" + (int)kcAntiDoor + "@TpPlayer=" + (int)kcTpPlayer + "@NoRecoil=" + (int)Key_noRecoil +
                "@[Memory]@Enable939Chams=" + Enable939Chams +
                "@[PreConfiguration]@RunningSpeed=" + RunningSpeed + "@WalkSpeed=" + WalkSpeed + "@JumpHight=" + JumpHight + "@dItemESP=" + dItemESP + "@dLocationESP=" + dLocationESP + "@dPlayerESP=" + dPlayerESP;
            defaultHotkeys = defaultHotkeys.Replace("@", System.Environment.NewLine);
            //System.IO.Directory.CreateDirectory(System.Environment.ExpandEnvironmentVariables(@"%USERPROFILE%/documents/SCP-Infinity-Hack"));
            if(!System.IO.File.Exists(IniFile.path))
               System.IO.File.AppendAllText(IniFile.path, defaultHotkeys);*/
            

            int tmp;

            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Menu", "ToggleMenu"))))
                kcUI = (KeyCode)tmp;


            //ESP
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("ESP", "ChamsWallhack"))))
                kcChamsWallhack = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("ESP", "PlayerESP"))))
                kcPlayerESP = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("ESP", "ItemESP"))))
                kcItemESP = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("ESP", "LocationESP"))))
                kcLocationESP = (KeyCode)tmp;
            //Aimbot
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Aimbot", "SelectPlayer"))))
                kcSelectPlayer = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Aimbot", "ClearSelectPlayer"))))
                kcClearSelectPlayer = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Aimbot", "Attack"))))
                kcAttack = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Aimbot", "RageAttack"))))
                kcRageAttack = (KeyCode)tmp;
            //Misc
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Misc", "Noclip"))))
                kcNoClip = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Misc", "NoclipMode"))))
                kcNoClipMode = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Misc", "MovmentCheat"))))
                kcMovementCheat = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Misc", "ListenAll"))))
                kcListenAll = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Misc", "Debug"))))
                kcDebug = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Misc", "ScpMode"))))
                kcScpMode = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Misc", "AntiDoor"))))
                kcAntiDoor = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Misc", "TpPlayer"))))
                kcTpPlayer = (KeyCode)tmp;
            if (System.Enum.IsDefined(typeof(KeyCode), tmp = int.Parse(IniFile.IniReadValue("Misc", "NoRecoil"))))
                Key_noRecoil = (KeyCode)tmp;
            //Memory
            Enable939Chams = bool.Parse(IniFile.IniReadValue("Memory", "Enable939Chams"));
            //PreConfiguration
            RunningSpeed = float.Parse(IniFile.IniReadValue("PreConfiguration", "RunningSpeed"));
            JumpHight = float.Parse(IniFile.IniReadValue("PreConfiguration", "JumpHight"));
            WalkSpeed = float.Parse(IniFile.IniReadValue("PreConfiguration", "WalkSpeed"));
            dItemESP = float.Parse(IniFile.IniReadValue("PreConfiguration", "dItemESP"));
            dLocationESP = float.Parse(IniFile.IniReadValue("PreConfiguration", "dLocationESP")); // , CultureInfo.InvariantCulture
            dPlayerESP = float.Parse(IniFile.IniReadValue("PreConfiguration", "dPlayerESP"));
            dLocation_SCP914 = bool.Parse(IniFile.IniReadValue("PreConfiguration", "dLocation_SCP914"));
            dLocation_Generator079 = bool.Parse(IniFile.IniReadValue("PreConfiguration", "dLocation_Generator079"));
            dLocation_PocketExit = bool.Parse(IniFile.IniReadValue("PreConfiguration", "dLocation_PocketExit"));
            dLocation_TeslaGate = bool.Parse(IniFile.IniReadValue("PreConfiguration", "dLocation_TeslaGate"));
            dLocation_Lift = bool.Parse(IniFile.IniReadValue("PreConfiguration", "dLocation_Lift"));
        }


        public bool IsValidClass(int cl)
        {
            return !(cl == 2 || cl == -1);
        }


        //private System.Random rand = new System.Random(); rand.Next(1, 999);
        public void Update(){

            //TOGGLE MENU 
            //TODO: So wie hier müssen alle keycodes ausgetauscht werden
            if (Input.GetKeyDown(kcUI))
            {
                GUIEnabled = !GUIEnabled;
            }

            //RELOAD CONFIG
            if (Input.GetKeyDown(ReloadConfig))
            {
                Start();
            }

            ESP.Update();

            //TP PLAYER TO YOU
            if (Input.GetKeyDown(kcTpPlayer))
            {
                if (!TpPlayer)
                {
                    TpPlayer = true;
                }
            }
            else if (TpPlayer && Input.GetKeyUp(kcTpPlayer))
            {
                TpPlayer = false;
            }
            if (TpPlayer)
            {
                foreach (GameObject gameObject_TPTOYOU in PlayerManager.singleton.players)
                {
                    bool flag = gameObject_TPTOYOU != PlayerManager.localPlayer &&
                    Vector3.Distance(gameObject_TPTOYOU.transform.position,
                    PlayerManager.localPlayer.transform.position) <= 7f; //7f
                    if (flag)
                    {
                        gameObject_TPTOYOU.transform.position =
                        PlayerManager.localPlayer.transform.position +
                        Camera.main.transform.forward * 1f;
                    }
                }
            }

            // ANTI DOOR
            bool keykcAntiDoor = Input.GetKeyDown(kcAntiDoor);
            if (keykcAntiDoor)
            {
                _Door = !_Door;
            }

            bool d = _Door;
            if (d)
            {
                foreach (Door RemoveDoor in Object.FindObjectsOfType<Door>())
                {
                    float DoorPos = Vector3.Distance(PlayerManager.localPlayer.transform.position, RemoveDoor.transform.position);
                    float pPos = 1f; //4f default
                    bool dCheck = DoorPos <= pPos;
                    if (dCheck)
                    {
                        RemoveDoor.gameObject.SetActive(false);
                        this.disabledDoors.Add(RemoveDoor);
                    }
                }
            }

            //BHOP
            bool keyDown5 = Input.GetKeyDown(kcMovementCheat);
            if (keyDown5)
            {
                Cheat._B = !Cheat._B;
            }
            GameObject gameObject = this.FindLocalPlayer();
            CharacterClassManager component = gameObject.GetComponent<CharacterClassManager>();
            FirstPersonController component5 = component.GetComponent<FirstPersonController>();
            bool flag19 = !(component == null);
            if (flag19)
            {
                bool b = Cheat._B;
                if (b)
                {
                    component5.m_RunSpeed = component.klasy[component.curClass].runSpeed * RunningSpeed; //1.19
                    component5.m_JumpSpeed = component.klasy[component.curClass].jumpSpeed * JumpHight; //1.27
                    component5.m_WalkSpeed = component.klasy[component.curClass].walkSpeed * WalkSpeed; // 1.27
                }
                else
                {
                    bool flag20 = !Cheat._B;
                    if (flag20)
                    {
                        component5.m_RunSpeed = component.klasy[component.curClass].runSpeed;
                        component5.m_JumpSpeed = component.klasy[component.curClass].jumpSpeed;
                        component5.m_WalkSpeed = component.klasy[component.curClass].walkSpeed;
                    }
                }
            }


            //SCP MODE
            bool keyDown4 = Input.GetKeyDown(kcScpMode);
            if (keyDown4)
            {
                Cheat._S = !Cheat._S;
            }
            bool s = Cheat._S;
            if (s)
            {
                bool mouseButtonDown = Input.GetMouseButtonDown(0);
                if (mouseButtonDown)
                {
                    Scp049PlayerScript comp_scp049 = component.GetComponent<Scp049PlayerScript>();
                    Scp049_2PlayerScript comp_scp049_2 = component.GetComponent<Scp049_2PlayerScript>();
                    Scp106PlayerScript comp_scp106 = component.GetComponent<Scp106PlayerScript>();
                    Scp096PlayerScript comp_scp096 = component.GetComponent<Scp096PlayerScript>();
                    Scp173PlayerScript comp_scp173 = component.GetComponent<Scp173PlayerScript>();
                    Scp939PlayerScript comp_scp939 = component.GetComponent<Scp939PlayerScript>();
                    Scp079PlayerScript comp_scp079 = component.GetComponent<Scp079PlayerScript>();

                    bool flag21 = comp_scp939 != null;
                    if (flag21)
                    {
                        foreach (GameObject gameObject_player in PlayerManager.singleton.players)
                        {
                            bool flag22 = Cheat.CheckValidTarget(gameObject_player) && Vector3.Distance(PlayerManager.localPlayer.transform.position, gameObject_player.transform.position) < comp_scp939.attackDistance && gameObject_player.GetComponent<CharacterClassManager>().IsTargetForSCPs();
                            if (flag22)
                            {
                                Vector3 position = Camera.main.transform.position;
                                Vector3 eulerAngles = Camera.main.transform.eulerAngles;
                                Camera.main.transform.position = gameObject_player.transform.position + Vector3.up * 1.5f;
                                Camera.main.transform.LookAt(gameObject_player.transform.position);
                                comp_scp939.GetType().GetMethod("Shoot", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(comp_scp939, new object[0]);
                                Camera.main.transform.position = position;
                                Camera.main.transform.eulerAngles = eulerAngles;
                                break;
                            }
                        }
                    }

                    bool iAm = comp_scp173.iAm173;
                    if (iAm)
                    {
                        foreach (GameObject gameObject_173 in PlayerManager.singleton.players)
                        {
                            bool flag23 = Cheat.CheckValidTarget(gameObject_173) && Vector3.Distance(PlayerManager.localPlayer.transform.position, gameObject_173.transform.position) < 5f && gameObject_173.GetComponent<CharacterClassManager>().IsTargetForSCPs();
                            if (flag23)
                            {
                                comp_scp173.GetType().GetMethod("HurtPlayer", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(comp_scp173, new object[]
                                {
                                        gameObject_173,
                                        "123"
                                });
                            }
                        }
                    }
                    bool iAm2 = comp_scp049.iAm049;
                    if (iAm2)
                    {
                        foreach (GameObject gameObject_049 in PlayerManager.singleton.players)
                        {
                            bool flag24 = Cheat.CheckValidTarget(gameObject_049) && Vector3.Distance(PlayerManager.localPlayer.transform.position, gameObject_049.transform.position) < comp_scp049.distance * 1.5f && comp_scp049.GetComponent<CharacterClassManager>().IsTargetForSCPs();
                            if (flag24)
                            {
                                comp_scp049.GetType().GetMethod("InfectPlayer", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(comp_scp049, new object[]
                                {
                                        gameObject_049,
                                        "123"
                                });
                            }
                        }
                    }
                    bool iAm049_ = comp_scp049_2.iAm049_2;
                    if (iAm049_)
                    {
                        foreach (GameObject gameObject_049_2 in PlayerManager.singleton.players)
                        {
                            bool flag25 = Cheat.CheckValidTarget(gameObject_049_2);
                            if (flag25)
                            {
                                int curClass = gameObject_049_2.GetComponent<CharacterClassManager>().curClass;
                                gameObject_049_2.GetComponent<CharacterClassManager>().curClass = 1;
                                bool flag26 = Cheat.CheckValidTarget(gameObject_049_2) && Vector3.Distance(PlayerManager.localPlayer.transform.position, gameObject_049_2.transform.position) < comp_scp049.distance * 1.7f;
                                if (flag26)
                                {
                                    gameObject_049_2.GetComponent<Scp049_2PlayerScript>().sameClass = false;
                                    Vector3 localEulerAngles = Camera.main.transform.localEulerAngles;
                                    Camera.main.transform.LookAt(gameObject_049_2.transform.position + Vector3.up);
                                    comp_scp049.GetType().GetMethod("Attack", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(comp_scp049, new object[0]);
                                    Camera.main.transform.localEulerAngles = localEulerAngles;
                                }
                                gameObject_049_2.GetComponent<CharacterClassManager>().curClass = curClass;
                            }
                        }
                    }
                    bool iAm3 = comp_scp106.iAm106;
                    /* if (iAm3)
                     {
                         if (this.doorCurrentlyIn != null && this.doorCurrentlyIn.destroyed)
                         {
                             this.ExitDoor();
                         }
                         else if (!this.isCollidingDoorOpen && this.doorCurrentlyIn != null && this.doorCurrentlyIn.isOpen && this.doorCurrentlyIn.curCooldown <= 0f && !this.isCollidingDoorOpen)
                         {
                             this.fpc.m_WalkSpeed = this.ccm.klasy[this.ccm.curClass].walkSpeed;
                             this.fpc.m_RunSpeed = this.ccm.klasy[this.ccm.curClass].runSpeed;
                             this.isCollidingDoorOpen = true;
                         }
                         else if (this.isCollidingDoorOpen && this.doorCurrentlyIn != null && !this.doorCurrentlyIn.isOpen)
                         {
                             this.isCollidingDoorOpen = false;
                             this.fpc.m_WalkSpeed = 1.5f;
                             this.fpc.m_RunSpeed = 1.5f;
                         }
                     }*/
                     
                    if (iAm3)
                    {
                        comp_scp106.StopCoroutine("ContainAnimation");
                        foreach (GameObject gameObject_106 in PlayerManager.singleton.players)
                        {
                            bool flag27 = Cheat.CheckValidTarget(gameObject_106);
                            if (flag27)
                            {
                                int curClass2 = gameObject_106.GetComponent<CharacterClassManager>().curClass;
                                gameObject_106.GetComponent<CharacterClassManager>().curClass = 1;
                                bool flag28 = Cheat.CheckValidTarget(gameObject_106) && Vector3.Distance(PlayerManager.localPlayer.transform.position, gameObject_106.transform.position) < 3.5f && gameObject_106.GetComponent<CharacterClassManager>().IsTargetForSCPs();
                                if (flag28)
                                {
                                    Vector3 localEulerAngles2 = Camera.main.transform.localEulerAngles;
                                    Camera.main.transform.LookAt(gameObject_106.transform.position + Vector3.up);
                                    MethodInfo method = comp_scp106.GetType().GetMethod("Shoot", BindingFlags.Instance | BindingFlags.NonPublic);
                                    method.Invoke(comp_scp106, new object[0]);
                                    method.Invoke(comp_scp106, new object[0]);
                                    method.Invoke(comp_scp106, new object[0]);
                                    Camera.main.transform.localEulerAngles = localEulerAngles2;
                                }
                                gameObject_106.GetComponent<CharacterClassManager>().curClass = curClass2;
                            }
                        }
                    }
                    bool iAm4 = comp_scp096.iAm096;
                    if (iAm4)
                    {
                        foreach (GameObject gameObject_096 in PlayerManager.singleton.players)
                        {
                            bool flag29 = Cheat.CheckValidTarget(gameObject_096) && gameObject_096.GetComponent<CharacterClassManager>().IsTargetForSCPs();
                            if (flag29)
                            {
                                int curClass3 = gameObject_096.GetComponent<CharacterClassManager>().curClass;
                                gameObject_096.GetComponent<CharacterClassManager>().curClass = 1;
                                bool flag30 = Vector3.Distance(PlayerManager.localPlayer.transform.position, gameObject_096.transform.position) < 4f;
                                if (flag30)
                                {
                                    Vector3 localEulerAngles3 = Camera.main.transform.localEulerAngles;
                                    Camera.main.transform.LookAt(gameObject_096.transform.position + Vector3.up);
                                    comp_scp096.GetType().GetMethod("Shoot", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(comp_scp096, new object[0]);
                                    Camera.main.transform.localEulerAngles = localEulerAngles3;
                                }
                                gameObject_096.GetComponent<CharacterClassManager>().curClass = curClass3;
                            }
                        }
                    }
                   bool iAm5 = comp_scp079.iAm079;
                    if (iAm5)
                    {
                        foreach (GameObject gameObject_079 in PlayerManager.singleton.players)
                        {
                            bool flag29 = Cheat.CheckValidTarget(gameObject_079) && gameObject_079.GetComponent<CharacterClassManager>().IsTargetForSCPs();
                            if (flag29)
                            {
                                int curClass3 = gameObject_079.GetComponent<CharacterClassManager>().curClass;
                                gameObject_079.GetComponent<CharacterClassManager>().curClass = 1;
                                bool flag30 = Vector3.Distance(PlayerManager.localPlayer.transform.position, gameObject_079.transform.position) < 4f;
                                if (flag30)
                                {
                                    Vector3 localEulerAngles3 = Camera.main.transform.localEulerAngles;
                                    Camera.main.transform.LookAt(gameObject_079.transform.position + Vector3.up);
                                    comp_scp096.GetType().GetMethod("Shoot", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(comp_scp096, new object[0]);
                                    Camera.main.transform.localEulerAngles = localEulerAngles3;
                                }
                                gameObject_079.GetComponent<CharacterClassManager>().curClass = curClass3;
                            }
                        }
                    }
                }
            }


            //DEBUG INFO
            if (Input.GetKeyDown(kcDebug))
            {
                if (!_isDebug)
                {
                    _isDebug = true;
                    _isTrace = true;
                }
            }
            else if (_isDebug && Input.GetKeyUp(kcDebug))
            {
                _isDebug = false;
                _isTrace = false;
            }


            //NOCLIP MODE
            if (Input.GetKeyDown(kcNoClipMode))
            {
                if (!_isEndDown)
                {
                    _isEndDown = true;
                }
            }
            else if (_isEndDown && Input.GetKeyUp(kcNoClipMode))
            {
                _isEndDown = false;
                _isBlink = !_isBlink;
            }

            //NOCLIP 
            if (Input.GetKeyDown(kcNoClip))
            {
                if (!_isNDown)
                {
                    _isNDown = true;
                    _isNoclip = true;
                }
            }
            else if (_isNDown && Input.GetKeyUp(kcNoClip))
            {
                _isNDown = false;
                _isNoclip = false;
            }


            //NOCLIP GET POSITION
            var lp = FindLocalPlayer();//PlayerManager.localPlayer;
            if (lp != null)
            {
                if (_isNoclip && _blinkCd < 1)
                {
                    if (_isBlink)
                    {
                        var myPos = lp.transform.position;
                        myPos += 10.0f * Camera.main.transform.forward *
                                 (Input.GetAxis("Vertical") == 0 ? 1.0f : Input.GetAxis("Vertical")) +
                                 Camera.main.transform.right * Input.GetAxis("Horizontal");
                        var move = lp.GetComponent<PlyMovementSync>();
                        move.position = myPos;
                        move.CallCmdSyncData(_y, myPos, _x);
                    }
                    else
                    {
                        lp.transform.position +=
                            0.05f * Camera.main.transform.forward *
                            (Input.GetAxis("Vertical") == 0 ? 1.0f : Input.GetAxis("Vertical")) +
                            Camera.main.transform.right * Input.GetAxis("Horizontal");
                    }
                }

                var myhealth = lp.GetComponent<PlayerStats>().health;

                if (_blinkCd > 0) _blinkCd -= 1;

                if (myhealth <= 0) return;
                PlayerManager.localPlayer.GetComponent<FallDamage>().enabled = false;
                /* little hacks
                var ccm = lp.GetComponent<CharacterClassManager>();
                if (ccm && !_isSpeedhack)
                {
                    foreach (var t in ccm.klasy)
                        t.runSpeed *= 1.3f;
                    _isSpeedhack = true;

                    // testing
                   
                }*/


                //MEMORY HOTKEYS
                if (Input.GetKeyDown(kcChamsWallhack) && Enable939Chams)
                {
                    Memory.SetWallhack(!Memory.ChamsWallhack);
                }

                if (Input.GetKeyDown(kcListenAll))
                {
                    Memory.SetRadio(!Memory._bAllRadio);
                }
            }
        }

        private void OnGUI(){

            if (GUIEnabled) {
                GUI.Box(new Rect(10, 40, 220, 365), "<color=orange><b>SCP:SL Infinity Cheat</b></color>");
                GUI.Label(new Rect(15, 60, 500, 30), "Noclip <color=#42f4d1>["+ kcNoClip +"]</color> " + (_isNoclip ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 80, 500, 30), "- NoclipMode <color=#42f4d1>["+ kcNoClipMode + "]</color> " + (_isBlink ? "<color=#8e16ff>BLINK</color>" : "<color=#ff16df>MOVE</color>"));
                //GUI.Label(new Rect(15, 100, 500, 30), "Speed Boost: " + (_isSpeedhack ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 100, 500, 30), "Movement Cheat <color=#42f4d1>["+ kcMovementCheat +"]</color> " + (Cheat._B ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 120, 500, 30), "<color=yellow><b>──────────────────────</b></color>");               
                GUI.Label(new Rect(15, 140, 500, 30), "ESP Chams <color=#42f4d1>["+ kcChamsWallhack + "]</color> " + (Memory.ChamsWallhack ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 160, 500, 30), "ESP Players <color=#42f4d1>[" + kcPlayerESP + "]</color> " + (ESP.ShowPlayerESP ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 180, 500, 30), "ESP Items <color=#42f4d1>["+ kcItemESP +"]</color> " + (ESP._bShowDropEsp ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 200, 500, 30), "ESP Locations <color=#42f4d1>["+ kcLocationESP +"]</color> " + (ESP._bShowLocations ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 220, 500, 30), "Aimbot Key <color=#42f4d1>["+ kcSelectPlayer +"]</color> SELECT");
                GUI.Label(new Rect(15, 240, 500, 30), "Aimbot Key <color=#42f4d1>["+ kcClearSelectPlayer +"]</color> CLEAR SELECT");
                GUI.Label(new Rect(15, 260, 500, 30), "Aimbot Key <color=#42f4d1>["+ kcAttack +"]</color> ATTACK");
                GUI.Label(new Rect(15, 280, 500, 30), "Aimbot Key <color=#42f4d1>["+ kcRageAttack +"]</color> RAGE");
                GUI.Label(new Rect(15, 300, 500, 30), "Listen ALL <color=#42f4d1>["+ kcListenAll +"]</color> " + (Memory._bAllRadio ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 320, 500, 30), "Debug Trace <color=#42f4d1>["+ kcDebug +"]</color> " + (_isTrace ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 340, 500, 30), "SCP Mode <color=#42f4d1>["+ kcScpMode +"]</color> " + (_S ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 360, 500, 30), "Anti-Door <color=#42f4d1>["+ kcAntiDoor +"]</color> " + (_Door ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));
                GUI.Label(new Rect(15, 380, 500, 30), "TP-Player <color=#42f4d1>["+ kcTpPlayer +"]</color> " + (TpPlayer ? "<color=#8aff62>ON</color>" : "<color=#ff7063>OFF</color>"));

            }
            //TARGET BOX
            GUI.Box(new Rect(Screen.width / 2 - 50, 20, 300, 25), "<color=#ff7063><b><size=15>" + (Aimbot.targetNick) + "</size></b></color>");
            //GUI.Box(new Rect(Screen.width / 2 - 50, 40, 300, 25), "<color=#ff7063><b><size=15>" + RunningSpeed + " " + WalkSpeed + " " + JumpHight + Enable939Chams + "</size></b></color>");
   
            // I placed it OnGUI because when onGUI is called then hook is 100% accurate.
            // If you know a better place feel free to suggest ;)
            Memory.Hook();
            //CHECK IF ING
            var lp = PlayerManager.localPlayer;
            if (!lp) return;
            //UPDATE IF ING
            Aimbot.Update(lp);
            var ccm = lp.GetComponent<CharacterClassManager>();
            //OLD PLACE OF GUI LABEL


            if (_isTrace)
                if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward),
                    out var hit))
                {
                    GUI.Label(new Rect(Screen.width / 2f, Screen.height / 2f, 500, 150),
                        "Tag:" + hit.transform.gameObject.tag + " and name is: " + hit.transform.gameObject.name);
                    var firstParent = hit.transform.gameObject.transform.parent;
                    if (firstParent)
                        GUI.Label(new Rect(Screen.width / 2f, Screen.height / 2f + 50, 500, 150),
                            "parent tag & name & type: " + firstParent.parent.tag + " & " + firstParent.name + " & " + firstParent.GetType());
                    if (Input.GetKeyDown(KeyCode.KeypadPlus))//Ez way to get Killed by AC xd
                        Destroy(hit.transform.gameObject);
                }

            if (_isNoclip)
            {
                if (_isBlink)
                {
                    var myPos = lp.transform.position;
                    myPos[1] += 15.0f;
                    var move = lp.GetComponent<PlyMovementSync>();
                    move.CallCmdSyncData(_y, myPos, _x);
                    myPos += 1.3f * Camera.main.transform.forward;
                    move.CallCmdSyncData(_y, myPos, _x);
                    myPos[1] -= 10.0f;
                    move.CallCmdSyncData(_y, myPos, _x);
                }
                else
                {
                    var myPos = lp.transform.position;
                    myPos += 50f * Camera.main.transform.forward +
                             Camera.main.transform.right * Input.GetAxis("Horizontal");
                    lp.GetComponent<PlyMovementSync>().position = myPos;
                }
            }

            var main = Camera.main;
            //var player = PlayerManager.localPlayer; // FindLocalPlayer();
            ESP.Render(lp, main, ccm);
        }

        private static bool CheckValidTarget(GameObject player)
        {
            return player != PlayerManager.localPlayer;
        }
        private GameObject FindLocalPlayer()
        {
            GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].GetComponent<NetworkIdentity>().isLocalPlayer)
                {
                    return array[i];
                }
            }
            return null;
        }
    }
}