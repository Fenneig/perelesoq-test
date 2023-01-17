using System;
using UnityEngine;

namespace Input
{
    public class CameraInput : MonoBehaviour
    {
        [SerializeField] private float _rotateSpeed;
        private const float BottomBorder = 89f;
        private const float TopBorder = 40f;

        public static event EventHandler OnCameraMoved;

        void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles -= Vector3.up * _rotateSpeed * Time.deltaTime;
                OnCameraMoved?.Invoke(this, EventArgs.Empty);
            }
            if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles += Vector3.up * _rotateSpeed * Time.deltaTime;
                OnCameraMoved?.Invoke(this, EventArgs.Empty);
            }
            if (UnityEngine.Input.GetKey(KeyCode.W))
            {
                if (transform.eulerAngles.x > TopBorder)
                {
                    transform.eulerAngles -= Vector3.right * _rotateSpeed * Time.deltaTime;
                    OnCameraMoved?.Invoke(this, EventArgs.Empty);
                }

            }
            if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                if (transform.eulerAngles.x < BottomBorder)
                {
                    transform.eulerAngles += Vector3.right * _rotateSpeed * Time.deltaTime;
                    OnCameraMoved?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
