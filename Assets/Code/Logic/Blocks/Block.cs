using UnityEngine;

namespace Code.Logic.Tiles
{
    public abstract class Block : MonoBehaviour
    {
        [SerializeField] private BlockType type;
        public BlockType Type => type;
    }
}