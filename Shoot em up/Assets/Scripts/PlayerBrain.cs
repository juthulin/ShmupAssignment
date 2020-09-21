using UnityEngine;
using UnityEngine.InputSystem;

namespace JT 
{
	public class PlayerBrain : MonoBehaviour
	{
		private MainInput _controls;
		[SerializeField] private RigidbodyMovementController playerRigidbodyMovementController;
		[SerializeField] private ShootingBehaviour playerShootingBehaviour;
		[SerializeField] private RevolvingWeaponBehaviour playerRevolvingWeaponBehaviour;
		[SerializeField] private ShieldComponent playerShieldComponent;

		public static PlayerBrain Instance { get; private set; }
		
		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Destroy(gameObject);
			}
			else
			{
				Instance = this;
			}
			
			_controls = new MainInput();

			_controls.MainScene.Movement.performed += PlayerMovement;
			_controls.MainScene.Movement.canceled += PlayerMovement;
			_controls.MainScene.Shooting.performed += Shooting;
			_controls.MainScene.Shooting.canceled += Shooting;
			_controls.MainScene.MouseDeltaX.performed += MouseDeltaX;
			_controls.MainScene.MouseDeltaX.canceled += MouseDeltaX;
			_controls.MainScene.SwitchWeaponPositive.performed += SwitchWeaponPositive;
			_controls.MainScene.SwitchWeaponNegative.performed += SwitchWeaponNegative;
			_controls.MainScene.UseEquipment.performed += ActivateEquipment;

			_controls.Enable();
		}

		private void OnEnable()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void PlayerMovement(InputAction.CallbackContext context)
		{
			playerRigidbodyMovementController.MovementVector = context.ReadValue<Vector2>();
		}

		private void Shooting(InputAction.CallbackContext context)
		{
			playerShootingBehaviour.CheckToFireWeapon(context.ReadValueAsButton());
		}

		private void MouseDeltaX(InputAction.CallbackContext context)
		{
			playerRevolvingWeaponBehaviour.SetRevolvingSpeed(Mathf.Clamp(context.ReadValue<float>(), -1f, 1f));
		}

		private void SwitchWeaponPositive(InputAction.CallbackContext context)
		{
			playerShootingBehaviour.SwitchWeapon(true);
		}

		private void SwitchWeaponNegative(InputAction.CallbackContext context)
		{
			playerShootingBehaviour.SwitchWeapon(false);
		}

		private void ActivateEquipment(InputAction.CallbackContext context)
		{
			playerShieldComponent.ActivateShield();
		}
		
		public void OnDeath()
		{
			gameObject.SetActive(false);
		}

		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
