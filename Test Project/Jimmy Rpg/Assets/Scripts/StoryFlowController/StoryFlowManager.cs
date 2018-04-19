using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;
using GoH = Assets.Scripts.Util.GameObjectHelper;
using Assets.Scripts.Story;
using Zenject;
using System;
using Assets.Scripts.Entities;
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
            _canvas = GoH.AddCanvas("My Canvas", 500, 100);
            Canvas = _canvas.GetComponent<Canvas>();
            GetConversation(ConversationChoice);
            FillCanvas();    
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

        public bool Conversing
        {
            get
            {
                return (_canvas.transform.childCount > 1);
            }
        }
        #endregion

        private ConversationModel GetConversation(int index)
        {
            //starts at 0
            if (index < 0 || index > CurrentStory.Conversations.Count() - 1) throw new ArgumentOutOfRangeException("Index out of range");
            if (CurrentConversation == CurrentStory.Conversations[index]) throw new ArgumentException("Getting same conversation");
            CurrentConversation = CurrentStory.Conversations[index];
            return CurrentConversation;
        }

        public void FillCanvas()
        {
            var conversation = CurrentConversation.ConversationText;
            GoH.AddTextToGameObject(_canvas, conversation, 500, 100);
            var options = CurrentConversation.ConversationOptions;
            int btnCount = 0;
            var nextConversation = ConversationChoice + 1;

            foreach (var option in options)
            {
                if (option.Value != null)
                    nextConversation = (int)option.Value;
                var btn = Instantiate(BtnPrefab);
                GoH.UpdateBtn(option.Key, nextConversation, 160, 30, btn, Canvas.gameObject);
                PositionRect(btn.gameObject, -50 * - (-btnCount));
                if(option.Value == null)
                    btn.onClick.AddListener(ConversationOnClick);
                else
                    btn.onClick.AddListener(StoryLeadOnClick);
                btnCount++;
            }
        }

        private void StoryLeadOnClick()
        {
            var go = EventSystem.current.currentSelectedGameObject;

            if (go != null)
            {
                int temp;
                int.TryParse(go.name, out temp);
                NextStory(temp);
                DeleteChildren(_canvas.transform);
            }
        }

        private void NextStory(int? nextStory)
        {
            _story = _storyService.Get((int) nextStory);
            ConversationChoice = 0;
            GetConversation(ConversationChoice);
        }

        private void ConversationOnClick()
        {  
            var go = EventSystem.current.currentSelectedGameObject;

            if (go != null)
            {
                int.TryParse(go.name, out ConversationChoice);
                GetConversation(ConversationChoice);
                ClearChildren(_canvas.transform);
                FillCanvas();
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
