namespace Code.Units.Clients
{
    public interface IClientServiceProvider
    {
        ClientService Service { get; }
        void Set(ClientService service);
    }
}