namespace Assets.Scripts.Data.Entities
{
    public interface IItem : IEntity
    {
        int ItemId { get; set; }
        string ItemName { get; set; }
        string ItemDescription { get; set; }
        decimal ItemValue { get; set; }
    }
}
