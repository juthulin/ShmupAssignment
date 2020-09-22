using UnityEngine;

namespace JT 
{
	public class RevolvingWeaponBehaviour : MonoBehaviour
	{
		[Header("Required Component")]
		[SerializeField] private Transform revolvingWeaponTransform;
		[Space]
		[SerializeField, Range(0.1f, 1f)] private float slowdownFactor = 0.5f;
		
		public float RevolvingSpeed { get; private set; }
		public bool Firing { get; set; } = false;
		
		private void Update()
		{
			if (RevolvingSpeed < -1f || RevolvingSpeed > 1f)
			{
				RevolvingSpeed -= RevolvingSpeed * slowdownFactor* Time.deltaTime;
			}
			revolvingWeaponTransform.Rotate(Vector3.forward, RevolvingSpeed * Time.deltaTime);
		}
		
		public void SetRevolvingSpeed(in float mouseDelta)
		{
			if (Firing)
			{
				RevolvingSpeed += -mouseDelta;
			}
		}
	}
}
