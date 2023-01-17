using UnityEngine.Events;

namespace Components
{
    public class DoorComponent : DisplayableComponent
    {
        public UnityAction OnInteract;
        public override bool IsActive { get; protected set; }

        private void Start()
        {
            OnInteract += Interact;
        }

        private void Interact()
        {
            IsActive = !IsActive;
            VisualComponent.UpdateVisual();
        }

        private void OnDestroy()
        {
            OnInteract -= Interact;
        }
    }
}