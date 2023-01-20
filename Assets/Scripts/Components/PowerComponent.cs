using System;
using UnityEngine;

namespace Components
{
    public class PowerComponent : MonoBehaviour
    {
        [SerializeField] private float _powerConsume;
        
        public static event EventHandler OnAnyPowerActiveChanged;

        public float PowerConsume => _powerConsume;
        
        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnAnyPowerActiveChanged?.Invoke(this,EventArgs.Empty);
            }
        }
    }
}