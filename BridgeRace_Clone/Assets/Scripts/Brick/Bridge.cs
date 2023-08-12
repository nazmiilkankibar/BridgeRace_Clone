using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private float takeRate;
    private List<GameObject> bricks = new List<GameObject>();
    float z;
    float y;
    public BoxCollider stairEdge;
    private bool canTake;
    private void Start()
    {
        canTake = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<TakeBrick>().brickInventory.Count > 0 && canTake)
        {
            takeRate += Time.deltaTime;
            if (takeRate >= .1f)
            {
                GameObject brick = other.GetComponent<TakeBrick>().AssignBrickToBridge();
                for (int i = 0; i < bricks.Count; i++)
                {
                    z += .4f;
                    y += .2f;
                }
                stairEdge.center += new Vector3(0, 0, .2f);
                stairEdge.size -= new Vector3(0, 0, .4f);

                if (stairEdge.size.z < 0)
                {
                    canTake = false;
                    Destroy(stairEdge);
                }

                bricks.Add(brick);
                Vector3 movePosition = new Vector3(0, y, z);
                brick.GetComponent<Brick>().MoveToBridge(transform, movePosition);
                takeRate = 0;
                z = 0;
                y = 0;
            }
        }
    }
}
