using UnityEngine;

namespace Visual
{
    public class LampVisual : MonoBehaviour, IVisuable
    {
        [SerializeField] private GameObject[] _pointLight;
        
        [ContextMenu("update")]
        public void UpdateVisual()
        {
            foreach (var pointLight in _pointLight)
                pointLight.SetActive(!pointLight.activeSelf);
        }
    }
}