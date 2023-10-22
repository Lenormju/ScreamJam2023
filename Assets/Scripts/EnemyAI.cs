using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent _navmeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
        _navmeshAgent = GetComponent<NavMeshAgent>();
        _navmeshAgent.updateRotation = false;
        _navmeshAgent.updateUpAxis = false;
    }


    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        _navmeshAgent.destination = GameManager.player.transform.position;

        // Calculate rotation to player
        Vector3 to = GameManager.player.transform.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, to);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 180 * Time.deltaTime);
    }
}
