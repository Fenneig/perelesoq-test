using Components;
using Unity.VisualScripting;
using UnityEngine;

namespace UI
{
    public class DeviceListComponent : MonoBehaviour
    {
        [SerializeField] private Transform _content;
        private Object[] _displayableList;
        private GameObject _deviceBlock;

        private void Start()
        {
            _displayableList = FindObjectsOfType(typeof(DisplayableComponent));
            foreach (var displayable in _displayableList)
            {
                var displayableComponent = displayable.GetComponent<DisplayableComponent>();
                if (displayableComponent.DeviceBlock == null) continue;
                var deviceBlock = Instantiate(displayableComponent.DeviceBlock, _content);
                displayableComponent.OnShow += deviceBlock.GetComponent<DeviceComponent>().DisplayableComponent_OnShow;
                displayableComponent.OnHide += deviceBlock.GetComponent<DeviceComponent>().DisplayableComponent_OnHide;
                deviceBlock.gameObject.SetActive(false);
            }
        }
    }
}
