using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(LampComponent))]
    public class LampVisual : MonoBehaviour, IVisuable
    {
        [SerializeField] private GameObject[] _pointLight;
        
        private LampComponent _lampComponent;

        private void Start()
        {
            _lampComponent = GetComponent<LampComponent>();
            UpdateVisual();
        }

        [ContextMenu("update")]
        public void UpdateVisual()
        {
            foreach (var pointLight in _pointLight)
                pointLight.SetActive(_lampComponent.IsActive);
        }
    }
}