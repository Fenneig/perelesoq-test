using System;
using UnityEngine;
using Visual;

namespace Components
{
    public abstract class DisplayableComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _deviceBlock;
        [SerializeField] protected VisualComponent _visualComponent;
        [SerializeField] protected DisplayableComponent _cameFromNode;
        
        public GameObject DeviceBlock => _deviceBlock;

        public abstract bool HasElectricity { get; }

        public static event EventHandler OnAnyVisualUpdated;
        public event EventHandler OnShow;
        public event EventHandler OnHide;

        public void Show() => OnShow?.Invoke(this, EventArgs.Empty);

        public void Hide() => OnHide?.Invoke(this, EventArgs.Empty);

        protected virtual void UpdateVisual() => OnAnyVisualUpdated?.Invoke(this, EventArgs.Empty);
    }
}