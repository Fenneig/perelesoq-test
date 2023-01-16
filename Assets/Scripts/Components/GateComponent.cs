using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(NodeComponent))]
    public abstract class GateComponent : DisplayableComponent
    {
        [SerializeField] protected NodeComponent _leftIncomeNode;
        [SerializeField] protected NodeComponent _rightIncomeNode;
        [SerializeField] protected NodeComponent _outcomeNode;
        protected NodeComponent Node;

        private void Start()
        {
            Node = GetComponent<NodeComponent>();
        }

        public abstract bool IsActive { get; }
        public bool LeftHookIsActive => _leftIncomeNode.HasElectricity;
        public bool RightHookIsActive => _rightIncomeNode.HasElectricity;

    }
}