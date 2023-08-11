using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime;
    [SerializeField] private Transform target;
    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(60, 0, 0), 2 * Time.deltaTime);
    }
}
