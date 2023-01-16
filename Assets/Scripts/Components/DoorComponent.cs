using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(NodeComponent))]
    public class DoorComponent : DisplayableComponent
    {
        
        [SerializeField] private int _capacityPerUse;
        [SerializeField] private NodeComponent _incomeNode;
        private NodeComponent _node;
        public bool IsActive => _node.HasElectricity;

        private void Start()
        {
            _node = GetComponent<NodeComponent>();
        }

        public override void UpdateNodeInfo()
        {
            _node.Capacity = 0;      
            _node.HasElectricity = true;

            
            if (!_incomeNode.HasElectricity) return;
            
            _node.Capacity = _capacityPerUse;
            _node.HasElectricity = true;
        }
    }
}