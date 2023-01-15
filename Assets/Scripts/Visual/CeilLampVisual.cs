using UnityEngine;

namespace Visual
{
    public class CeilLampVisual : MonoBehaviour, IVisuable
    {
        [SerializeField] private Renderer _lightRenderer;
        [SerializeField] private Material _lightMaterialOn;
        [SerializeField] private Material _lightMaterialOff;
        [SerializeField] private bool _isLightOn;

        private void Start()
        {
            UpdateVisual();
        }

        [ContextMenu("update")]
        public void UpdateVisual()
        {
            _isLightOn = !_isLightOn;
            _lightRenderer.material = _isLightOn ? _lightMaterialOn : _lightMaterialOff;
        }
    }
}