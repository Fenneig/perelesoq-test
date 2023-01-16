﻿using System;
using UnityEngine;

namespace Components
{
    public abstract class DisplayableComponent : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject _deviceBlock;
        public GameObject DeviceBlock => _deviceBlock;
        
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

        public abstract void UpdateNodeInfo();
    }
}