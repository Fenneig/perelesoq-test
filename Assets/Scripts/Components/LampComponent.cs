using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(NodeComponent))]
    public class LampComponent : DisplayableComponent
    {
        [SerializeField] private int _capacity;
        [SerializeField] private NodeComponent _incomeNode;
        private NodeComponent _node;
        public bool IsActive => _incomeNode.HasElectricity;

        private void Start()
        {
            _node = GetComponent<NodeComponent>();
        }

        public override void UpdateNodeInfo()
        {
            _node.Capacity = 0;
            
            if (IsActive) _node.Capacity = _capacity;
        }
    }
}