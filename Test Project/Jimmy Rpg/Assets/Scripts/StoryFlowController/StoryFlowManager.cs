using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;
using GoH = Assets.Scripts.Util.GameObjectHelper;
using Assets.Scripts.Story;
using Zenject;
using System;

namespace Assets.Scripts.StoryFlowController
{
    public class StoryFlowManager : MonoBehaviour, IStoryFlowManager
    {
        private GameObject _canvas;
        private Canvas Canvas;
        public int ConversationChoice = 0;
        public IStoryService _storyService;
        public Button BtnPrefab;
        private ConversationModel CurrentConversation;

        [Inject]
        public void Create(IStoryService storyService)
        {
            _storyService = storyService;
        }

        private void Start()
        {
            _canvas = GoH.AddCanvas(500, 100);
            Canvas = _canvas.GetComponent<Canvas>();
            GetConversation(ConversationChoice);
            FillCanvas(_canvas);    
        }
        #region Story
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

        private ConversationModel GetConversation(int index)
        {
            //starts at 0
            if (index < 0) throw new ArgumentOutOfRangeException("Index is below range");
            if (CurrentConversation == CurrentStory.Conversations[index]) throw new ArgumentException("Getting same conversation");
            if (index > CurrentStory.Conversations.Count() - 1) throw new ArgumentOutOfRangeException("Index above range");
            CurrentConversation = CurrentStory.Conversations[index];
            return CurrentConversation;
        }

        private void FillCanvas(GameObject canvas)
        {
            
            var conversation = CurrentConversation.ConversationText;
            GoH.AddTextToGameObject(canvas, conversation, 500, 100);
            var options = CurrentConversation.ConversationOptions;
            int btnCount = 0;
            var maxOption = CurrentStory.Conversations.Count() - 1;
            var nextConversation = ConversationChoice + 1;

            foreach (var option in options)
            {
                var btn = Instantiate(BtnPrefab);
                GoH.UpdateBtn(option, nextConversation, 160, 30, btn, Canvas.gameObject);
                PositionRect(btn.gameObject, -50 * - (-btnCount));
                btn.onClick.AddListener(ConversationOnClick);
                btnCount++;
            }

            //if (isNewStory)
            //{
                //ClearChildren(_canvas.transform);
                //isNewStory = false;
                //return;
            //}

            if (CurrentConversation.StoryLeadId != null)
            {
                Debug.Log("Lead id is " + CurrentConversation.StoryLeadId.ToString());
                NextStory(CurrentConversation.StoryLeadId);
            }
        }

        private void NextStory(int? nextStory)
        {
            _story = _storyService.Get((int) nextStory);
            //Reset after use
            ConversationChoice = 0;
            GetConversation(ConversationChoice);
            isNewStory = true;
        }

        private bool isNewStory = false;
        private void ConversationOnClick()
        {  
            var go = EventSystem.current.currentSelectedGameObject;

            if (go != null && !isNewStory)
            {
                int.TryParse(go.name, out ConversationChoice);
                GetConversation(ConversationChoice);
                ClearChildren(_canvas.transform);
                FillCanvas(_canvas);
            }
            else
            {
                isNewStory = false;
                DeleteChildren(_canvas.transform);
            }
        }

        public void DeleteChildren(Transform transform)
        {
            foreach (Transform child in transform)
            {
                GoH.DestroyObject(child.gameObject);
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
