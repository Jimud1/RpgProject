﻿using System.Collections.Generic;
using Assets.Scripts.Entities;

namespace Assets.Scripts
{
    public interface IRepository 
    {
        IEnumerable<StoryModel> Stories { get; }
    }
}
