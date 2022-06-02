using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    public NavMeshAgent agent;

    void Start()
    {
        //agent.destination = goal.position;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, goal.position) < 3.0f)
        {
            Debug.Log("loaded");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
