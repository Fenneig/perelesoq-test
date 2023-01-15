using System;
using Components;
using Input;
using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(DisplayableComponent))]
    public class InCameraDetection : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        private Camera _camera;
        private DisplayableComponent _displayableComponent;

        private bool _isVisible;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            InputManager.OnCameraMoved += InputManager_OnCameraMoved;
            _displayableComponent = GetComponent<DisplayableComponent>();
        }

        private void InputManager_OnCameraMoved(object sender, EventArgs e) => UpdateDetection();

        private void UpdateDetection()
        {
            var bounds = _collider.bounds;
            var cameraFrustum = GeometryUtility.CalculateFrustumPlanes(_camera);
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
            {
                if (_isVisible) return;
                if (_displayableComponent != null)
                    _displayableComponent.Show();
                _isVisible = true;
            }
            else
            {
                if (!_isVisible) return;
                if (_displayableComponent != null)
                    _displayableComponent.Hide();
                _isVisible = false;
            }
        }

        private void OnDestroy()
        {
            InputManager.OnCameraMoved -= InputManager_OnCameraMoved;
        }
    }
}