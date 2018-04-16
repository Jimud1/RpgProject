using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;
using GoH = Assets.Scripts.Util.GameObjectHelper;
using Assets.Scripts.Story;
using Zenject;
namespace Assets.Scripts.StoryFlowController
{
    public class StoryFlowManager : MonoBehaviour, IStoryFlowManager
    {
        private GameObject _canvas;
        private Canvas Canvas;
        public int ConversationChoice = 0;
        public IStoryService _storyService;
        public Button BtnPrefab;
        public ConversationModel CurrentConversation;

        [Inject]
        public void Create(IStoryService storyService)
        {
            _storyService = storyService;
        }

        private void Start()
        {
            _canvas = GoH.AddCanvas(500, 100);
            Canvas = _canvas.GetComponent<Canvas>();
            FillCanvas(_canvas);    
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
        public StoryModel CurrentStory
        {
            get
            {
                //If it's null then get the 1st
                return _story ?? (_story = _storyService.Get(1));
            }
        }
        #endregion

        private void FillCanvas(GameObject canvas)
        {

            CurrentConversation = CurrentStory.Conversations[ConversationChoice];
            var conversation = CurrentStory.Conversations[ConversationChoice].ConversationText;
            GoH.AddTextToGameObject(canvas, conversation, 500, 100);

            var convoOptions = CurrentStory.Conversations[ConversationChoice].ConversationOptions;
            int btnCount = 0;
            var maxOption = CurrentStory.Conversations.Count();
            var nextConversation = ConversationChoice + 1;

            foreach (var option in convoOptions)
            {
                if(nextConversation >= maxOption - 1)
                {
                    nextConversation = maxOption - 1;
                }
                var liveBtn = Instantiate(BtnPrefab);
                var btn = GoH.UpdateBtn(option, nextConversation, 160, 30, liveBtn, Canvas.gameObject);
                PositionRect(btn.gameObject, -50 * - (-btnCount));
                btn.onClick.AddListener(ConversationOnClick);
                btnCount++;
            }

            if (CurrentConversation.StoryLeadId != null)
            {
                Debug.Log("Lead id is " + CurrentConversation.StoryLeadId.ToString());
                NextStory(CurrentConversation.StoryLeadId);
            }

        }

        private void NextStory(int? nextStory)
        {
            ConversationChoice = -1;
            _story = _storyService.Get((int) nextStory);
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


        public void ClearChildren(Transform transform)
        {
            foreach (Transform child in transform)
            {
                GoH.HideObject(child.gameObject);
            }
        }

        private void PositionRect(GameObject obj, int y)
        {
            GoH.PlaceRect(obj, 0, y, 0);
        }
    }
}
