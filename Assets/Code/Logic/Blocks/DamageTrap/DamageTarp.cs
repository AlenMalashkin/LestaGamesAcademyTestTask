using System;
using System.Collections.Generic;
using Code.Infrastructure.Update;
using Code.Logic.Tiles;
using Code.Logic.Traps.States;
using Code.Services;
using UnityEngine;

namespace Code.Logic.Traps
{
    public class DamageTarp : Block, ITickable
    {
        [SerializeField] private Material defaultMaterial;
        [SerializeField] private Material preparingMaterial;
        [SerializeField] private Material damagingMaterial;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private int trapDamage;
        [SerializeField] private float timeToDamage = 1;
        [SerializeField] private float timeToReload = 5;

        private Dictionary<Type, DamageTrapState> _states;
        private DamageTrapState _state;
        private IDamageable _damageable;
        private float _cooldown;

        private IUpdater _updater;
        
        public IDamageable Damageable => _damageable;
        public MeshRenderer MeshRenderer => meshRenderer;
        public Material DefaultMaterial => defaultMaterial;
        public Material PreparingMaterial => preparingMaterial;
        public Material DamagingMaterial => damagingMaterial;
        public int TrapDamage => trapDamage;
        public float TimeToDamage => timeToDamage;
        public float TimeToReload => timeToReload;

        private void Awake()
        {
            _updater = ServiceLocator.Container.Resolve<IUpdater>();
        }

        private void Start()
        {
            _states = new Dictionary<Type, DamageTrapState>
            {
                [typeof(DisabledState)] = new DisabledState(this),
                [typeof(EnabledState)] = new EnabledState(this),
                [typeof(DamageState)] = new DamageState(this),
                [typeof(ReloadState)] = new ReloadState(this)
            };

            _state = _states[typeof(DisabledState)];
            _state.Enter();
        }

        private void OnEnable()
        {
            _updater.AddTickable(this);
        }

        private void OnDisable()
        {
            _updater.RemoveTickable(this);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                _damageable = damageable;
                
                if (_state.GetType() == typeof(DisabledState))
                    ChangeState(typeof(EnabledState));
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable) && damageable == _damageable)
            {
                _damageable = null;
            }
        }

        public void Tick()
        {
            _state.Update();
            CountCooldown();
        }

        public void ChangeState(Type stateType)
        {
            _state?.Exit();
            _state = _states[stateType];
            _state.Enter();
        }

        public void StartCount(float cooldown)
            => _cooldown = cooldown;
        
        public bool IsCooldownUp()
            => _cooldown <= 0;

        private void CountCooldown()
            => _cooldown -= Time.deltaTime;
    }
}