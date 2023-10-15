using UnityEngine;

namespace Code.StaticData.PlayerStaticData
{
    [CreateAssetMenu(fileName = "PlayerStaticData", menuName = "Player Static Data", order = 0)]
    public class PlayerStaticData : ScriptableObject
    {
        [SerializeField] private float moveSpeed = 4.0f;
        [SerializeField] private float rotationSpeed = 1.0f;
        [SerializeField] private float speedChangeRate = 10.0f;
        [SerializeField] private float jumpHeight = 1.2f;
        [SerializeField] private float gravity = -15.0f;
        [SerializeField] private float jumpTimeout = 0.1f;
        [SerializeField] private float groundedOffset = -0.14f;
        [SerializeField] private float groundedRadius = 0.5f;
        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private float topClamp = 90.0f;
        [SerializeField] private float bottomClamp = -90.0f;

        public float MoveSpeed => moveSpeed;
        public float RotationSpeed => rotationSpeed;
        public float SpeedChangeRate => speedChangeRate;
        public float JumpHeight => jumpHeight;
        public float Gravity => gravity;
        public float JumpTimeout => jumpTimeout;
        public float GroundedOffset => groundedOffset;
        public float GroundedRadius => groundedRadius;
        public LayerMask GroundLayers => groundLayers;
        public float TopClamp => topClamp;
        public float BottomClamp => bottomClamp;
    }
}