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
        private bool _isInited;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            CameraInput.OnCameraMoved += CameraInput_OnCameraMoved;
            _displayableComponent = GetComponent<DisplayableComponent>();
        }

        private void CameraInput_OnCameraMoved(object sender, EventArgs e) => UpdateDetection();

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

        private void LateUpdate()
        {
            if (_isInited) return;
            _isInited = true;
            UpdateDetection();
        }

        private void OnDestroy()
        {
            CameraInput.OnCameraMoved -= CameraInput_OnCameraMoved;
        }
    }
}