using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(LampComponent))]
    public class CeilLampVisual : MonoBehaviour, IVisuable
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
        public void UpdateVisual()
        {
            _lightRenderer.material = _lamp.IsActive ? _lightMaterialOn : _lightMaterialOff;
        }
    }
}