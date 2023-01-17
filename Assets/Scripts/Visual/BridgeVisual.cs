using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(BridgeComponent))]
    public class BridgeVisual : VisualComponent
    {
        [SerializeField] private Renderer _bridgeIndicator;
        [SerializeField] private Material _matIndicatorOn;
        [SerializeField] private Material _matIndicatorOff;
        private BridgeComponent _bridge;

        private void Start()
        {
            _bridge = GetComponent<BridgeComponent>();
        }

        public override void UpdateVisual()
        {
            _bridgeIndicator.material = _bridge.IsActive ? _matIndicatorOn : _matIndicatorOff;
        }
    }
}