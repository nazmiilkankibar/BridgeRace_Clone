using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool canMovePlayer;
    private bool canMoveBridge;
    public Transform target;
    private Vector3 offset;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private float height;
    private void Update()
    {
        if (canMovePlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + new Vector3(0, height * .2f, 0), speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, turnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position,target.position + new Vector3(0,height * .2f, 0)) < .01f)
            {
                canMovePlayer = false;
            }
        }
        if (canMoveBridge)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + offset, 10 *  speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, turnSpeed * Time.deltaTime);
        }
    }
    public void SetMoveTarget(Transform moveTarget, float targetHeight)
    {
        height = targetHeight;
        transform.parent = moveTarget;
        target = moveTarget;
        canMovePlayer = true;
        transform.tag = "Untagged";
    }
    public void MoveToBridge(Transform parent, Vector3 position)
    {
        transform.parent = parent;
        canMovePlayer = false;
        canMoveBridge = true;
        target = parent;
        offset = position;
        transform.tag = "Untagged";
    }
}
