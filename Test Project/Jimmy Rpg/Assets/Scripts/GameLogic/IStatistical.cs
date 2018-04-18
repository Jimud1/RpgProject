namespace Assets.Scripts.GameLogic
{
    public interface IStatistical
    {
        float MaxHp { get; set; }
        float CurrentHp { get; set; }
        float Strength { get; set; }
        float Dexterity { get; set; }
        float Accuracy { get; set; }
        float Constitution { get; set; }
        float Intelligence { get; set; }
        float Wisdom { get; set; }
    }
}
