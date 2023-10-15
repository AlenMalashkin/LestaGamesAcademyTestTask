using UnityEngine;

namespace Code.Logic
{
    public class DeathZoneTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damageable.MaxHealth);
            }
        }
    }
}