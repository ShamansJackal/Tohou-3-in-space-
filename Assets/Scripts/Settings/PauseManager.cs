using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Zenject;

public class PauseManager : MonoBehaviour
{
    [Inject]
    private StandartInputActions _inputActions;

    public UnityEvent _onPause;
    public UnityEvent _onUnpause;

    private InputAction _pauseAction;
    private InputAction _unpauseAction;
    private bool _isPaused;
    // Start is called before the first frame update
    void Awake()
    {
        _pauseAction = _inputActions.Player.Pause;
        _unpauseAction = _inputActions.UI.Back;

        _pauseAction.performed += ctx => Pause();
        _unpauseAction.performed += ctx => FindObjectOfType<BackButton>(false).Press(); //TODO
    }

    private void OnEnable()
    {
        _pauseAction.Enable();
    }

    private void OnDisable()
    {
        _pauseAction.Disable();
        _unpauseAction.Disable();
    }

    public void Pause()
    {
        if (_isPaused) return;

        _unpauseAction.Enable();
        _inputActions.Player.Disable();

        _isPaused = true;
        Time.timeScale = 0;
        _onPause.Invoke();
    }

    public void Unpause()
    {
        if (!_isPaused) return;

        _inputActions.Player.Enable();
        _unpauseAction.Disable();

        _isPaused = false;
        Time.timeScale = 1;
        _onUnpause.Invoke();
    }
}
