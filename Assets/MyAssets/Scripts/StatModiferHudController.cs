﻿using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class StatModiferHudController : HudController {


        public GUIStyle StatModifersButtonStyle;
        public GUIStyle statModifersCharacterSelectionLabelStyle;
        private SaveObject saveObject = null;

        public Sprite backgroundTB;
        public Sprite backgroundBB;
        public Sprite backgroundDefault;

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

            if (!PreferencesManager.TIKIBEE_SELECTED && !PreferencesManager.BOMBUS_SELECTED) {
                LevelController.loadCharacterSelection();
                return;
            }

            GameObject backgroundController = GameObject.FindGameObjectWithTag("Background");
            SpriteRenderer sr = backgroundController.GetComponent<SpriteRenderer>();
            if (PreferencesManager.TIKIBEE_SELECTED) {
                sr.sprite = backgroundTB;
            } else {
                sr.sprite = backgroundBB;
            }
            
            
            if (saveObject == null) {
                saveObject = PersistantData.Load();
            }

            if (GUI.Button(new Rect(300, 20, 230, 60), "Main Menu", menuButtonStyle)) {
                LevelController.loadMainMenuScene();
            }
            if (GUI.Button(new Rect(300, 90, 230, 60), "Back", menuButtonStyle)) {
                PreferencesManager.BOMBUS_SELECTED = false;
                PreferencesManager.TIKIBEE_SELECTED = false;
            }
            if (GUI.Button(new Rect(300, 160, 230, 60), "Play", menuButtonStyle)) {
                PersistantData.Save(saveObject);
                LevelController.loadNextLevelWithLevelMap();
            }
            if (GUI.Button(new Rect(1400, 1020, 230, 60), "Save", menuButtonStyle)) {
                PersistantData.Save(saveObject);
            }

            float buttonAlignLeftX = 1000;
            float buttonAlignLeftY = 200;
            float buttonWidth = 370;
            float buttonHeight = 50;
            float textAlignLeftX = buttonAlignLeftX + 80;
            float textAlignLeftY = buttonAlignLeftX + 100;
            float labelWidth = 140;
            float labelHeight = 50;
            float buttonLabelBuffer = 5.0f;

            //currency
            //buttonAlignLeftX - 25, buttonAlignLeftY - 37, 80, 10
            //(1000, 140, 80, 10)
            GUI.Label(new Rect(buttonAlignLeftX - 85, buttonAlignLeftY - 92, labelWidth + 350, labelHeight), "Total Currency: " + saveObject.PLAYER_CURRENCY.ToString(), StatModifersButtonStyle);

            //TIKI BEE
            if (PreferencesManager.TIKIBEE_SELECTED) {
                //health multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 40, buttonWidth, buttonHeight), "Health Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_HEALTH_MODIFIER += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), (saveObject.TB_PLAYER_HEALTH_MODIFIER * 100).ToString(), StatModifersButtonStyle);

                //score multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 160, buttonWidth, buttonHeight), "Score Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SCORE_MODIFIER += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SCORE_MODIFIER.ToString(), StatModifersButtonStyle);

                //Shield duration and cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 130, buttonWidth, buttonHeight), "Shield Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SHIELD_DURATION += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SHIELD_DURATION.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Shield Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.TB_PLAYER_SHIELD_COOLDOWN - .1f <= 0 || saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SHIELD_COOLDOWN -= 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SHIELD_COOLDOWN.ToString(), StatModifersButtonStyle);

                //speed boost duration cooldown and multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 85, buttonWidth, buttonHeight), "Boost Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SPEED_BOOST_DURATION += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SPEED_BOOST_DURATION.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.TB_PLAYER_SPEED_BOOST_COOLDOWN - .1f <= 0 || saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SPEED_BOOST_COOLDOWN -= 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SPEED_BOOST_COOLDOWN.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_SPEED_BOOST_MULTIPLIER += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_SPEED_BOOST_MULTIPLIER.ToString(), StatModifersButtonStyle);

                //arcane burst cooldown radio and damage
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 75, buttonWidth, buttonHeight), "Burst Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.TB_PLAYER_BURST_COOLDOWN - .1f <= 0 || saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_BURST_COOLDOWN -= 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_BURST_COOLDOWN.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Radius", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_BURST_RADIUS += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_BURST_RADIUS.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Damage", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.TB_PLAYER_BURST_DAMAGE += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.TB_PLAYER_BURST_DAMAGE.ToString(), StatModifersButtonStyle);
            }
                //BOMBUS
            else if (PreferencesManager.BOMBUS_SELECTED) {
                //health multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 40, buttonWidth, buttonHeight), "Health Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_HEALTH_MODIFIER += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), (saveObject.BB_PLAYER_HEALTH_MODIFIER * 100).ToString(), StatModifersButtonStyle);

                //score multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 160, buttonWidth, buttonHeight), "Score Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SCORE_MODIFIER += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SCORE_MODIFIER.ToString(), StatModifersButtonStyle);

                //Shield duration and cooldown
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 130, buttonWidth, buttonHeight), "Shield Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SHIELD_DURATION += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SHIELD_DURATION.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Shield Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.BB_PLAYER_SHIELD_COOLDOWN - .1f <= 0 || saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SHIELD_COOLDOWN -= 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SHIELD_COOLDOWN.ToString(), StatModifersButtonStyle);

                //speed boost duration cooldown and multiplier
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 85, buttonWidth, buttonHeight), "Boost Duration", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SPEED_BOOST_DURATION += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SPEED_BOOST_DURATION.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.BB_PLAYER_SPEED_BOOST_COOLDOWN - .1f <= 0 || saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SPEED_BOOST_COOLDOWN -= 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SPEED_BOOST_COOLDOWN.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Boost Multiplier", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_SPEED_BOOST_MULTIPLIER += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_SPEED_BOOST_MULTIPLIER.ToString(), StatModifersButtonStyle);

                //arcane burst cooldown radio and damage
                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += 75, buttonWidth, buttonHeight), "Burst Cooldown", StatModifersButtonStyle)) {
                    if (saveObject.BB_PLAYER_BURST_COOLDOWN - .1f <= 0 || saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_BURST_COOLDOWN -= 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_BURST_COOLDOWN.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Radius", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_BURST_RADIUS += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_BURST_RADIUS.ToString(), StatModifersButtonStyle);

                if (GUI.Button(new Rect(buttonAlignLeftX, buttonAlignLeftY += buttonHeight, buttonWidth, buttonHeight), "Burst Damage", StatModifersButtonStyle)) {
                    if (saveObject.PLAYER_CURRENCY - 1 < 0) { return; }
                    saveObject.PLAYER_CURRENCY -= 1;
                    saveObject.BB_PLAYER_BURST_DAMAGE += 0.1f;
                }
                GUI.Label(new Rect(buttonAlignLeftX + buttonWidth + buttonLabelBuffer, buttonAlignLeftY, labelWidth, labelHeight), saveObject.BB_PLAYER_BURST_DAMAGE.ToString(), StatModifersButtonStyle);
            }
        }
    }
}
