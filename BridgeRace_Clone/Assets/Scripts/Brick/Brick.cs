using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool canMove;
    public Transform target;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private float height;
    private void Update()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + new Vector3(0, height * .2f, 0), speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, turnSpeed * Time.deltaTime);
        }
    }
    public void SetMoveTarget(Transform moveTarget, float targetHeight)
    {
        height = targetHeight;
        transform.parent = moveTarget;
        target = moveTarget;
        canMove = true;
    }
}
