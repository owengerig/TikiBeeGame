//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections;
using UnityEngine;

namespace TikiBeeGame {
    public static class SpawnPoint {

        private static float yExtent = Camera.main.camera.orthographicSize;
        private static float xExtent = yExtent * Screen.width / Screen.height;
        private static float xExtendWithInsideBuffer = xExtent - 1.0f;
        private static float yExtendWithInsideBuffer = yExtent - 1.0f;
        private static float xExtendWithOutsideBuffer = xExtent + 1.0f;
        private static float yExtendWithOutsideBuffer = yExtent + 1.0f;

        private static GameHudController gameHudController;


        public static Vector3 getSpawnPointAtRandomInsideBounds() {
            if (Camera.main == null) {
                return new Vector3(0f, 0f, -1.0f);
            }

            Vector3 returnVal = new Vector3(0f, 0f, 0f);

            float screenX = Random.Range(0.0f, Camera.main.pixelWidth);
            float screenY = Random.Range(Camera.main.pixelHeight / 4.5f, Camera.main.pixelHeight);
            float ScreenZ = Random.Range(Camera.main.nearClipPlane, Camera.main.farClipPlane);
            return Camera.main.ScreenToWorldPoint(new Vector3(screenX, screenY, ScreenZ));
        }

        public static Vector3 getSpawnPointAtRandomInsideBoundsExcludeHud() {
            Vector3 returnVal = getSpawnPointAtRandomInsideBounds();
            if (Camera.main == null) {
                return new Vector3(0f, 0f, -1.0f);
            }

            bool collidesWithHud = doesCollideWithHud(returnVal);
            while (collidesWithHud) {
                returnVal = getSpawnPointAtRandomInsideBounds();
                collidesWithHud = doesCollideWithHud(returnVal);
            }
            //return returnVal;
            return getSpawnPointAtRandomInsideBounds();
        }

        private static bool doesCollideWithHud(Vector3 preposedPosition) {
            preposedPosition = Camera.main.WorldToScreenPoint(preposedPosition);

            if (gameHudController == null) {
                GameObject hudControllerGO = GameObject.FindGameObjectWithTag("Hud");
                if (hudControllerGO != null) {
                    gameHudController = hudControllerGO.GetComponent<GameHudController>();
                }
                if (gameHudController == null) { return false; }
            }
            return gameHudController.onHud(new Vector2(preposedPosition.x, preposedPosition.y));
        }
        public static Vector3 getSpawnPointAtTopOutsideBounds() {
            return Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1.1f, 1f));
        }
        public static Vector3 getSpawnPointAtBottomOutsideBounds() {
            return Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), -.1f, 1f));
        }
        public static Vector3 getSpawnPointAtRightOutsideBounds() {
            return Camera.main.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0f, 1f), 1f));
        }
        public static Vector3 getSpawnPointAtLeftOutsideBounds() {
            return Camera.main.ViewportToWorldPoint(new Vector3(-.1f, Random.Range(0f, 1f), 1f));
        }
    }
}

