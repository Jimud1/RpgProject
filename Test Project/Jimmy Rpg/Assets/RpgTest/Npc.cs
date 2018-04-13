using Assets.StoryController;

namespace Assets.RpgTest
{
    public class Npc : ANpc
    {
        /// <summary>
        /// Id of story for this Npc 
        /// </summary>
        public override int NpcStoryId
        {
            get
            {
                return RpgStorySettings.NpcOneId;
            }
        }
    }
}
