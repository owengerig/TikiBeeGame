using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class StatModiferHudController : HudController {


        public GUIStyle StatModifersButtonStyle;
        public GUIStyle statModifersCharacterSelectionLabelStyle;
        private SaveObject saveObject = null;

        public Sprite backgroundTB;
        public Sprite backgroundBB;
        public Sprite backgroundPR;
        public Sprite backgroundDefault;
        public Texture2D emptyBar;
        public Texture2D fullBar;

        // Use this for initialization
        void Start() {;
        }

        // Update is called once per frame
        void Update() {

        }

        void OnGUI() {
            /*
             * handles scaling of ui
             * taken from:
             * http://answers.unity3d.com/questions/169056/bulletproof-way-to-do-resolution-independant-gui-s.html
             */
            float native_width = 1920;
            float native_height = 1080;

            //set up scaling
            float rx = Screen.width / native_width;
            float ry = Screen.height / native_height;
            GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
            /////////////////////////////////////////////////////////////////////

            if (!PreferencesManager.TIKIBEE_SELECTED && !PreferencesManager.BOMBUS_SELECTED && !PreferencesManager.PERRER_SELECTED) {
                LevelController.loadCharacterSelection();
                return;
            }

            GameObject backgroundController = GameObject.FindGameObjectWithTag("Background");
            SpriteRenderer sr = backgroundController.GetComponent<SpriteRenderer>();
            if (PreferencesManager.TIKIBEE_SELECTED) {
                sr.sprite = backgroundTB;
            } else if (PreferencesManager.TIKIBEE_SELECTED) {
                sr.sprite = backgroundBB;
            } else {
                sr.sprite = backgroundPR;
            }
            
            
            if (saveObject == null) {
                saveObject = PersistantData.Load();
            }

            if (GUI.Button(new Rect(300, 90, 230, 60), "Back", menuButtonStyle)) {
                PreferencesManager.BOMBUS_SELECTED = false;
                PreferencesManager.TIKIBEE_SELECTED = false;
                PreferencesManager.PERRER_SELECTED = false;
            }
            if (GUI.Button(new Rect(300, 160, 230, 60), "Play", menuButtonStyle)) {
                PersistantData.Save(saveObject);
                LevelController.loadNextLevelWithLevelMap();
            }
            if (GUI.Button(new Rect(1400, 1020, 230, 60), "Reset", menuButtonStyle)) {
                saveObject = PersistantData.Load();
            }

            float buttonAlignLeftX = 1000;
            float buttonAlignLeftY = 200;
            float buttonWidth = 370;
            float buttonHeight = 50;
            float labelWidth = 140;
            float labelHeight = 50;
            float buttonLabelBuffer = 5.0f;

            //currency
            //buttonAlignLeftX - 25, buttonAlignLeftY - 37, 80, 10
            //(1000, 140, 80, 10)
            GUI.Label(new Rect(buttonAlignLeftX - 85, buttonAlignLeftY - 92, labelWidth + 350, labelHeight), "Total Currency: " + saveObject.PLAYER_CURRENCY.ToString(), StatModifersButtonStyle);


            float maxHealthMultiplier = 3f;
            float maxSpeedMultiplier = 3f;
            float maxScoreModifier = 10f;
            float maxShieldDuration = 10f;
            float maxShieldCooldown = 10f;
            float maxSpeedBoostDuration = 10f;
            float maxSpeedBoostCooldown = 10f;
            float maxSpeedBoostModifier = 10f;
            float maxBurstRadius= 5f;
            float maxBurstCooldown = 10f;
            float maxBurstDamage = 100f;

            //TIKI BEE
            if (PreferencesManager.TIKIBEE_SELECTED) {
                #region TikiBee Health Modifier
                //health multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 40, buttonWidth, buttonHeight), "Health Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_HEALTH_MODIFIER + 1 > maxHealthMultiplier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_HEALTH_MODIFIER += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), (saveObject.TB_PLAYER_HEALTH_MODIFIER * 100).ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxHealthMultiplier/saveObject.TB_PLAYER_HEALTH_MODIFIER), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Score Modifier
                //score multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 130, buttonWidth, buttonHeight), "Score Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_SCORE_MODIFIER + 1 > maxScoreModifier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SCORE_MODIFIER += .1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SCORE_MODIFIER.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxScoreModifier / saveObject.TB_PLAYER_SCORE_MODIFIER), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Speed Modifier
                //health multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Speed Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_SPEED_MODIFIER + 1 > maxSpeedMultiplier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SPEED_MODIFIER += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), (saveObject.TB_PLAYER_HEALTH_MODIFIER * 100).ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedMultiplier / saveObject.TB_PLAYER_SPEED_MODIFIER), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Shield Duration
                //Shield duration and cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 120, buttonWidth, buttonHeight), "Shield Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_SHIELD_DURATION + 1 > maxShieldDuration) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SHIELD_DURATION += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SHIELD_DURATION.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxShieldDuration / saveObject.TB_PLAYER_SHIELD_DURATION), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Shield Cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Shield Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_SHIELD_COOLDOWN + 1f > maxShieldCooldown ) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SHIELD_COOLDOWN += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SHIELD_COOLDOWN.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxShieldCooldown / saveObject.TB_PLAYER_SHIELD_COOLDOWN), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Speed Boost Duration
                //speed boost duration cooldown and multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 85, buttonWidth, buttonHeight), "Boost Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_SPEED_BOOST_DURATION + 1 > maxSpeedBoostDuration) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SPEED_BOOST_DURATION += 1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SPEED_BOOST_DURATION.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedBoostDuration / saveObject.TB_PLAYER_SPEED_BOOST_DURATION), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Speed Boost Cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_SPEED_BOOST_COOLDOWN + 1f > maxSpeedBoostCooldown) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SPEED_BOOST_COOLDOWN += 1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SPEED_BOOST_COOLDOWN.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedBoostCooldown / saveObject.TB_PLAYER_SPEED_BOOST_COOLDOWN), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Speed Boost Modifier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_SPEED_BOOST_MULTIPLIER + 1f > maxSpeedBoostModifier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SPEED_BOOST_MULTIPLIER += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SPEED_BOOST_MULTIPLIER.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedBoostModifier / saveObject.TB_PLAYER_SPEED_BOOST_MULTIPLIER), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Burst Cooldown
                //arcane burst cooldown radio and damage
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 75, buttonWidth, buttonHeight), "Burst Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_BURST_COOLDOWN + 1f > maxBurstCooldown) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_BURST_COOLDOWN += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_BURST_COOLDOWN.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxBurstCooldown / saveObject.TB_PLAYER_BURST_COOLDOWN), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Burst Radius
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Radius", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_BURST_RADIUS + 1f > maxBurstRadius) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_BURST_RADIUS += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_BURST_RADIUS.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxBurstRadius / saveObject.TB_PLAYER_BURST_RADIUS), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region TikiBee Burst Damage
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Damage", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.TB_PLAYER_BURST_DAMAGE + 1f > maxBurstDamage) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_BURST_DAMAGE += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_BURST_DAMAGE.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxBurstDamage / saveObject.TB_PLAYER_BURST_DAMAGE), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion
            }
                //BOMBUS
            else if (PreferencesManager.BOMBUS_SELECTED) {
                #region Bombus Health Modifier
                //health multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 40, buttonWidth, buttonHeight), "Health Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_HEALTH_MODIFIER + 1 > maxHealthMultiplier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_HEALTH_MODIFIER += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), (saveObject.BB_PLAYER_HEALTH_MODIFIER * 100).ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxHealthMultiplier/saveObject.BB_PLAYER_HEALTH_MODIFIER), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion
                #region Bombus Score Modifier
                //score multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 130, buttonWidth, buttonHeight), "Score Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_SCORE_MODIFIER + 1 > maxScoreModifier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SCORE_MODIFIER += .1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SCORE_MODIFIER.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxScoreModifier / saveObject.BB_PLAYER_SCORE_MODIFIER), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion


                #region Bombus Speed Modifier
                //health multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Speed Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_SPEED_MODIFIER + 1 > maxSpeedMultiplier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SPEED_MODIFIER += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), (saveObject.TB_PLAYER_HEALTH_MODIFIER * 100).ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedMultiplier / saveObject.BB_PLAYER_SPEED_MODIFIER), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Shield Duration
                //Shield duration and cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 120, buttonWidth, buttonHeight), "Shield Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_SHIELD_DURATION + 1 > maxShieldDuration) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SHIELD_DURATION += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SHIELD_DURATION.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxShieldDuration / saveObject.BB_PLAYER_SHIELD_DURATION), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Shield Cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Shield Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_SHIELD_COOLDOWN + 1f > maxShieldCooldown ) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SHIELD_COOLDOWN += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SHIELD_COOLDOWN.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxShieldCooldown / saveObject.BB_PLAYER_SHIELD_COOLDOWN), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Speed Boost Duration
                //speed boost duration cooldown and multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 85, buttonWidth, buttonHeight), "Boost Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_SPEED_BOOST_DURATION + 1 > maxSpeedBoostDuration) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SPEED_BOOST_DURATION += 1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SPEED_BOOST_DURATION.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedBoostDuration / saveObject.BB_PLAYER_SPEED_BOOST_DURATION), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Speed Boost Cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_SPEED_BOOST_COOLDOWN + 1f > maxSpeedBoostCooldown) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SPEED_BOOST_COOLDOWN += 1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SPEED_BOOST_COOLDOWN.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedBoostCooldown / saveObject.BB_PLAYER_SPEED_BOOST_COOLDOWN), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Speed Boost Modifier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_SPEED_BOOST_MULTIPLIER + 1f > maxSpeedBoostModifier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SPEED_BOOST_MULTIPLIER += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SPEED_BOOST_MULTIPLIER.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedBoostModifier / saveObject.BB_PLAYER_SPEED_BOOST_MULTIPLIER), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Burst Cooldown
                //arcane burst cooldown radio and damage
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 75, buttonWidth, buttonHeight), "Burst Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_BURST_COOLDOWN + 1f > maxBurstCooldown) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_BURST_COOLDOWN += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_BURST_COOLDOWN.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxBurstCooldown / saveObject.BB_PLAYER_BURST_COOLDOWN), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Burst Radius
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Radius", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_BURST_RADIUS + 1f > maxBurstRadius) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_BURST_RADIUS += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_BURST_RADIUS.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxBurstRadius / saveObject.BB_PLAYER_BURST_RADIUS), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Burst Damage
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Damage", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.BB_PLAYER_BURST_DAMAGE + 1f > maxBurstDamage) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_BURST_DAMAGE += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_BURST_DAMAGE.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                    GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                    GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxBurstDamage / saveObject.BB_PLAYER_BURST_DAMAGE), labelHeight));
                        GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                    GUI.EndGroup();
                GUI.EndGroup();
                #endregion
            } else if (PreferencesManager.PERRER_SELECTED) {
                #region Perrer Health Modifier
                //health multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 40, buttonWidth, buttonHeight), "Health Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_HEALTH_MODIFIER + 1 > maxHealthMultiplier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_HEALTH_MODIFIER += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), (saveObject.PR_PLAYER_HEALTH_MODIFIER * 100).ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxHealthMultiplier / saveObject.PR_PLAYER_HEALTH_MODIFIER), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion
                #region Bombus Score Modifier
                //score multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 130, buttonWidth, buttonHeight), "Score Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_SCORE_MODIFIER + 1 > maxScoreModifier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_SCORE_MODIFIER += .1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.PR_PLAYER_SCORE_MODIFIER.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxScoreModifier / saveObject.PR_PLAYER_SCORE_MODIFIER), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion


                #region Bombus Speed Modifier
                //health multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Speed Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_SPEED_MODIFIER + 1 > maxSpeedMultiplier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_SPEED_MODIFIER += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), (saveObject.PR_PLAYER_HEALTH_MODIFIER * 100).ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedMultiplier / saveObject.PR_PLAYER_SPEED_MODIFIER), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Shield Duration
                //Shield duration and cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 120, buttonWidth, buttonHeight), "Shield Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_SHIELD_DURATION + 1 > maxShieldDuration) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_SHIELD_DURATION += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.PR_PLAYER_SHIELD_DURATION.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxShieldDuration / saveObject.PR_PLAYER_SHIELD_DURATION), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Shield Cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Shield Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_SHIELD_COOLDOWN + 1f > maxShieldCooldown) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_SHIELD_COOLDOWN += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.PR_PLAYER_SHIELD_COOLDOWN.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxShieldCooldown / saveObject.PR_PLAYER_SHIELD_COOLDOWN), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Speed Boost Duration
                //speed boost duration cooldown and multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 85, buttonWidth, buttonHeight), "Boost Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_SPEED_BOOST_DURATION + 1 > maxSpeedBoostDuration) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_SPEED_BOOST_DURATION += 1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.PR_PLAYER_SPEED_BOOST_DURATION.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedBoostDuration / saveObject.PR_PLAYER_SPEED_BOOST_DURATION), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Speed Boost Cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_SPEED_BOOST_COOLDOWN + 1f > maxSpeedBoostCooldown) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_SPEED_BOOST_COOLDOWN += 1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.PR_PLAYER_SPEED_BOOST_COOLDOWN.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedBoostCooldown / saveObject.PR_PLAYER_SPEED_BOOST_COOLDOWN), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Speed Boost Modifier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_SPEED_BOOST_MULTIPLIER + 1f > maxSpeedBoostModifier) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_SPEED_BOOST_MULTIPLIER += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.PR_PLAYER_SPEED_BOOST_MULTIPLIER.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxSpeedBoostModifier / saveObject.PR_PLAYER_SPEED_BOOST_MULTIPLIER), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Burst Cooldown
                //arcane burst cooldown radio and damage
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 75, buttonWidth, buttonHeight), "Burst Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_BURST_COOLDOWN + 1f > maxBurstCooldown) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_BURST_COOLDOWN += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.PR_PLAYER_BURST_COOLDOWN.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxBurstCooldown / saveObject.PR_PLAYER_BURST_COOLDOWN), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Burst Radius
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Radius", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_BURST_RADIUS + 1f > maxBurstRadius) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_BURST_RADIUS += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.PR_PLAYER_BURST_RADIUS.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxBurstRadius / saveObject.PR_PLAYER_BURST_RADIUS), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion

                #region Bombus Burst Damage
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Damage", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0 || saveObject.PR_PLAYER_BURST_DAMAGE + 1f > maxBurstDamage) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.PR_PLAYER_BURST_DAMAGE += 1f;
                }
                //GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.PR_PLAYER_BURST_DAMAGE.ToString(), StatModifersButtonStyle);
                GUI.BeginGroup(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), emptyBar);
                GUI.BeginGroup(new Rect(0, 0, labelWidth / (maxBurstDamage / saveObject.PR_PLAYER_BURST_DAMAGE), labelHeight));
                GUI.Box(new Rect(0, 0, labelWidth, labelHeight), fullBar);
                GUI.EndGroup();
                GUI.EndGroup();
                #endregion
            }
        }
    }
}
