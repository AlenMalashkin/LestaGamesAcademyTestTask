using System.Numerics;
using Code.Infrastructure.Update;
using Code.Logic.Tiles;
using Code.Services;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Code.Logic.Traps
{
    public class WindTrap : Block, ITickable
    {
        [SerializeField] private float windStrength;
        [SerializeField] private float timeToChangeDirection;
        [SerializeField] private Vector3[] directions;

        private CharacterController _windTarget;
        private Vector3 _windDirection;
        private float _changeDirectionCooldown;
        
        private IUpdater _updater;

        private void Awake()
        {
            _updater = ServiceLocator.Container.Resolve<IUpdater>();
        }

        private void OnEnable()
        {
            _updater.AddTickable(this);
        }

        private void OnDisable()
        {
            _updater.RemoveTickable(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterController player))
            {
                _windTarget = player;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out CharacterController player))
            {
                _windTarget = null;
            }
        }


        public void Tick()
        {
            if (_windTarget)
                _windTarget.Move(_windDirection * windStrength * Time.deltaTime);
            
            CountCooldown();
            
            ChangeWindDirection();
        }

        private void ChangeWindDirection()
        {
            if (IsCooldownUp())
            {
                _changeDirectionCooldown = timeToChangeDirection;

                _windDirection = directions[Random.Range(0, directions.Length)];
            }
        }

        private void CountCooldown()
            => _changeDirectionCooldown -= Time.deltaTime;

        private bool IsCooldownUp()
            => _changeDirectionCooldown <= 0;
    }
}