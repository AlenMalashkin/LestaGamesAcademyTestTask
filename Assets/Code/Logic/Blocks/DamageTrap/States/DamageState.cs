namespace Code.Logic.Traps.States
{
    public class DamageState : DamageTrapState
    {
        private DamageTarp _damageTarp;
        
        private float _timeToNextState;

        public DamageState(DamageTarp damageTarp)
        {
            _damageTarp = damageTarp;
        }
        
        public override void Enter()
        {
            _damageTarp.StartCount(0.5f);
            _damageTarp.MeshRenderer.material = _damageTarp.DamagingMaterial;
            _damageTarp.Damageable?.TakeDamage(_damageTarp.TrapDamage);
        }

        public override void Update()
        {
            if (_damageTarp.IsCooldownUp())
            {
                _damageTarp.ChangeState(typeof(ReloadState));
            }
        }

        public override void Exit()
        {
        }
    }
}