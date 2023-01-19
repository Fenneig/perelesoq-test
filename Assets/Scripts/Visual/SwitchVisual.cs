using System;
using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(SwitchComponent))]
    public class SwitchVisual : VisualComponent
    {
        [SerializeField] private Transform _switcherButton;
        [SerializeField] private Renderer _switcherIndicator;
        [SerializeField] private Material _switcherMatIndicatorOn;
        [SerializeField] private Material _switcherMatIndicatorOff;
        private SwitchComponent _switch;
        private bool _activeState;

        #region MonoBehaviour

        private void Start()
        {
            _switch = GetComponent<SwitchComponent>();
            _activeState = _switch.ActiveState;
            if (!_switch.HasElectricity) UpdateRotation();
            DisplayableComponent.OnAnyVisualUpdated += DisplayableComponent_OnAnyVisualUpdated;
        }

        private void OnDestroy() => DisplayableComponent.OnAnyVisualUpdated -= DisplayableComponent_OnAnyVisualUpdated;

        #endregion

        public override void UpdateVisual()
        {
            if (_switch.ActiveState != _activeState) UpdateRotation();
            UpdateIndicatorColor();
        }

        private void DisplayableComponent_OnAnyVisualUpdated(object sender, EventArgs e) => UpdateVisual();

        private void UpdateIndicatorColor()
        {
            _switcherIndicator.material = _switch.HasElectricity ? _switcherMatIndicatorOn : _switcherMatIndicatorOff;
        }

        private void UpdateRotation()
        {
            _activeState = !_activeState;
            _switcherButton.localEulerAngles *= -1;
        }
    }
}