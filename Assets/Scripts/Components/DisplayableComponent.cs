using System;
using UnityEngine;

namespace Components
{
    public abstract class DisplayableComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _deviceBlock;
        public GameObject DeviceBlock => _deviceBlock;
        
        public abstract bool IsActive { get; protected set; }

        public event EventHandler OnShow;
        public event EventHandler OnHide;

        public void Show()
        {
            OnShow?.Invoke(this, EventArgs.Empty);
        }

        public void Hide()
        {
            OnHide?.Invoke(this,EventArgs.Empty);
        }
    }
}