using System;
using TMPro;
using UnityEngine;

namespace Components
{
    public class SourceComponent : DisplayableComponent
    {
        [SerializeField] private TextMeshPro _displayText;
        [SerializeField] private float _maxPower;
        [SerializeField] private PowerComponent[] _connectedPowerComponents;
        private float _currentPower;

        public override bool HasElectricity => true;
        public float MaxPower => _maxPower;
        public float CurrentPower => _currentPower;
        public string Time { get; private set; }

        #region MonoBehaviour

        private void Start()
        {
            _cameFromNode = null;
            PowerComponent.OnAnyPowerActiveChanged += PowerComponent_OnAnyPowerActiveChanged;
        }

        private void Update()
        {
            Time = DateTime.Now.ToString().Split(" ")[1];
            _displayText.text = $"TIME: {Time}\r\nTOTAL: {_maxPower}\r\nCURRENT: {_currentPower}";
        }

        private void OnDestroy() => PowerComponent.OnAnyPowerActiveChanged -= PowerComponent_OnAnyPowerActiveChanged;

        #endregion

        private void PowerComponent_OnAnyPowerActiveChanged(object sender, EventArgs e) => UpdatePower();

        private void UpdatePower()
        {
            _currentPower = 0;
            foreach (var powerComponent in _connectedPowerComponents)
            {
                if (powerComponent.IsActive)
                    _currentPower += powerComponent.PowerConsume;
            }
        }
    }
}