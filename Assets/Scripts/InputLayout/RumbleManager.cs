using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Zenject;

namespace Assets.Scripts.InputLayout
{
    public class RumbleManager : MonoBehaviour
    {
        [Inject]
        private PlayerInput _playerInput;

        private Gamepad _pad;
        private Coroutine _stopRumble;
        private bool _gamePadConnected;

        private void OnEnable()
        {
            _playerInput.onControlsChanged += DeviceChanged;
        }

        private void OnDisable()
        {
            _playerInput.onControlsChanged -= DeviceChanged;
        }

        public void RumblePulse(float lowFreq, float highFreq, float duration)
        {
            _pad = Gamepad.current;

            if(_pad != null && _gamePadConnected)
            {
                _pad.SetMotorSpeeds(lowFreq, highFreq);
                _stopRumble = StartCoroutine(StopRumble(duration, _pad));
            }
        }

        private IEnumerator StopRumble(float duration, Gamepad pad)
        {
            yield return new WaitForSeconds(duration);
            pad.SetMotorSpeeds(0f, 0f);
        }

        private void DeviceChanged(PlayerInput playerInput)
        {
            _gamePadConnected = playerInput.currentControlScheme == "Gamepad";
            if (!_gamePadConnected && _stopRumble != null) StopCoroutine(_stopRumble);

        }
    }
}
