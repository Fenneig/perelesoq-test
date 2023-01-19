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
        [SerializeField] private LayerMask _wallLayer;
        private Camera _camera;
        private DisplayableComponent _displayableComponent;

        private bool _isVisible;
        private bool _isInitialized;

        #region MonoBehaviour

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            CameraInput.OnCameraMoved += CameraInput_OnCameraMoved;
            CameraComponent.OnCameraMoved += CameraComponent_OnCameraMoved;
            _displayableComponent = GetComponent<DisplayableComponent>();
        }

        private void LateUpdate()
        {
            if (_isInitialized) return;
            _isInitialized = true;
            UpdateDetection();
        }

        private void OnDestroy()
        {
            CameraInput.OnCameraMoved -= CameraInput_OnCameraMoved;
            CameraComponent.OnCameraMoved -= CameraComponent_OnCameraMoved;
        }

        #endregion

        private void CameraInput_OnCameraMoved(object sender, EventArgs e) => UpdateDetection();
        private void CameraComponent_OnCameraMoved(object sender, EventArgs e) => UpdateDetection();

        private void UpdateDetection()
        {
            Vector3 direction = (_camera.transform.position - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, _camera.transform.position);

            if (Physics.Raycast(transform.position, direction, distance, _wallLayer))
            {
                if (_displayableComponent != null) _displayableComponent.Hide();
                return;
            }

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
    }
}