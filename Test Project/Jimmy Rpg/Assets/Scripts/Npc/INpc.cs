using Assets.Scripts.Story;

namespace Assets.Scripts.Npc
{
    public interface INpc
    {
        /// <summary>
        /// Method for displaying UI
        /// </summary>
        void Converse();
        StoryModel Story { get; }
        int NpcStoryId { get; }
    }
}
