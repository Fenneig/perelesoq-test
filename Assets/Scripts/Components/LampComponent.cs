using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(PowerComponent))]
    public class LampComponent : DisplayableComponent
    {
        private PowerComponent _power;

        public override bool HasElectricity => _cameFromNode.HasElectricity;

        private void Start()
        {
            _power = GetComponent<PowerComponent>();
        }

        public void UpdatePowerConsume() => _power.IsActive = HasElectricity;
    }
}