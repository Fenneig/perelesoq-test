namespace Components
{
    public class GateOrComponent : GateComponent
    {
        public override bool IsActive => _leftIncomeNode.HasElectricity || _rightIncomeNode.HasElectricity;

        public override void UpdateNodeInfo()
        {
            Node.Capacity = 0;
            Node.HasElectricity = false;

            if (!IsActive) return;
            
            _outcomeNode.GetComponent<DisplayableComponent>()?.UpdateNodeInfo();

            if (_leftIncomeNode.HasElectricity && _rightIncomeNode.HasElectricity)
                Node.Capacity = _outcomeNode.Capacity / 2f;
            else
                Node.Capacity = _outcomeNode.Capacity;

            Node.HasElectricity = true;
        }
    }
}