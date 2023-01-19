using UnityEngine.Events;

namespace Components
{
    public class DoorComponent : DisplayableComponent
    {
        public UnityAction OnInteract;
        public override bool HasElectricity => _cameFromNode.HasElectricity;

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