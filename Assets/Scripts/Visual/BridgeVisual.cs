using System;
using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(BridgeComponent))]
    public class BridgeVisual : VisualComponent
    {
        [SerializeField] private Renderer _bridgeIndicator;
        [SerializeField] private Material _matIndicatorOn;
        [SerializeField] private Material _matIndicatorOff;
        private BridgeComponent _bridge;

        #region MonoBehaviour

        private void Start()
        {
            _bridge = GetComponent<BridgeComponent>();
            DisplayableComponent.OnAnyVisualUpdated += DisplayableComponent_OnAnyVisualUpdated;
        }

        private void OnDestroy() => DisplayableComponent.OnAnyVisualUpdated -= DisplayableComponent_OnAnyVisualUpdated;

        #endregion

        private void DisplayableComponent_OnAnyVisualUpdated(object sender, EventArgs e) => UpdateVisual();

        public override void UpdateVisual()
        {
            _bridgeIndicator.material = _bridge.HasElectricity ? _matIndicatorOn : _matIndicatorOff;
        }
    }
}