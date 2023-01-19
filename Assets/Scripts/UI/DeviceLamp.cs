using System;
using Components;

namespace UI
{
    public class DeviceLamp : DeviceComponent
    {
        private LampComponent _lampComponent;

        public void Setup(string deviceName, LampComponent lampComponent)
        {
            _name.text = deviceName;
            _lampComponent = lampComponent;
            DisplayableComponent.OnAnyVisualUpdated += DisplayableComponent_OnAnyVisualUpdated;
        }

        private void OnDestroy() => DisplayableComponent.OnAnyVisualUpdated -= DisplayableComponent_OnAnyVisualUpdated;

        private void DisplayableComponent_OnAnyVisualUpdated(object sender, EventArgs e) =>
            _status.text = _lampComponent.HasElectricity ? "on" : "off";
    }
}