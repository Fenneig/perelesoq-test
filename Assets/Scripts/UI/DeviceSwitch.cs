using Components;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DeviceSwitch : DeviceComponent
    {
        [SerializeField] private Toggle _toggle;

        public void Setup(string deviceName, SwitchComponent switchComponent)
        {
            _name.text = deviceName;
            _toggle.onValueChanged.AddListener(switchComponent.OnActiveChanged);
            _toggle.onValueChanged.AddListener(isActive => _status.text = isActive ? "on" : "off" );
        }
    }
}