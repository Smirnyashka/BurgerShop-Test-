using Code.Tables;

namespace Code.Commands
{
    public class ClearTableCommand : ICommand
    {
        private Table _table;

        public ClearTableCommand(Table table)
        {
            _table = table;
        }
        
        public void Execute() => 
            _table.Clear();
    }
}