using System;
using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(LampComponent))]
    public class CeilLampVisual : VisualComponent
    {
        [SerializeField] private Renderer _lightRenderer;
        [SerializeField] private Material _lightMaterialOn;
        [SerializeField] private Material _lightMaterialOff;
        private LampComponent _lamp;

        #region MonoBehaviour

        private void Start()
        {
            _lamp = GetComponent<LampComponent>();
            UpdateVisual();
            DisplayableComponent.OnAnyVisualUpdated += DisplayableComponent_OnAnyVisualUpdated;
        }

        private void OnDestroy() => DisplayableComponent.OnAnyVisualUpdated -= DisplayableComponent_OnAnyVisualUpdated;

        #endregion

        private void DisplayableComponent_OnAnyVisualUpdated(object sender, EventArgs e) => UpdateVisual();

        public override void UpdateVisual()
        {
            _lightRenderer.material = _lamp.HasElectricity ? _lightMaterialOn : _lightMaterialOff;
        }
    }
}