using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(NodeComponent))]
    public class BridgeComponent : DisplayableComponent
    {
        [SerializeField] private NodeComponent _incomeNode;
        [SerializeField] private NodeComponent[] _outcomeNodes;
        private NodeComponent _node;
        public bool IsActive => _incomeNode.HasElectricity;

        private void Start()
        {
            _node = GetComponent<NodeComponent>();
        }

        public override void UpdateNodeInfo()
        {
            _node.Capacity = 0;
            _node.HasElectricity = false;

            if (!IsActive) return;

            foreach (var outcomeNode in _outcomeNodes)
            {
                outcomeNode.GetComponent<DisplayableComponent>()?.UpdateNodeInfo();
                _node.Capacity = outcomeNode.Capacity;
            }

            _node.HasElectricity = true;
        }
    }
}