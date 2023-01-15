using Components;
using UnityEngine;

namespace Visual
{
    public class SwitcherVisual : MonoBehaviour, IVisuable
    {
        [SerializeField] private Transform _switcherButton;
        [SerializeField] private Renderer _switcherIndicator;
        [SerializeField] private SwitchComponent _switchComponent;
        [SerializeField] private Material _switcherMatIndicatorOn;
        [SerializeField] private Material _switcherMatIndicatorOff;

        [ContextMenu("update")]
        public void UpdateVisual()
        {
            _switcherButton.localEulerAngles *= -1;
            _switcherIndicator.material = _switchComponent.IsActive ? 
                _switcherMatIndicatorOn : 
                _switcherMatIndicatorOff;
        }
    }
}