namespace Components
{
    public class LampComponent : DisplayableComponent
    {
        public override bool HasElectricity => _cameFromNode.HasElectricity;
    }
}