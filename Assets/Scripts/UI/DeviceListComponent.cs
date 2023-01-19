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
                deviceBlock.gameObject.SetActive(false);
            }
        }

        private void SetupDevice(DeviceComponent device, DisplayableComponent displayableComponent)
        {
            switch (device)
            {
                case DeviceLamp:
                {
                    var deviceLamp = device.GetComponent<DeviceLamp>();
                    var lampVisualComponent = displayableComponent.GetComponent<LampComponent>();
                    deviceLamp.Setup(displayableComponent.gameObject.name, lampVisualComponent);
                    break;
                }
                case DeviceDoor:
                {
                    var deviceDoor = device.GetComponent<DeviceDoor>();
                    var doorVisualComponent = displayableComponent.GetComponent<DoorVisual>();
                    var doorComponent = displayableComponent.GetComponent<DoorComponent>();
                    deviceDoor.Setup(displayableComponent.gameObject.name, doorComponent, doorVisualComponent);
                    break;
                }
                case DeviceSwitch:
                {
                    var deviceSwitch = device.GetComponent<DeviceSwitch>();
                    var switchComponent = displayableComponent.GetComponent<SwitchComponent>();
                    deviceSwitch.Setup(displayableComponent.gameObject.name, switchComponent);
                    break;
                }
            }
        }
    }
}