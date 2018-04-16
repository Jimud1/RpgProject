using UnityEngine;
using Zenject;

namespace Assets.Scripts.Npc
{
    public class cNpc : ANpc
    {
        public Sprite _btnSprite;
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
        public override Sprite BtnSprite
        {
            get
            {
                return _btnSprite;
            }
        }
    }
}
