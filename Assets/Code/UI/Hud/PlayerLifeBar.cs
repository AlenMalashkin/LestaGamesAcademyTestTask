using System;
using Code.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Hud
{
    public class PlayerLifeBar : MonoBehaviour
    {
        [SerializeField] private Image filler;

        private IDamageable _damageable;

        public void Init(IDamageable damageable)
        {
            _damageable = damageable;
        }

        private void Start()
        {
            _damageable.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _damageable.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(int changedHealth)
        {
            filler.fillAmount = (float) changedHealth / _damageable.MaxHealth;
        }
    }
}