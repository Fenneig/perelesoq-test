using System;
using Input;
using UnityEngine;

public class InCameraDetection : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    private Camera _camera;
    
    public bool IsInCamera { get; private set; }

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        InputManager.OnCameraMoved += InputManager_OnCameraMoved;
        UpdateDetection();
    }

    private void InputManager_OnCameraMoved(object sender, EventArgs e) => UpdateDetection();

    private void UpdateDetection()
    {
        var bounds = _collider.bounds;
        var cameraFrustum = GeometryUtility.CalculateFrustumPlanes(_camera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            if (IsInCamera) return;
            Debug.Log($"{gameObject.name} is in camera view");
            IsInCamera = true;
        }
        else
        {
            if (!IsInCamera) return;
            Debug.Log($"{gameObject.name} is not in camera view");
            IsInCamera = false;
        }
    }

    private void OnDestroy()
    {
        InputManager.OnCameraMoved -= InputManager_OnCameraMoved;
    }
}
