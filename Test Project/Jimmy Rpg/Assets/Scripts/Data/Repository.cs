using Assets.Scripts.Data.Entities;


namespace Assets.Scripts.Data
{
    public class Repository : IRepository
    {
        private JsonGameContext _gameContext;
        public JsonGameContext GameContext
        {
            get
            {
                return _gameContext ?? (_gameContext = new JsonGameContext());
            }
        }
    }
}
