﻿using UnityEngine;

namespace Assets.StoryController
{
    public interface INpc
    {
        /// <summary>
        /// Method for displaying UI
        /// </summary>
        void Converse();
        StoryModel Story { get; }
        IStoryRepository StoryRepository { get; }
        int NpcStoryId { get; }
    }
}