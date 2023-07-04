using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class OverlayPanel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _parent;

        private void OnEnable()
        {
            EventSystem.current.SetSelectedGameObject(null);
            if (_parent != null) _parent.SetActive(false);
        }

        private void OnDisable()
        {
            EventSystem.current.SetSelectedGameObject(null);
            if (_parent != null) _parent.SetActive(true);
        }
    }
}
