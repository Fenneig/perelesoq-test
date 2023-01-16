using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(NodeComponent))]
    public class SourceComponent : MonoBehaviour
    {
        [Header("nodes")] 
        [SerializeField] private NodeComponent[] _outcomeNodes;
        public NodeComponent SourceNodeComponent { get; private set; }

        private void Start()
        {
            SourceNodeComponent = GetComponent<NodeComponent>();
            SourceNodeComponent.HasElectricity = true;
        }

        [ContextMenu("UpdateInfo")]
        public void UpdateNodeInfo()
        {
            SourceNodeComponent.Capacity = 0;
            foreach (var outcomeNode in _outcomeNodes)
            {
                outcomeNode.GetComponent<DisplayableComponent>()?.UpdateNodeInfo();
                SourceNodeComponent.Capacity += outcomeNode.Capacity;
            }

            Debug.Log($"capacity = {SourceNodeComponent.Capacity}");
        }
        
        
    }
}