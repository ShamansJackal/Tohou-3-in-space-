using Assets.Scripts.CharacterSystem;
using Assets.Scripts.InputLayout;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [Inject]
    private StandartInputActions _inputActions;

    private InputAction _movementActions;
    private InputAction _fireAction;

    public PlayerCharacter player;

    private void Awake()
    {
        _movementActions = _inputActions.Player.Move;
        _fireAction = _inputActions.Player.Fire;

        _fireAction.performed += ctx => player.weapon.MainFire.Press();
        //_fireAction.performed += ctx => print("sda");
        _fireAction.canceled += ctx => player.weapon.MainFire.Release();
        //_fireAction.canceled += ctx => print("res");
    }

    private void OnEnable()
    {
        _movementActions.Enable();
        _fireAction.Enable();
    }

    private void OnDisable()
    {
        _movementActions.Disable();
        _fireAction.Disable();
    }

    private void Update()
    {
        Vector2 deltaV = _movementActions.ReadValue<Vector2>();
        player.movementStrategy.Move(deltaV * Time.deltaTime);
    }
}
