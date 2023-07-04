using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.InputLayout
{
    public class SelectionManager : MonoBehaviour
    {
        [Inject]
        private StandartInputActions _inputActions;

        private InputAction _navigateAction;

        private void Awake()
        {
            _navigateAction = _inputActions.UI.Navigate;

            _navigateAction.performed += ctx => SelectFirstSelecteble();
        }

        private void OnEnable()
        {
            _navigateAction.Enable();
        }

        private void OnDisable()
        {
            _navigateAction.Disable();
        }

        private void SelectFirstSelecteble()
        {
            if(EventSystem.current.currentSelectedGameObject == null)
            {
                var selectble = FindObjectOfType<Selectable>(false);
                if(selectble != null)
                {
                    EventSystem.current.SetSelectedGameObject(selectble.gameObject);
                }
            }

        }
    }
}
