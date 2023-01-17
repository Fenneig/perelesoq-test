using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(LampComponent))]
    public class CeilLampVisual : VisualComponent
    {
        [SerializeField] private Renderer _lightRenderer;
        [SerializeField] private Material _lightMaterialOn;
        [SerializeField] private Material _lightMaterialOff;
        private LampComponent _lamp;

        private void Start()
        {
            _lamp = GetComponent<LampComponent>();
            UpdateVisual();
        }

        [ContextMenu("update")]
        public override void UpdateVisual()
        {
            _lightRenderer.material = _lamp.IsActive ? _lightMaterialOn : _lightMaterialOff;
        }
    }
}