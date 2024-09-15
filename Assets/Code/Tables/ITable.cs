namespace Code.Tables
{
    public interface ITable
    {
        void Clear();
        void Add();
        
        public bool HasBurger { get; }
    }
}