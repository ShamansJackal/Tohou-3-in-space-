using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField]
        private TabGroup _tabGroup;

        [SerializeField]
        private Image _background;

        public void OnPointerExit(PointerEventData eventData)
        {
            _tabGroup.OnTabExit(this);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _tabGroup.OnTabEnter(this);
        }

        void Start()
        {
            _tabGroup.Subscribe(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _tabGroup.OnTabSelected(this);
        }
    }
}