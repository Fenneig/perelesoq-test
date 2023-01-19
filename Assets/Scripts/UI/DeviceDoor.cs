using Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Visual;

namespace UI
{
    public class DeviceDoor : DeviceComponent
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _buttonText;

        public void Setup(string deviceName, DoorComponent doorComponent, DoorVisual doorVisual)
        {
            _name.text = deviceName;
            _button.onClick.AddListener(doorComponent.OnInteract);
            _button.onClick.AddListener(() => _status.text = doorVisual.IsOpen ? "OPEN" : "CLOSED");
            _button.onClick.AddListener(() => _buttonText.text = doorVisual.IsOpen ? "CLOSE" : "OPEN");
            _status.text = doorVisual.IsOpen ? "OPEN" : "CLOSED";
            _buttonText.text = doorVisual.IsOpen ? "CLOSE" : "OPEN";
        }

        private void OnDestroy() => _button.onClick.RemoveAllListeners();
    }
}