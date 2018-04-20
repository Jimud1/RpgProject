using System.Collections.Generic;
using Assets.Scripts.Data.Entities;

namespace Assets.Scripts.Data
{
    public interface IRepository 
    {
        JsonGameContext GameContext { get; }
    }
}
