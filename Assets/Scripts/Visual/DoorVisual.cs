using System.Collections;
using Components;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(DoorComponent))]
    public class DoorVisual : MonoBehaviour, IVisuable
    {
        [SerializeField] private float _timeToOpen = 5f;
        [SerializeField] private Transform _pivot;
        
        private bool _isOpen;
        private float _startPosition = 0f;
        private float _endPosition = -90f;

        private DoorComponent _door;

        private void Start()
        {
            _door = GetComponent<DoorComponent>();
        }

        [ContextMenu("update")]
        public void UpdateVisual()
        {
            if (_isOpen == _door.IsActive) return;
            _isOpen = _door.IsActive;
            StartCoroutine(OpenDoor());
        }

        private IEnumerator OpenDoor()
        {
            float timePassed = 0f;

            while (timePassed < _timeToOpen)
            {
                timePassed += Time.deltaTime;
                float progress = timePassed / _timeToOpen;
                var value = _isOpen
                    ? Mathf.Lerp(_startPosition, _endPosition, progress)
                    : Mathf.Lerp(_endPosition, _startPosition, progress);
                _pivot.localEulerAngles = Vector3.up * value;
                Debug.Log(value);
                yield return null;
            }
        }
    }
}