namespace Code.Logic.Traps.States
{
    public class ReloadState : DamageTrapState
    {
        private DamageTarp _damageTarp;

        public ReloadState(DamageTarp damageTarp)
        {
            _damageTarp = damageTarp;
        }

        public override void Enter()
        {
            _damageTarp.StartCount(_damageTarp.TimeToReload);
            _damageTarp.MeshRenderer.material = _damageTarp.DefaultMaterial;
        }

        public override void Update()
        {
            if (_damageTarp.IsCooldownUp())
            {
                _damageTarp.ChangeState(typeof(DisabledState));
            }
        }

        public override void Exit()
        {
        }
    }
}