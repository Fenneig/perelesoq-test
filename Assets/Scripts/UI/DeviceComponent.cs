using System;
using UnityEngine;

namespace UI
{
    public class DeviceComponent : MonoBehaviour
    {
        public void DisplayableComponent_OnShow(object sender, EventArgs e) => ShowBlock();
        public void DisplayableComponent_OnHide(object sender, EventArgs e) => HideBlock();

        private void ShowBlock()
        {
            gameObject.SetActive(true);
        }

        private void HideBlock()
        {
            gameObject.SetActive(false);
        }
    }
}