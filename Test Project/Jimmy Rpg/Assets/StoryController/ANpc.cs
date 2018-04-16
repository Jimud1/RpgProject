using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;
using GoH = Assets.StoryController.GameObjectHelper;

namespace Assets.StoryController
{
    public abstract class ANpc : MonoBehaviour, INpc
    {
        private GameObject _canvas;
        private Canvas Canvas;
        private int Choice = 0;
        private void Start()
        {
            _storyService = new StoryService();
            _canvas = GoH.AddCanvas(500, 100);
            FillCanvas(_canvas);
            Canvas = _canvas.GetComponent<Canvas>();
        }           
        private void FillCanvas(GameObject canvas)
        {
            var wdt = 160;
            var hgt = 30;
            var conversation = Story.Conversations[Choice].ConversationText;
            GoH.AddTextToGameObject(canvas, conversation, 500, 100);
            var convoOptions = Story.Conversations[Choice].ConversationOptions;
            int count = 0;
            foreach (var option in convoOptions)
            {
                int nextConvo = 0;
                if(Choice <= Story.Conversations.Count())
                {
                    nextConvo = Choice + 1;
                }
                else
                {
                    nextConvo = Story.Conversations.Count() - 1;
                }
                var btn = GoH.CreateBtn(option, nextConvo, canvas, wdt, hgt, BtnSprite);
                PositionRect(btn, -50 * - (-count));
                var button = btn.GetComponent<Button>();
                button.onClick.AddListener(ConversationOnClick);
                count++;
            }
        }

        public void ClearChildren(Transform transform)
        {
            foreach (Transform child in transform)
            {
                GoH.HideObject(child.gameObject);
            }
        }

        private void ConversationOnClick()
        {  
            var go = EventSystem.current.currentSelectedGameObject;
            if (go != null)
            {
                int.TryParse(go.name, out Choice);
                ClearChildren(_canvas.transform);
                FillCanvas(_canvas);
            }
        }

        private void PositionRect(GameObject obj, int y)
        {
            GoH.PlaceRect(obj, 0, y, 0);
        }

        #region Story
        private IStoryService _storyService;
        public abstract int NpcStoryId { get; }
        public abstract Sprite BtnSprite {get;}
        public void Converse()
        {
            if (Canvas.enabled)
                Canvas.enabled = false;
            else
                Canvas.enabled = true;
        }
        private StoryModel _story;
        public StoryModel Story
        {
            get
            {
                return _story ?? (_story = _storyService.Get(NpcStoryId));
            }
        }
        public virtual void OnTriggerStay (Collider col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    Converse();
            }
        }
        #endregion
    }
}
