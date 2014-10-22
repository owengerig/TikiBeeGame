using System.Collections;
using UnityEngine;

namespace TikiBeeGame {

    public class TikiBeeController : PlayerController {

        // Use this for initialization
        public override void Start() {
            loadDataFromPersistantStore();

            this.HEALTH = Mathf.RoundToInt(HEALTH_MULTIPLIER * 100.0f);
            this.SCORE = 0;
            this.DAMAGE = 5;
            this.TURN_SPEED = 5;
            
            base.Start();
        }
        

        public void death() {
            DestroyMe();
        }

        public void loadDataFromPersistantStore() {
            //load currency from persistent data
            SaveObject so = PersistantData.Load();

            //add defaults
            //this.CURRENCY = so.PLAYER_CURRENCY;
            this.MOVE_SPEED = so.TB_PLAYER_SPEED_MODIFIER + 3;
            this.MOVE_SPEED_DEFAULT = so.TB_PLAYER_SPEED_MODIFIER + 3;
            this.HEALTH_MULTIPLIER = so.TB_PLAYER_HEALTH_MODIFIER+1;
            this.SCORE_MODIFIER = so.TB_PLAYER_SCORE_MODIFIER+1;
            this.SHIELD_DURATION = so.TB_PLAYER_SHIELD_DURATION+2;
            this.SHIELD_COOLDOWN = 10-so.TB_PLAYER_SHIELD_COOLDOWN;
            this.SPEED_BOOST_DURATION = so.TB_PLAYER_SPEED_BOOST_DURATION+2;
            this.SPEED_BOOST_COOLDOWN = 10-so.TB_PLAYER_SPEED_BOOST_COOLDOWN;
            this.SPEED_BOOST_MULTIPLIER = so.TB_PLAYER_SPEED_BOOST_MULTIPLIER+1;
            this.BURST_DAMAGE = so.TB_PLAYER_BURST_DAMAGE+2;
            this.BURST_COOLDOWN = 10-so.TB_PLAYER_BURST_COOLDOWN;
            this.BURST_RADIUS = so.TB_PLAYER_BURST_RADIUS+1;
        }
    }
}