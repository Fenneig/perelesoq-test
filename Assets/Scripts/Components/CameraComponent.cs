﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    public class CameraComponent : DisplayableComponent
    {
        [SerializeField] private Transform _lookAtAfterSelect;
        public override bool HasElectricity { get; } = false;

        public static event EventHandler OnCameraMoved;

        public UnityAction OnSelectCamera;

        private Camera _camera;
        
        private const float TopBorder = 40f;

        #region MonoBehaviour

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            OnSelectCamera += SelectCamera;
        }

        private void OnDestroy() => OnSelectCamera -= SelectCamera;

        #endregion

        private void SelectCamera()
        {
            _camera.transform.parent = transform;
            _camera.transform.localPosition = Vector3.zero;
            _camera.transform.LookAt(_lookAtAfterSelect);
            if (_camera.transform.eulerAngles.x < TopBorder)
                _camera.transform.eulerAngles -= Vector3.right * (_camera.transform.eulerAngles.x - TopBorder);
            OnCameraMoved?.Invoke(this, EventArgs.Empty);
        }
    }
}