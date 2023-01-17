using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(GateComponent))]
    public class GateVisual : MonoBehaviour, IVisuable
    {
        private GateComponent _gate;

        private void Start()
        {
            _gate = GetComponent<GateComponent>();
        }

        public void UpdateVisual()
        {
        }
    }
}