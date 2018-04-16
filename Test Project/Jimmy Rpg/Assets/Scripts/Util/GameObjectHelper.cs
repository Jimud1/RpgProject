using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace Assets.Scripts.Util
{
    public static class GameObjectHelper 
    {
        /// <summary>
        /// Add text to gameobject, creates object and adds text
        /// component to object then adds to gameObject
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="text"></param>
        public static Text AddTextToGameObject(GameObject gameObject, string text, float width, float height)
        {
            var obj = CreateObject();
            Text txt = obj.AddComponent<Text>();
            txt.name = "Test-" + text;
            txt.text = text;
            txt.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            txt.color = Color.black;
            obj.transform.SetParent(gameObject.transform, true);
            var rectTrans = obj.GetComponent<RectTransform>();
            SetRectTransformXy(rectTrans, width, height);
            return txt;
        }

        public static void SetRectTransformXy(RectTransform rect, float x, float y)
        {
            rect.anchoredPosition = Vector3.zero;
            rect.sizeDelta = new Vector2(x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="count"></param>
        /// <param name="canvas"></param>
        public static GameObject CreateBtn(string text, int count, GameObject canvas, 
            float width, float height, Sprite sprite)
        {
            var obj = new GameObject();
            var button = obj.AddComponent<Button>();
            obj.transform.SetParent(canvas.transform, false);
            var rectTransform = obj.AddComponent<RectTransform>();
            SetRectTransformXy(rectTransform, width, height);
            button.name = count.ToString();
            var image = AddImageTo(obj, sprite);
            button.targetGraphic = image;
            var txt = AddTextToGameObject(obj, text, width, height);
            txt.alignment = TextAnchor.MiddleCenter;
            return obj;
        }

        public static Button UpdateBtn(string text, int count,  float width, float height, 
            Button btn, GameObject parent)
        {
            SetParent(parent.transform, btn.transform);
            var rectTransform = btn.GetComponent<RectTransform>();
            SetRectTransformXy(rectTransform, width, height);
            btn.name = count.ToString();
            var txt = AddTextToGameObject(btn.gameObject, text, width, height);
            txt.alignment = TextAnchor.MiddleCenter;
            return btn;
        }

        public static void SetParent(Transform parent, Transform child)
        {
            child.SetParent(parent);
        }

        public static void DestroyObject(GameObject obj)
        {
           GameObject.Destroy(obj);
        }

        public static void HideObject(GameObject obj)
        {
            obj.SetActive(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        public static void PlaceRect(GameObject obj,float x, float y, float z)
        {
            var rect = obj.GetComponent<RectTransform>();
            rect.localPosition = new Vector3(x, y, z);
        }

        public static Image AddImageTo(GameObject obj, Sprite sprite)
        {
            var image = obj.AddComponent<Image>();
            image.sprite = sprite;
            image.type = Image.Type.Sliced;
            return image;
        }

        private static GameObject CreateObject()
        {
            return new GameObject();
        }

        public static GameObject AddCanvas(float width, float height)
        {
            var obj = CreateObject();
            obj.name = "Test";
            var canvas = obj.AddComponent<Canvas>();
            obj.AddComponent<CanvasScaler>();
            obj.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            var rectTransform = obj.GetComponent<RectTransform>();
            SetRectTransformXy(rectTransform, width, height); 
            return obj;
        }
    }
}