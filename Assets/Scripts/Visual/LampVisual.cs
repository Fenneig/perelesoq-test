﻿using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(LampComponent))]
    public class LampVisual : VisualComponent
    {
        [SerializeField] private GameObject[] _pointLight;
        private LampComponent _lamp;

        private void Start()
        {
            _lamp = GetComponent<LampComponent>();
        }

        [ContextMenu("update")]
        public override void UpdateVisual()
        {
            foreach (var pointLight in _pointLight)
                pointLight.SetActive(_lamp.IsActive);
        }
    }
}