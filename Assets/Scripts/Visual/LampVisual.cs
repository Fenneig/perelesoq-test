using System;
using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(LampComponent))]
    public class LampVisual : VisualComponent
    {
        [SerializeField] private GameObject[] _pointLight;
        private LampComponent _lamp;

        #region MonoBehaviour

        private void Start()
        {
            _lamp = GetComponent<LampComponent>();
            DisplayableComponent.OnAnyVisualUpdated += DisplayableComponent_OnAnyVisualUpdated;
        }

        private void OnDestroy() => DisplayableComponent.OnAnyVisualUpdated -= DisplayableComponent_OnAnyVisualUpdated;

        #endregion

        private void DisplayableComponent_OnAnyVisualUpdated(object sender, EventArgs e) => UpdateVisual();

        public override void UpdateVisual()
        {
            _lamp.UpdatePowerConsume();
            foreach (var pointLight in _pointLight)
                pointLight.SetActive(_lamp.HasElectricity);
        }
    }
}