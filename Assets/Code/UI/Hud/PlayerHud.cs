using UnityEngine;

namespace Code.UI.Hud
{
    public class PlayerHud : MonoBehaviour
    {
        [SerializeField] private PlayerLifeBar playerLifeBar;
        public PlayerLifeBar PlayerLifeBar => playerLifeBar;
    }
}