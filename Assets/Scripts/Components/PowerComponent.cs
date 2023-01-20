using System;
using UnityEngine;

namespace Components
{
    public class PowerComponent : MonoBehaviour
    {
        [SerializeField] private float _powerConsume;
        private bool _isActive;

        public float PowerConsume => _powerConsume;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnAnyPowerActiveChanged?.Invoke(this,EventArgs.Empty);
            }
        }
        
        public static event EventHandler OnAnyPowerActiveChanged;
    }
}