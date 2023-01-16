using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(BridgeComponent))]
    public class BridgeVisual : MonoBehaviour, IVisuable
    {
        [SerializeField] private Renderer _switcherIndicator;
        [SerializeField] private Material _switcherMatIndicatorOn;
        [SerializeField] private Material _switcherMatIndicatorOff;
        
        private BridgeComponent _bridge;

        private void Start()
        {
            _bridge = GetComponent<BridgeComponent>();
            UpdateVisual();
        }

        [ContextMenu("update")]
        public void UpdateVisual()
        {
            _switcherIndicator.material = _bridge.IsActive ? 
                                          _switcherMatIndicatorOn : 
                                          _switcherMatIndicatorOff;
        }
    }
}