using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DeviceComponent : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _name;
        [SerializeField] protected TextMeshProUGUI _status;
        
        public void DisplayableComponent_OnShow(object sender, EventArgs e) => ShowBlock();
        public void DisplayableComponent_OnHide(object sender, EventArgs e) => HideBlock();

        public void ShowBlock() => gameObject.SetActive(true);
        public void HideBlock() => gameObject.SetActive(false);
    }
}