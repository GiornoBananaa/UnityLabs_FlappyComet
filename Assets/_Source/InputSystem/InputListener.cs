using CometSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private GameInputActions _gameInput;
        private CometMovement _cometMovement;
        private bool _liftComet;

        [Inject]
        public void Construct(CometMovement cometMovement)
        {
            _cometMovement = cometMovement;
        }

        private void Awake()
        {
            _gameInput = new GameInputActions();
            EnableInput();
        }

        private void FixedUpdate()
        {
            if (_liftComet)
                LiftComet();
        }


        private void OnDestroy()
        {
            DisableInput();
        }

        public void EnableInput()
        {
            _gameInput.GlobalActionMap.LiftComet.started += StartLiftingComet;
            _gameInput.GlobalActionMap.LiftComet.canceled += EndLiftingComet;
            _gameInput.Enable();
        }

        public void DisableInput()
        {
            _gameInput.GlobalActionMap.LiftComet.started -= StartLiftingComet;
            _gameInput.GlobalActionMap.LiftComet.canceled -= EndLiftingComet;
            _gameInput.Disable();
        }

        private void StartLiftingComet(InputAction.CallbackContext callbackContext)
        {
            _liftComet = true;
        }

        private void EndLiftingComet(InputAction.CallbackContext callbackContext)
        {
            _liftComet = false;
        }

        private void LiftComet()
        {
            _cometMovement.LiftComet();
        }
    }
}
