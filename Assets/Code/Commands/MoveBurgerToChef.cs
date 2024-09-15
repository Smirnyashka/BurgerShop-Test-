using Code.Tables;
using Code.Units.Chef;

namespace Code.Commands
{
    public class MoveBurgerToChef:ICommand
    {
        private IPlayer _chef;
        private Table _table;

        public MoveBurgerToChef(IPlayer chef, Table table)
        {
            _chef = chef;
            _table = table;
        }

        public void Execute()
        {
            if (_table.HasBurger && _chef.HasBurger == false)
            {
                _table.Clear();
                _chef.TakeBurger();
            }
        }
    }
}