using Components;
using Unity.VisualScripting;
using UnityEngine;
using Visual;

namespace UI
{
    public class DeviceListComponent : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        private Object[] _displayableList;

        private void Start()
        {
            _displayableList = FindObjectsOfType(typeof(DisplayableComponent));
            foreach (var displayable in _displayableList)
            {
                var displayableComponent = displayable.GetComponent<DisplayableComponent>();
                if (displayableComponent == null || displayableComponent.DeviceBlock == null) continue;
                var deviceBlock = Instantiate(displayableComponent.DeviceBlock, _content);
                var device = deviceBlock.GetComponent<DeviceComponent>();
                SetupDevice(device, displayableComponent);
                displayableComponent.OnShow += device.DisplayableComponent_OnShow;
                displayableComponent.OnHide += device.DisplayableComponent_OnHide;
            }

            _displayableList = FindObjectsOfType(typeof(CameraComponent));
        }

        private void SetupDevice(DeviceComponent device, DisplayableComponent displayableComponent)
        {
            switch (device)
            {
                case DeviceGate:
                {
                    var deviceGate = device.GetComponent<DeviceGate>();
                    var gateComponent = displayableComponent.GetComponent<GateComponent>();
                    deviceGate.Setup(displayableComponent.gameObject.name, gateComponent);
                    device.HideBlock();
                    break;
                }
                case DeviceCamera:
                {
                    var deviceCamera = device.GetComponent<DeviceCamera>();
                    var cameraComponent = displayableComponent.GetComponent<CameraComponent>();
                    deviceCamera.Setup(displayableComponent.gameObject.name, cameraComponent);
                    break;
                }
                case DeviceLamp:
                {
                    var deviceLamp = device.GetComponent<DeviceLamp>();
                    var lampComponent = displayableComponent.GetComponent<LampComponent>();
                    deviceLamp.Setup(displayableComponent.gameObject.name, lampComponent);
                    device.HideBlock();
                    break;
                }
                case DeviceDoor:
                {
                    var deviceDoor = device.GetComponent<DeviceDoor>();
                    var doorVisualComponent = displayableComponent.GetComponent<DoorVisual>();
                    var doorComponent = displayableComponent.GetComponent<DoorComponent>();
                    deviceDoor.Setup(displayableComponent.gameObject.name, doorComponent, doorVisualComponent);
                    device.HideBlock();
                    break;
                }
                case DeviceSwitch:
                {
                    var deviceSwitch = device.GetComponent<DeviceSwitch>();
                    var switchComponent = displayableComponent.GetComponent<SwitchComponent>();
                    deviceSwitch.Setup(displayableComponent.gameObject.name, switchComponent);
                    device.HideBlock();
                    break;
                }
            }
        }
    }
}