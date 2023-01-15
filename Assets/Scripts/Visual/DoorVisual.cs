using System.Collections;
using UnityEngine;

namespace Visual
{
    public class DoorVisual : MonoBehaviour, IVisuable
    {
        [SerializeField] private float _timeToOpen = 5f;
        [SerializeField] private Transform _pivot;
        private bool _isOpen;
        private float _startPosition = 0f;
        private float _endPosition = -90f;

        [ContextMenu("update")]
        public void UpdateVisual()
        {
            _isOpen = !_isOpen;
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