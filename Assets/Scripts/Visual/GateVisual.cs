using System;
using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(GateComponent))]
    public class GateVisual : VisualComponent
    {
        [SerializeField] private Renderer _leftHookIndicator;
        [SerializeField] private Renderer _rightHookIndicator;
        [SerializeField] private Renderer _outcomeIndicator;
        [SerializeField] private Material _matIndicatorOn;
        [SerializeField] private Material _matIndicatorOff;

        private GateComponent _gate;

        #region MonoBehaviour

        private void Start()
        {
            _gate = GetComponent<GateComponent>();
            DisplayableComponent.OnAnyVisualUpdated += DisplayableComponent_OnAnyVisualUpdated;
        }

        private void OnDestroy() => DisplayableComponent.OnAnyVisualUpdated -= DisplayableComponent_OnAnyVisualUpdated;

        #endregion

        private void DisplayableComponent_OnAnyVisualUpdated(object sender, EventArgs e) => UpdateVisual();

        public override void UpdateVisual()
        {
            _leftHookIndicator.material = _gate.FirstNodeElectricity ? _matIndicatorOn : _matIndicatorOff;
            _rightHookIndicator.material = _gate.SecondNodeElectricity ? _matIndicatorOn : _matIndicatorOff;
            _outcomeIndicator.material = _gate.HasElectricity ? _matIndicatorOn : _matIndicatorOff;
        }
    }
}