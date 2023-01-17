using Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DeviceDoor : DeviceComponent
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _buttonText;
        
        public void Setup(string deviceName, DoorComponent doorComponent)
        {
            _name.text = deviceName;
            _button.onClick.AddListener(doorComponent.OnInteract);
            _button.onClick.AddListener(() => _status.text = doorComponent.IsActive ? "OPEN" : "CLOSED");
            _button.onClick.AddListener(() => _buttonText.text = doorComponent.IsActive ? "CLOSE" : "OPEN");
            _status.text = doorComponent.IsActive ? "OPEN" : "CLOSED";
            _buttonText.text = doorComponent.IsActive ? "CLOSE" : "OPEN";
        }
    }
}