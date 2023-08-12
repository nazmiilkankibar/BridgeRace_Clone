using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RedRival : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    private Transform targetBridge;
    [SerializeField] private string ownColor;

    public int targetTakeBrick;
    public List<GameObject> inventory = new List<GameObject>();
    public List<Transform> bricksOnFloor = new List<Transform>();
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetTargetBridge();
        targetTakeBrick = Random.Range(1, 5);
        Invoke("TakeToListBricks", 1);
    }
    private void TakeToListBricks()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("RedBrick").Length; i++)
        {
            bricksOnFloor.Add(GameObject.FindGameObjectsWithTag("RedBrick")[i].transform);
        }
    }
    private void Update()
    {
        if (targetTakeBrick > 0)
        {
            if (target == null)
            {
                target = GetClosestEnemy(bricksOnFloor);
            }
            else
            {
                Move();
            }
        }
        else
        {
            target = targetBridge;
            Move();
        }
    }
    private void Move()
    {
        agent.SetDestination(target.position);
    }
    private void SetTargetBridge()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Bridge").Length; i++)
        {
            if (GameObject.FindGameObjectsWithTag("Bridge")[i].GetComponent<Bridge>().ownColor == "")
            {
                targetBridge = GameObject.FindGameObjectsWithTag("Bridge")[i].transform;
                targetBridge.GetComponent<Bridge>().ownColor = ownColor;
            }
        }
    }
    private Transform GetClosestEnemy(List<Transform> bricks)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in bricks)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }
}
