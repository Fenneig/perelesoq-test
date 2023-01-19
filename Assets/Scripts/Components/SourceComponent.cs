using UnityEngine;

namespace Components
{
    public class SourceComponent : DisplayableComponent
    {
        [SerializeField] private float _maxPower;
        private float _currentPower;

        public override bool HasElectricity => true;

        private void Start() => _cameFromNode = null;

        public void ChangePower(float amount)
        {
            _currentPower += amount;
            if (_currentPower < 0) _currentPower = 0;
        }
    }
}