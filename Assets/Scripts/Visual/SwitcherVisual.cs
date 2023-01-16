using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(SwitchComponent))]
    public class SwitcherVisual : MonoBehaviour, IVisuable
    {
        [SerializeField] private Transform _switcherButton;
        [SerializeField] private Renderer _switcherIndicator;
        [SerializeField] private Material _switcherMatIndicatorOn;
        [SerializeField] private Material _switcherMatIndicatorOff;
        
        private SwitchComponent _switchComponent;

        private void Start()
        {
            _switchComponent = GetComponent<SwitchComponent>();
            UpdateVisual();
        }

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