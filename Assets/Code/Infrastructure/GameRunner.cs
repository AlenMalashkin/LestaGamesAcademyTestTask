using UnityEngine;

namespace Code.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private Bootstrap bootstrapPrefab;

        private void Awake()
        {
            Bootstrap bootstrap = FindObjectOfType<Bootstrap>();

            if (bootstrap != null)
                return;
               
            Instantiate(bootstrapPrefab);
        }
    }
}