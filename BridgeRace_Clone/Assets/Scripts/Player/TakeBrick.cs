using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBrick : MonoBehaviour
{
    private int takenBrick;
    private Transform inventory;
    private void Start()
    {
        inventory = transform.GetChild(2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlueBrick"))
        {
            other.GetComponent<Brick>().SetMoveTarget(inventory, takenBrick);
            takenBrick++;
        }
    }
}
