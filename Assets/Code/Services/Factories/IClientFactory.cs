using Code.Units.Clients;
using UnityEngine;

namespace Code.Services.Factories
{
    public interface IClientFactory
    {
        IClient CreateClient(Transform at, Transform container);
    }
}