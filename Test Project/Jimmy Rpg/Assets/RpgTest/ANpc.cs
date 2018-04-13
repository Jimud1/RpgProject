using UnityEngine;
using System.Linq;

namespace Assets.RpgTest
{
    public abstract class ANpc : MonoBehaviour, INpc
    {
        private StoryModel _story;
        public abstract void Converse();

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
