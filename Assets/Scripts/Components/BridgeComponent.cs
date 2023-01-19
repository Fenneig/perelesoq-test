namespace Components
{
    public class BridgeComponent : DisplayableComponent
    {
        public override bool HasElectricity => _cameFromNode.HasElectricity;
    }
}