using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class SwitchComponent : DisplayableComponent
    {
        [SerializeField] private bool _activeState;
        
        public bool ActiveState => _activeState;
        public override bool HasElectricity => _cameFromNode.HasElectricity && _activeState;

        public UnityAction<bool> OnActiveChanged;

        #region MonoBehaviour

        private void Start() => OnActiveChanged += ActiveChange;

        private void OnDestroy() => OnActiveChanged -= ActiveChange;

        #endregion

        private void ActiveChange(bool isActive)
        {
            _activeState = isActive;
            UpdateVisual();
        }

        protected override void UpdateVisual()
        {
            _visualComponent.UpdateVisual();
            base.UpdateVisual();
        }
    }
}