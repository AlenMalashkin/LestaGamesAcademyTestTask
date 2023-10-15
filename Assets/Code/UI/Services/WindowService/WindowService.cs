using System;
using Code.Infrastructure.AssetProvider;
using Code.Infrastructure.Constants;
using Code.UI.Windows;
using Object = UnityEngine.Object;

namespace Code.UI.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private IAssetProvider _assetProvider;
        
        public WindowService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public WindowBase Open(WindowType type)
        {
            switch (type)
            {
                case WindowType.Lose:
                    return OpenLoseWindow();
                case WindowType.Win:
                    return OpenWinWindow();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private WindowBase OpenLoseWindow()
            => Object.Instantiate(
                _assetProvider.LoadPrefab<WindowBase>(PrefabPaths.LoseWindow));

        private WindowBase OpenWinWindow()
            => Object.Instantiate(
                _assetProvider.LoadPrefab<WindowBase>(PrefabPaths.WinWindow));
    }
}