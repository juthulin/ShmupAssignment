using UnityEngine;
using UnityEngine.InputSystem;

namespace JT 
{
	public class PlayerBrain : MonoBehaviour
	{
		private MainInput _controls;
		[SerializeField] private RigidbodyMovementController rigidbodyMovementController;
		[SerializeField] private ShootingBehaviour shootingBehaviour;
		[SerializeField] private RevolvingWeaponBehaviour revolvingWeaponBehaviour;

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

			_controls.Enable();
		}

		private void OnEnable()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void PlayerMovement(InputAction.CallbackContext context)
		{
			rigidbodyMovementController.MovementVector = context.ReadValue<Vector2>();
		}

		private void Shooting(InputAction.CallbackContext context)
		{
			shootingBehaviour.CheckToFireWeapon(context.ReadValueAsButton());
		}

		private void MouseDeltaX(InputAction.CallbackContext context)
		{
			revolvingWeaponBehaviour.SetRevolvingSpeed(Mathf.Clamp(context.ReadValue<float>(), -1f, 1f));
		}

		private void SwitchWeaponPositive(InputAction.CallbackContext context)
		{
			shootingBehaviour.SwitchWeapon(true);
		}

		private void SwitchWeaponNegative(InputAction.CallbackContext context)
		{
			shootingBehaviour.SwitchWeapon(false);
		}

		private void OnDisable()
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
