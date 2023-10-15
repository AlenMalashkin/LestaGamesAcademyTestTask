using System;
using System.Collections;
using UnityEngine;

namespace Code.Logic.PlayerLogic
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        public event Action<int> HealthChanged;
        
        [SerializeField] private int health;

        private int _health;
        
        public int MaxHealth
        {
            get => health;
            set => health = value;
        }
        public int CurrentHealth
        {
            get => _health;
            set => _health = value >= 0 ? value : 0;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            
            HealthChanged?.Invoke(CurrentHealth);
        }
    }
}