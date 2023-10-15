using Code.Infrastructure.AssetProvider;
using Code.Infrastructure.Constants;
using Code.Logic;
using Code.UI.Hud;
using UnityEngine;

namespace Code.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private IAssetProvider _assetProvider;
        
        public UIFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public GameObject CreateHud(IDamageable damageable)
        {
            PlayerHud hud = Object.Instantiate(_assetProvider.LoadPrefab<PlayerHud>(PrefabPaths.Hud));
            hud.PlayerLifeBar.Init(damageable);
            return hud.gameObject;
        }
    }
}