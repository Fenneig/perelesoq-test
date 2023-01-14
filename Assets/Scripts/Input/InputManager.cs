using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private const float BottomBorder = 89f;
    private const float TopBorder = 40f;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= Vector3.up * _rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.up * _rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.eulerAngles.x > TopBorder)
                transform.eulerAngles -= Vector3.right * _rotateSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.eulerAngles.x < BottomBorder)
                transform.eulerAngles += Vector3.right * _rotateSpeed * Time.deltaTime;
        }
    }
}
