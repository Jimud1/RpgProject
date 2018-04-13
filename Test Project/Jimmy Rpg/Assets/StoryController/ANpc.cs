using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace Assets.StoryController
{
    public abstract class ANpc : MonoBehaviour, INpc
    {
        private StoryModel _story;
        private Canvas Canvas;

        private void Start()
        {
            Canvas = GameObject.FindGameObjectWithTag("ConversationUi").GetComponent<Canvas>();
            FillCanvas();
        }

        private void FillCanvas()
        {
            Text[] texts = Canvas.GetComponentsInChildren<Text>();

            var conversation = Story.Conversations[0].ConversationText;
            var convoOptions = Story.Conversations[0].ConversationOptions;

            texts[0].text = conversation;
            //Last will be where we place converstion text, the rest will be from btns
            for (int i = 1; i <= texts.Length - 1; i++)
            {
                texts[i].text = convoOptions[i - 1];
            }
        }

        public void Converse()
        {
            if (Canvas.enabled)
                Canvas.enabled = false;
            else
                Canvas.enabled = true;
        }

        private IStoryRepository _storyRepository;
        public IStoryRepository StoryRepository
        {
            get
            {
                return _storyRepository ?? (_storyRepository = new StoryRepository());
            }
        }

        public StoryModel Story
        {
            get
            {
                return _story ?? (_story = StoryRepository.Stories.Where(
                    x => x.StoryId == NpcStoryId).FirstOrDefault());
            }
        }
        public abstract int NpcStoryId { get; }

        /// <summary>
        /// Control display
        /// </summary>
        /// <param name="col"></param>
        public virtual void OnTriggerStay (Collider col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    Converse();
            }
        }
    }
}
