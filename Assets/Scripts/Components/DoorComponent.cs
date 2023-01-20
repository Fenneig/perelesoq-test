using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    [RequireComponent(typeof(PowerComponent))]
    public class DoorComponent : DisplayableComponent
    {
        private PowerComponent _power;
        public override bool HasElectricity => _cameFromNode.HasElectricity;
        
        public UnityAction OnInteract;

        #region MonoBehaviour

        private void Start()
        {
            _power = GetComponent<PowerComponent>();
            OnInteract += Interact;
        }

        private void OnDestroy() => OnInteract -= Interact;

        #endregion

        private void Interact()
        {
            if (HasElectricity) _visualComponent.UpdateVisual();
        }

        public void AnimationStart()
        {
            _power.IsActive = true;
        }

        public void AnimationEnd()
        {
            _power.IsActive = false;
        }
    }
}