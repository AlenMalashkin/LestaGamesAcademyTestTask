using UnityEngine;

namespace Code.Infrastructure.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject LoadPrefab(string path)
            => (GameObject) Resources.Load(path);

        public T LoadPrefab<T>(string path) where T : Object
            => Resources.Load<T>(path);

        public GameObject[] LoadPrefabs(string path)
            => (GameObject[]) Resources.LoadAll(path);

        public T[] LoadPrefabs<T>(string path) where T : Object
            => Resources.LoadAll<T>(path);
    }
}