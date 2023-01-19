using System.Collections;
using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(DoorComponent))]
    public class DoorVisual : VisualComponent
    {
        private const float START_POSITION = 0f;
        private const float END_POSITION = -90f;
        
        [SerializeField] private float _timeToOpen = 5f;
        [SerializeField] private Transform _pivot;
        
        public bool IsOpen { get; private set; }
        
        private DoorComponent _door;
        private bool _isAnimationInProgress;

        private void Start() => _door = GetComponent<DoorComponent>();

        public override void UpdateVisual()
        {
            if (!_door.HasElectricity || _isAnimationInProgress) return;
            _isAnimationInProgress = true;
            IsOpen = !IsOpen;
            StartCoroutine(OpenDoor());
        }

        private IEnumerator OpenDoor()
        {
            float timePassed = 0f;

            while (timePassed < _timeToOpen)
            {
                timePassed += Time.deltaTime;
                float progress = timePassed / _timeToOpen;
                var value = IsOpen
                    ? Mathf.Lerp(START_POSITION, END_POSITION, progress)
                    : Mathf.Lerp(END_POSITION, START_POSITION, progress);
                _pivot.localEulerAngles = Vector3.up * value;
                yield return null;
            }

            _isAnimationInProgress = false;
        }
    }
}