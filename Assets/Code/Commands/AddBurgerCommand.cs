using Code.Tables;

namespace Code.Commands
{
    public class AddBurgerCommand : ICommand
    {
        private Table _table;

        public AddBurgerCommand(Table table)
        {
            _table = table;
        }
        
        public void Execute() => 
            _table.Add();
    }
}