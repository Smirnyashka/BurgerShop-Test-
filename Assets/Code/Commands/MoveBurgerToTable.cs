using Code.Tables;
using Code.Units.Chef;

namespace Code.Commands
{
    public class MoveBurgerToTable: ICommand
    {
        private IPlayer _chef;
        private Table _table;

        public MoveBurgerToTable(IPlayer chef, Table table)
        {
            _chef = chef;
            _table = table;
        }

        public void Execute()
        {
            if (_chef.HasBurger && _table.HasBurger == false)
            {
                _table.Add();
                _chef.PutBurger();
            }
        }
    }
}