using Code.Services;
using UnityEngine;

namespace Code.Infrastructure.AssetProvider
{
    public interface IAssetProvider : IService
    {
        GameObject LoadPrefab(string path);
        T LoadPrefab<T>(string path) where T : Object;
        GameObject[] LoadPrefabs(string path);
        T[] LoadPrefabs<T>(string path) where T : Object;
    }
}