using Code.Infrastructure.Update;
using Code.Services;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Code.Logic.Tiles.UpAndDown
{
    public class UpAndDownTrap : Block, ITickable
    {
        [SerializeField] private float up;
        [SerializeField] private float down;
        [SerializeField] private float time;

        private float _timeTicking;

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

        public void Tick()
        {
            transform.position = Vector3.Lerp(
                new Vector3(transform.position.x, 
                    up,
                    transform.position.z), 
                new Vector3(transform.position.x, 
                    down,
                    transform.position.z),
                Mathf.PingPong(_timeTicking, time));
            _timeTicking += Time.deltaTime;
        }
    }
}