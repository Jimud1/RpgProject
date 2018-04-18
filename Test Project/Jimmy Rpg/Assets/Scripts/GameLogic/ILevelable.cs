namespace Assets.Scripts.GameLogic
{
    public interface ILevelable
    {
        void AddExperience(float exp);
        void LevelUp();
        LevelModel Level { get; }
    }
}