using Components;
using TMPro;
using UnityEngine;

namespace Visual
{
    public class ScreenVisual : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private TextMeshProUGUI _maxPowerText;
        [SerializeField] private TextMeshProUGUI _currentPowerText;
        private SourceComponent _source;

        private void Start()
        {
            _source = FindObjectOfType<SourceComponent>();
        }

        private void Update()
        {
            if (_source == null) return;
            _timeText.text = _source.Time;
            _maxPowerText.text = $"TOTAL: {_source.MaxPower}W";
            _currentPowerText.text = $"CURRENT: {_source.CurrentPower}W";
        }
    }
}