using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;
using GoH = Assets.Scripts.Util.GameObjectHelper;
using Assets.Scripts.Story;
using Zenject;
namespace Assets.Scripts.NonPlayerCharacter
{
    public class Npc : MonoBehaviour, INpc
    {
        private GameObject _canvas;
        private Canvas Canvas;
        private int ConversationChoice = 0;
        public IStoryService _storyService;
        public Sprite BtnSprite;
        public int NpcStoryId
        {
            get
            {
                return 1;
            }
        }

        [Inject]
        public void Create(IStoryService storyService)
        {
            _storyService = storyService;
        }

        private void Start()
        {
            _canvas = GoH.AddCanvas(500, 100);
            FillCanvas(_canvas);
            Canvas = _canvas.GetComponent<Canvas>();
        }
        #region Story
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

        public virtual void OnTriggerStay(Collider col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    Converse();
            }
        }
        #endregion

        private void FillCanvas(GameObject canvas)
        {
            var wdt = 160;
            var hgt = 30;
            var conversation = Story.Conversations[ConversationChoice].ConversationText;
            GoH.AddTextToGameObject(canvas, conversation, 500, 100);
            var convoOptions = Story.Conversations[ConversationChoice].ConversationOptions;
            int count = 0;
            foreach (var option in convoOptions)
            {
                int nextConvo = 0;
                if(ConversationChoice <= Story.Conversations.Count())
                {
                    nextConvo = ConversationChoice + 1;
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
                int.TryParse(go.name, out ConversationChoice);
                ClearChildren(_canvas.transform);
                FillCanvas(_canvas);
            }
        }

        private void PositionRect(GameObject obj, int y)
        {
            GoH.PlaceRect(obj, 0, y, 0);
        }
    }
}
