namespace Components
{
    public class GateOrComponent : GateComponent
    {
        public override bool HasElectricity => _cameFromNode.HasElectricity || _cameFromSecondNode.HasElectricity;
    }
}