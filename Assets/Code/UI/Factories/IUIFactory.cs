using Code.Logic;
using Code.Services;
using UnityEngine;

namespace Code.UI.Factories
{
    public interface IUIFactory : IService
    {
        GameObject CreateHud(IDamageable damageable);
    }
}