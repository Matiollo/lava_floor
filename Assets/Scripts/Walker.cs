using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walker : MonoBehaviour
{
    public float minWalkDuration = 1.0f;
    public float maxWalkDuration = 5.0f;
    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartNewWalk();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            StartNewWalk();
        }
    }

    void StartNewWalk()
    {
        Vector3 target;
        target.x = Random.Range(-20, 20);
        target.y = 0.5f;
        target.z = Random.Range(-20, 20);

        agent.SetDestination(target);

        timer = Random.Range(minWalkDuration, maxWalkDuration);
    }
}
