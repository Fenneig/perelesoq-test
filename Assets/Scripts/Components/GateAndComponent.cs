namespace Components
{
    public class GateAndComponent : GateComponent
    {
        public override bool IsActive => _leftIncomeNode.HasElectricity && _rightIncomeNode.HasElectricity;
        
        public override void UpdateNodeInfo()
        {
            Node.Capacity = 0;
            Node.HasElectricity = false;

            if (!IsActive) return;
            
            _outcomeNode.GetComponent<DisplayableComponent>()?.UpdateNodeInfo();
            
            Node.Capacity = _outcomeNode.Capacity / 2;

            Node.HasElectricity = true;
        }
    }
}