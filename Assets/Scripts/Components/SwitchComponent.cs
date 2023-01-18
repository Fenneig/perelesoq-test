using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class SwitchComponent : DisplayableComponent
    {
        [SerializeField] private bool _isActive;
        public UnityAction<bool> OnActiveChanged;

        public override bool IsActive
        {
            get => _isActive; 
            protected set => _isActive = value;
        }

        private void Start()
        {
            OnActiveChanged += ActiveChange;
        }

        private void ActiveChange(bool isActive)
        {
            IsActive = isActive;
            VisualComponent.UpdateVisual();
        }

        private void OnDestroy()
        {
            OnActiveChanged -= ActiveChange;
        }
    }
}