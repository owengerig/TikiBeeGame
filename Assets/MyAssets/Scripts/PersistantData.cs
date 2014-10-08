using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TikiBeeGame {
    static class PersistantData {
        public static void Save(SaveObject data) {
            Stream stream = File.Open("MySavedGame.game", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Binder = new VersionDeserializationBinder();
            Logger.logGame("Writing Information");
            bformatter.Serialize(stream, data);
            stream.Close();
        }

        public static SaveObject Load() {
            SaveObject data = new SaveObject();

			if (!System.IO.File.Exists("MySavedGame.game")) {
                Logger.logGame("File not found, saving defaults");
				SaveDefaults();
			}
			Stream stream = File.Open("MySavedGame.game", FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Binder = new VersionDeserializationBinder();
            Logger.logGame("Reading Data");
            data = (SaveObject)bformatter.Deserialize(stream);
            stream.Close();
            return data;
        }

        public static void SaveDefaults() {
			SaveObject so = new SaveObject ();

            so.PLAYER_CURRENCY = 10;
            so.TB_PLAYER_SPEED_MODIFIER = 0;
            so.TB_PLAYER_HEALTH_MODIFIER = 0;
            so.TB_PLAYER_SCORE_MODIFIER = 0;
            so.TB_PLAYER_SHIELD_DURATION = 0;
            so.TB_PLAYER_SHIELD_COOLDOWN = 0;
            so.TB_PLAYER_SPEED_BOOST_DURATION = 0;
            so.TB_PLAYER_SPEED_BOOST_COOLDOWN = 0;
            so.TB_PLAYER_SPEED_BOOST_MULTIPLIER = 0;
            so.TB_PLAYER_BURST_COOLDOWN = 0;
            so.TB_PLAYER_BURST_RADIUS = 0;
            so.TB_PLAYER_BURST_DAMAGE = 0;
            so.BB_PLAYER_HEALTH_MODIFIER = 0;
            so.BB_PLAYER_SCORE_MODIFIER = 0;
            so.BB_PLAYER_SHIELD_DURATION = 0;
            so.BB_PLAYER_SHIELD_COOLDOWN = 0;
            so.BB_PLAYER_SPEED_BOOST_DURATION = 0;
            so.BB_PLAYER_SPEED_BOOST_COOLDOWN = 0;
            so.BB_PLAYER_SPEED_BOOST_MULTIPLIER = 0;
            so.BB_PLAYER_BURST_COOLDOWN = 0;
            so.BB_PLAYER_BURST_RADIUS = 0;
            so.BB_PLAYER_BURST_DAMAGE = 0;

			Save (so);
		}

        public static void Delete() {
            if (System.IO.File.Exists("MySavedGame.game")) {
                System.IO.File.Delete("MySavedGame.game");
            }
        }
    }

    [Serializable()]
    class SaveObject : ISerializable {
        public int PLAYER_CURRENCY = 0;
        public float TB_PLAYER_SPEED_MODIFIER = 0;
        public float TB_PLAYER_HEALTH_MODIFIER = 0;
        public float TB_PLAYER_SCORE_MODIFIER = 0;
        public float TB_PLAYER_SHIELD_DURATION = 0;
        public float TB_PLAYER_SHIELD_COOLDOWN = 0;
        public float TB_PLAYER_SPEED_BOOST_DURATION = 0;
        public float TB_PLAYER_SPEED_BOOST_COOLDOWN = 0;
        public float TB_PLAYER_SPEED_BOOST_MULTIPLIER = 0;
        public float TB_PLAYER_BURST_COOLDOWN = 0;
        public float TB_PLAYER_BURST_RADIUS = 0;
        public float TB_PLAYER_BURST_DAMAGE = 0;
        public float BB_PLAYER_SPEED_MODIFIER = 0;
        public float BB_PLAYER_HEALTH_MODIFIER = 0;
        public float BB_PLAYER_SCORE_MODIFIER = 0;
        public float BB_PLAYER_SHIELD_DURATION = 0;
        public float BB_PLAYER_SHIELD_COOLDOWN = 0;
        public float BB_PLAYER_SPEED_BOOST_DURATION = 0;
        public float BB_PLAYER_SPEED_BOOST_COOLDOWN = 0;
        public float BB_PLAYER_SPEED_BOOST_MULTIPLIER = 0;
        public float BB_PLAYER_BURST_COOLDOWN = 0;
        public float BB_PLAYER_BURST_RADIUS = 0;
        public float BB_PLAYER_BURST_DAMAGE = 0;

        public SaveObject() {
        }

        protected SaveObject(SerializationInfo info, StreamingContext ctxt) {
            //Get the values from info and assign them to the appropriate properties
            PLAYER_CURRENCY = (int)info.GetValue("PLAYER_CURRENCY", typeof(int));
            TB_PLAYER_HEALTH_MODIFIER = (float)info.GetValue("TB_PLAYER_HEALTH_MODIFIER", typeof(float));
            TB_PLAYER_SPEED_MODIFIER = (float)info.GetValue("TB_PLAYER_SPEED_MODIFIER", typeof(float));
            TB_PLAYER_SCORE_MODIFIER = (float)info.GetValue("TB_PLAYER_SCORE_MODIFIER", typeof(float));
            TB_PLAYER_SHIELD_DURATION = (float)info.GetValue("TB_PLAYER_SHIELD_DURATION", typeof(float));
            TB_PLAYER_SHIELD_COOLDOWN = (float)info.GetValue("TB_PLAYER_SHIELD_COOLDOWN", typeof(float));
            TB_PLAYER_SPEED_BOOST_DURATION = (float)info.GetValue("TB_PLAYER_SPEED_BOOST_DURATION", typeof(float));
            TB_PLAYER_SPEED_BOOST_COOLDOWN = (float)info.GetValue("TB_PLAYER_SPEED_BOOST_COOLDOWN", typeof(float));
            TB_PLAYER_SPEED_BOOST_MULTIPLIER = (float)info.GetValue("TB_PLAYER_SPEED_BOOST_MULTIPLIER", typeof(float));
            TB_PLAYER_BURST_COOLDOWN = (float)info.GetValue("TB_PLAYER_BURST_COOLDOWN", typeof(float));
            TB_PLAYER_BURST_RADIUS = (float)info.GetValue("TB_PLAYER_BURST_RADIUS", typeof(float));
            BB_PLAYER_BURST_DAMAGE = (float)info.GetValue("BB_PLAYER_BURST_DAMAGE", typeof(float));
            BB_PLAYER_HEALTH_MODIFIER = (float)info.GetValue("BB_PLAYER_HEALTH_MODIFIER", typeof(float));
            TB_PLAYER_SPEED_MODIFIER = (float)info.GetValue("TB_PLAYER_SPEED_MODIFIER", typeof(float));
            BB_PLAYER_SCORE_MODIFIER = (float)info.GetValue("BB_PLAYER_SCORE_MODIFIER", typeof(float));
            BB_PLAYER_SHIELD_DURATION = (float)info.GetValue("BB_PLAYER_SHIELD_DURATION", typeof(float));
            BB_PLAYER_SHIELD_COOLDOWN = (float)info.GetValue("BB_PLAYER_SHIELD_COOLDOWN", typeof(float));
            BB_PLAYER_SPEED_BOOST_DURATION = (float)info.GetValue("BB_PLAYER_SPEED_BOOST_DURATION", typeof(float));
            BB_PLAYER_SPEED_BOOST_COOLDOWN = (float)info.GetValue("BB_PLAYER_SPEED_BOOST_COOLDOWN", typeof(float));
            BB_PLAYER_SPEED_BOOST_MULTIPLIER = (float)info.GetValue("BB_PLAYER_SPEED_BOOST_MULTIPLIER", typeof(float));
            BB_PLAYER_BURST_COOLDOWN = (float)info.GetValue("BB_PLAYER_BURST_COOLDOWN", typeof(float));
            BB_PLAYER_BURST_RADIUS = (float)info.GetValue("BB_PLAYER_BURST_RADIUS", typeof(float));
            BB_PLAYER_BURST_DAMAGE = (float)info.GetValue("BB_PLAYER_BURST_DAMAGE", typeof(float));
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt) {
            info.AddValue("PLAYER_CURRENCY", (PLAYER_CURRENCY));
            info.AddValue("TB_PLAYER_HEALTH_MODIFIER", (TB_PLAYER_HEALTH_MODIFIER));
            info.AddValue("TB_PLAYER_SPEED_MODIFIER", (TB_PLAYER_SPEED_MODIFIER));
            info.AddValue("TB_PLAYER_SCORE_MODIFIER", (TB_PLAYER_SCORE_MODIFIER));
            info.AddValue("TB_PLAYER_SHIELD_DURATION", (TB_PLAYER_SHIELD_DURATION));
            info.AddValue("TB_PLAYER_SHIELD_COOLDOWN", (TB_PLAYER_SHIELD_COOLDOWN));
            info.AddValue("TB_PLAYER_SPEED_BOOST_DURATION", (TB_PLAYER_SPEED_BOOST_DURATION));
            info.AddValue("TB_PLAYER_SPEED_BOOST_COOLDOWN", (TB_PLAYER_SPEED_BOOST_COOLDOWN));
            info.AddValue("TB_PLAYER_SPEED_BOOST_MULTIPLIER", (TB_PLAYER_SPEED_BOOST_MULTIPLIER));
            info.AddValue("TB_PLAYER_BURST_COOLDOWN", (TB_PLAYER_BURST_COOLDOWN));
            info.AddValue("TB_PLAYER_BURST_RADIUS", (TB_PLAYER_BURST_RADIUS));
            info.AddValue("TB_PLAYER_BURST_DAMAGE", (TB_PLAYER_BURST_DAMAGE));
            info.AddValue("BB_PLAYER_HEALTH_MODIFIER", (BB_PLAYER_HEALTH_MODIFIER));
            info.AddValue("BB_PLAYER_SPEED_MODIFIER", (BB_PLAYER_SPEED_MODIFIER));
            info.AddValue("BB_PLAYER_SCORE_MODIFIER", (BB_PLAYER_SCORE_MODIFIER));
            info.AddValue("BB_PLAYER_SHIELD_DURATION", (BB_PLAYER_SHIELD_DURATION));
            info.AddValue("BB_PLAYER_SHIELD_COOLDOWN", (BB_PLAYER_SHIELD_COOLDOWN));
            info.AddValue("BB_PLAYER_SPEED_BOOST_DURATION", (BB_PLAYER_SPEED_BOOST_DURATION));
            info.AddValue("BB_PLAYER_SPEED_BOOST_COOLDOWN", (BB_PLAYER_SPEED_BOOST_COOLDOWN));
            info.AddValue("BB_PLAYER_SPEED_BOOST_MULTIPLIER", (BB_PLAYER_SPEED_BOOST_MULTIPLIER));
            info.AddValue("BB_PLAYER_BURST_COOLDOWN", (BB_PLAYER_BURST_COOLDOWN));
            info.AddValue("BB_PLAYER_BURST_RADIUS", (BB_PLAYER_BURST_RADIUS));
            info.AddValue("BB_PLAYER_BURST_DAMAGE", (BB_PLAYER_BURST_DAMAGE));
        }
    }
}
public sealed class VersionDeserializationBinder : SerializationBinder {
    public override Type BindToType(string assemblyName, string typeName) {
        if (!string.IsNullOrEmpty(assemblyName) && !string.IsNullOrEmpty(typeName)) {
            Type typeToDeserialize = null;

            assemblyName = Assembly.GetExecutingAssembly().FullName;

            // The following line of code returns the type. 
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));

            return typeToDeserialize;
        }

        return null;
    }
}
