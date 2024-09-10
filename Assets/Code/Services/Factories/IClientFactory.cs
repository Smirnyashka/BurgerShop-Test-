using Code.Enemy;
using UnityEngine;

namespace Code.Services.Factories
{
    public interface IClientFactory
    {
        IClient CreateClient(Transform at);
    }
}