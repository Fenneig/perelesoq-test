using UnityEngine.Events;

namespace Components
{
    public class SwitchComponent : DisplayableComponent
    {
        public UnityAction<bool> OnActiveChanged;
        public override bool IsActive { get; protected set; }

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