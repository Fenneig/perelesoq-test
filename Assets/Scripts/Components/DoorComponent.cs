using UnityEngine.Events;

namespace Components
{
    public class DoorComponent : DisplayableComponent
    {
        public override bool HasElectricity => _cameFromNode.HasElectricity;
        
        public UnityAction OnInteract;

        #region MonoBehaviour

        private void Start() => OnInteract += Interact;

        private void OnDestroy() => OnInteract -= Interact;

        #endregion

        private void Interact()
        {
            if (HasElectricity) _visualComponent.UpdateVisual();
        }
    }
}