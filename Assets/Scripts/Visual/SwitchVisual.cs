using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(SwitchComponent))]
    public class SwitchVisual : VisualComponent
    {
        [SerializeField] private Transform _switcherButton;
        [SerializeField] private Renderer _switcherIndicator;
        [SerializeField] private Material _switcherMatIndicatorOn;
        [SerializeField] private Material _switcherMatIndicatorOff;
        private SwitchComponent _switch;

        private void Start()
        {
            _switch = GetComponent<SwitchComponent>();
        }

        public override void UpdateVisual()
        {
            _switcherButton.localEulerAngles *= -1;
            _switcherIndicator.material = _switch.IsActive ? 
                _switcherMatIndicatorOn : 
                _switcherMatIndicatorOff;
        }
    }
}