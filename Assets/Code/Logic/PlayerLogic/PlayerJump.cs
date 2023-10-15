using Code.Services.InputService;
using Code.StaticData.PlayerStaticData;
using UnityEngine;

namespace Code.Logic.PlayerLogic
{
    public class PlayerJump : MonoBehaviour
    {
	    public float VerticalVelocity => _verticalVelocity;

	    [SerializeField] private PlayerStaticData playerStaticData;
	    [SerializeField] private int additionalJumpCount = 1;
	    
	    private IInputService _input;
	    private float _verticalVelocity;
	    private float _terminalVelocity = 53.0f;
	    private bool _grounded = true;
	    private float _jumpTimeoutDelta;
	    private int _additionalJumpCount;

	    private void OnDrawGizmosSelected()
	    {
		    Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
		    Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

		    if (_grounded) Gizmos.color = transparentGreen;
		    else Gizmos.color = transparentRed;

		    Gizmos.DrawSphere(new Vector3(transform.position.x,
			    transform.position.y - playerStaticData.GroundedOffset,
			    transform.position.z), 
			    playerStaticData.GroundedRadius);
	    }

	    public void Init(IInputService input)
	    {
		    _input = input;
	    }
	    
	    public void GroundedCheck(float groundedOffset, float groundedRadius, LayerMask groundLayers)
	    {
		    Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
		    _grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);
	    }
	    
	    public void JumpAndApplyGravity(float jumpHeight, float gravity, float jumpTimeout)
	    {
		    if (_grounded)
		    {
			    _additionalJumpCount = additionalJumpCount;

			    if (_verticalVelocity < 0.0f)
				    _verticalVelocity = -2f; 
			    
			    Jump(jumpTimeout, jumpHeight, gravity);
		    }
		    else
		    {
			    AdditionalJump(jumpTimeout, jumpHeight, gravity);
		    }

		    CountJumpTimeoutDelta();

		    ApplyGravity(gravity);
	    }

	    private void Jump(float jumpTimeout, float jumpHeight, float gravity)
	    {
		    if (_input.ReadJump() && _jumpTimeoutDelta <= 0.0f)
		    {
			    _jumpTimeoutDelta = jumpTimeout;
			    _verticalVelocity = Mathf.Sqrt(jumpHeight * -2 * gravity);
		    }
	    }

	    private void AdditionalJump(float jumpTimeout, float jumpHeight, float gravity)
	    {
		    if (_input.ReadJump() && _additionalJumpCount > 0 && _jumpTimeoutDelta <= 0.0f)
		    {
			    _additionalJumpCount -= 1;
			    Jump(jumpTimeout, jumpHeight, gravity);
		    }
	    }

	    private void ApplyGravity(float gravity)
	    {
		    if (_verticalVelocity < _terminalVelocity)
			    _verticalVelocity += gravity * Time.deltaTime; 
	    }

	    private void CountJumpTimeoutDelta()
	    {
		    if (_jumpTimeoutDelta >= 0.0f)
			    _jumpTimeoutDelta -= Time.deltaTime;
	    }
    }
}