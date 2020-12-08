using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent nm;
    public Transform target;
    public float distanceThreshold = 10f;
    public enum AIState { idle, chasing};
    public AIState aiState = AIState.idle;

    // Start is called before the first frame update
    void Start()
    {
        nm = GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(Move());
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    IEnumerator Move()
    {

        
        
        while (true)
        {
            switch (aiState)
            {
                case AIState.idle:
                    float dist = Vector3.Distance(target.position, transform.position);
                    if(dist < distanceThreshold)
                    {
                        aiState = AIState.chasing;
                    }
                    nm.SetDestination(transform.position);
                    break;
                case AIState.chasing:
                    dist = Vector3.Distance(target.position, transform.position);
                    if(dist > distanceThreshold)
                    {
                        aiState = AIState.idle;
                    }
                    nm.SetDestination(target.position);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(2);
        }
    }
}
