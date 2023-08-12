using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBrick : MonoBehaviour
{
    private int takenBrick;
    private Transform inventoryPosition;
    public List<GameObject> brickInventory = new List<GameObject>();
    private void Start()
    {
        inventoryPosition = transform.GetChild(2);
    }
    public GameObject AssignBrickToBridge()
    {
        GameObject brick = brickInventory[brickInventory.Count - 1];
        brickInventory.Remove(brick);
        return brick;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (transform.tag)
        {
            case "Player":
                if (other.CompareTag("BlueBrick"))
                {
                    other.GetComponent<Brick>().SetMoveTarget(inventoryPosition, brickInventory.Count);
                    brickInventory.Add(other.gameObject);
                    takenBrick++;
                    
                }
                break;
            case "Rival":
                if (other.CompareTag("RedBrick"))
                {
                    other.GetComponent<Brick>().SetMoveTarget(inventoryPosition, brickInventory.Count);
                    brickInventory.Add(other.gameObject);
                    RedRival redRival = transform.GetComponent<RedRival>();
                    redRival.bricksOnFloor.Remove(other.transform);
                    redRival.target = null;
                    redRival.targetTakeBrick--;
                    redRival.inventory.Add(other.gameObject);
                }
                break;
            default:
                break;
        }
        
    }
}
