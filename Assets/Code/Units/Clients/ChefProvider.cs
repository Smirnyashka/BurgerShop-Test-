using Code.Tables;

namespace Code.Units.Clients
{
    public class ChefProvider
    {
        public Chef.Chef _chef { get; private set; }

        public void Set(Chef.Chef chef) =>
            _chef = chef;
    }
}