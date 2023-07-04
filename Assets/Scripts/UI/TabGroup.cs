using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TabGroup : MonoBehaviour
    {
        [SerializeField]
        private List<TabButton> _tabButtons;

        public void Subscribe(TabButton tabButton)
        {
            if (_tabButtons == null) _tabButtons = new List<TabButton>();

            _tabButtons.Add(tabButton);
        }

        public void OnTabEnter(TabButton tabButton)
        {

        }

        public void OnTabExit(TabButton tabButton)
        {

        }

        public void OnTabSelected(TabButton tabButton)
        {

        }
    }
}