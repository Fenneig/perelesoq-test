using System;
using Components;

namespace UI
{
    public class DeviceGate : DeviceComponent
    {
        private GateComponent _gateComponent;

        public void Setup(string deviceName, GateComponent gateComponent)
        {
            _name.text = deviceName;
            _gateComponent = gateComponent;
            DisplayableComponent.OnAnyVisualUpdated += DisplayableComponent_OnAnyVisualUpdated;
        }

        private void OnDestroy() => DisplayableComponent.OnAnyVisualUpdated -= DisplayableComponent_OnAnyVisualUpdated;

        private void DisplayableComponent_OnAnyVisualUpdated(object sender, EventArgs e) =>
            _status.text = _gateComponent.HasElectricity ? "open" : "close";
        
    }
}