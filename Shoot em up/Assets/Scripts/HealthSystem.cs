using UnityEngine;

namespace JT 
{
	public class HealthSystem : MonoBehaviour
	{
		[SerializeField] private int _currentHealth;
		[SerializeField] private int maxHealth;

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

		private void Awake()
		{
			CurrentHealth = maxHealth;
		}

		public void TakeDamage(int amount)
		{
			CurrentHealth += -amount;
		}

		private void Die()
		{
			gameObject.SetActive(false);
		}
	}
}
