using Components;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DeviceCamera : DeviceComponent
    {
        [SerializeField] private Button _button;

        public void Setup(string deviceName, CameraComponent cameraComponent)
        {
            _name.text = deviceName;
            _status.text = "";
            _button.onClick.AddListener(cameraComponent.OnSelectCamera);
        }

        private void OnDestroy() => _button.onClick.RemoveAllListeners();
    }
}