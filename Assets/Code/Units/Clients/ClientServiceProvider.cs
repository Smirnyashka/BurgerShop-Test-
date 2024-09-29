namespace Code.Units.Clients
{
    public class ClientServiceProvider : IClientServiceProvider
    {
        public ClientService Service { get; private set; }

        public void Set(ClientService service) => 
            Service = service;
    }
}