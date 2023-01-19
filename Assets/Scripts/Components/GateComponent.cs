using UnityEngine;

namespace Components
{
    public abstract class GateComponent : DisplayableComponent
    {
        [SerializeField] protected DisplayableComponent _cameFromSecondNode;
        
        public override bool HasElectricity { get; }

        public bool FirstNodeElectricity => _cameFromNode.HasElectricity;
        public bool SecondNodeElectricity => _cameFromSecondNode.HasElectricity;
    }
}