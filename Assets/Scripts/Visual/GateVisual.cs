using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(GateComponent))]
    public class GateVisual : MonoBehaviour, IVisuable
    {
        [SerializeField] private Renderer _leftIncomeHook;
        [SerializeField] private Renderer _rightIncomeHook;
        [SerializeField] private Renderer _outcomeHook;
        [SerializeField] private Material _lightMaterialOn;
        [SerializeField] private Material _lightMaterialOff;

        private GateComponent _gate;
        
        private void Start()
        {
            _gate = GetComponent<GateComponent>();
            UpdateVisual();
        }

        [ContextMenu("update")]
        public void UpdateVisual()
        {
            _leftIncomeHook.material = _gate.LeftHookIsActive ? _lightMaterialOn : _lightMaterialOff;
            _rightIncomeHook.material = _gate.RightHookIsActive ? _lightMaterialOn : _lightMaterialOff;
            _outcomeHook.material = _gate.IsActive ? _lightMaterialOn : _lightMaterialOff;
        }
    }
}