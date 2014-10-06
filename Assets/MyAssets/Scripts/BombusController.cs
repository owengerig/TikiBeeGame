using System.Collections;
using UnityEngine;

namespace TikiBeeGame {
    class BombusController : PlayerController {

        // Use this for initialization
        public override void Start() {
            loadDataFromPersistantStore();

            this.HEALTH = Mathf.RoundToInt(HEALTH_MULTIPLIER * 100.0f);
            this.SCORE = 0;
            this.DAMAGE = 5;
            this.MOVE_SPEED = 3;
            this.MOVE_SPEED_DEFAULT = 3;
            this.TURN_SPEED = 5;
            base.Start();
        }

        public void death() {
            DestroyMe();
        }

        public void loadDataFromPersistantStore() {
            //load currency from persistent data
            SaveObject so = PersistantData.Load();

            this.CURRENCY = so.PLAYER_CURRENCY;
            this.HEALTH_MULTIPLIER = so.BB_PLAYER_HEALTH_MODIFIER;
            this.SCORE_MODIFIER = so.BB_PLAYER_SCORE_MODIFIER;
            this.SHIELD_DURATION = so.BB_PLAYER_SHIELD_DURATION;
            this.SHIELD_COOLDOWN = so.BB_PLAYER_SHIELD_COOLDOWN;
            this.SPEED_BOOST_DURATION = so.BB_PLAYER_SPEED_BOOST_DURATION;
            this.SPEED_BOOST_COOLDOWN = so.BB_PLAYER_SPEED_BOOST_COOLDOWN;
            this.SPEED_BOOST_MULTIPLIER = so.BB_PLAYER_SPEED_BOOST_MULTIPLIER;
            this.BURST_DAMAGE = so.BB_PLAYER_BURST_DAMAGE;
            this.BURST_COOLDOWN = so.BB_PLAYER_BURST_COOLDOWN;
            this.BURST_RADIUS = so.BB_PLAYER_BURST_RADIUS;
        }
    }
}
