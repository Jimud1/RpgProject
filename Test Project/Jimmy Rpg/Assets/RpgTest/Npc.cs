using UnityEngine;

namespace Assets.RpgTest
{
    public class Npc : ANpc
    {   

        private bool displayGui = false;
        public Canvas canvas;

        /// <summary>
        /// Id of story for this Npc 
        /// </summary>
        public override int NpcStoryId
        {
            get
            {
                return 1;
            }
        }

        public override void Converse()
        {
            if (displayGui)
                displayGui = false;
            else
                displayGui = true;
        }
    }
}
