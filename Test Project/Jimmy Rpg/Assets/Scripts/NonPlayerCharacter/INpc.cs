using Assets.Scripts.Story;

namespace Assets.Scripts.NonPlayerCharacter
{
    public interface INpc
    {
        void Converse();
        StoryModel Story { get; }
        int NpcStoryId { get; }
    }
}
