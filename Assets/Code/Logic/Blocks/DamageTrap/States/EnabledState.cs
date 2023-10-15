namespace Code.Logic.Traps.States
{
    public class EnabledState : DamageTrapState
    {
        private DamageTarp _damageTarp;

        public EnabledState(DamageTarp damageTrap)
        {
            _damageTarp = damageTrap;
        }
        
        public override void Enter()
        {
            _damageTarp.StartCount(_damageTarp.TimeToDamage);
            _damageTarp.MeshRenderer.material = _damageTarp.PreparingMaterial;
        }

        public override void Update()
        {
            if (_damageTarp.IsCooldownUp())
            {
                _damageTarp.ChangeState(typeof(DamageState));
            }
        }

        public override void Exit()
        {
        }
    }
}