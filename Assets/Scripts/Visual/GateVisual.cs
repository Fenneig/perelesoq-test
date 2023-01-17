using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(GateComponent))]
    public class GateVisual : VisualComponent
    {
        private GateComponent _gate;

        private void Start()
        {
            _gate = GetComponent<GateComponent>();
        }

        public override void UpdateVisual()
        {
        }
    }
}