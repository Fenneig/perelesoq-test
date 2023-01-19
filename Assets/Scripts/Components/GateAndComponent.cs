namespace Components
{
    public class GateAndComponent : GateComponent
    {
        public override bool HasElectricity => _cameFromNode.HasElectricity && _cameFromSecondNode.HasElectricity;
    }
}