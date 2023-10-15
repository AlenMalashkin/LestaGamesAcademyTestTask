namespace Code.Logic.Traps.States
{
    public class DisabledState : DamageTrapState
    {
        private DamageTarp _damageTarp;
        
        public DisabledState(DamageTarp damageTrap)
        {
            _damageTarp = damageTrap;   
        }
        
        public override void Enter()
        {
            _damageTarp.MeshRenderer.material = _damageTarp.DefaultMaterial;
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
        }
    }
}