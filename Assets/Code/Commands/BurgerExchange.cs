using Code.Tables;
using Code.Units.Chef;

namespace Code.Commands
{
    public class BurgerExchange
    {
        private IPlayer _chef;
        private Table _table;


        public void MoveToTable()
        {
            if (_chef.HasBurger && _table.HasBurger == false)
            {
                _table.Add();
                _chef.PutBurger();
            }
        }

        public void MoveToChef()
        {
            if (_table.HasBurger && _chef.HasBurger == false)
            {
                _table.Clear();
                _chef.TakeBurger();
            }
        }
    }
}