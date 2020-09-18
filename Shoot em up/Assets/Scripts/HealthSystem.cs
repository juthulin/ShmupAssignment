using UnityEngine;
using UnityEngine.Events;

namespace JT 
{
	public class HealthSystem : MonoBehaviour
	{
		private int _currentHealth;
		[SerializeField] private int maxHealth;
		public UnityEvent deathEvent;

		public int CurrentHealth
		{
			get => _currentHealth;
			set
			{
				if (value >= maxHealth)
					_currentHealth = maxHealth;
				else if (value <= 0)
				{
					_currentHealth = 0;
					Die();
				}
				else
					_currentHealth = value;
			}
		}

		private void OnEnable()
		{
			CurrentHealth = maxHealth;
		}

		public void TakeDamage(int amount)
		{
			CurrentHealth += -amount;
		}

		private void Die()
		{
			deathEvent?.Invoke();
		}
	}
}
