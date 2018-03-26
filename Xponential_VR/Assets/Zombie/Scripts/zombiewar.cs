using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombiewar : MonoBehaviour {

    public GameObject[] zombies = new GameObject[4];
    float m_Speed;
    public Transform myPoint;
    CharacterController zombieController;

    // Use this for initialization
    void Start () {
        /*for (int i = 0; i < 4; i++)
        {
            zombies[i] = GameObject.Find("Zombie" + (i + 1));
        }
        m_Speed = 0.6f;
        myPoint = GameObject.FindWithTag("Player").transform;*/


    }
	
	// Update is called once per frame
	void Update () {
        /*for (int i = 0; i < 4; i++)
        {
            NavMeshAgent agent = zombies[i].GetComponent<NavMeshAgent>();
            agent.destination = myPoint.position;

            
        }*/
        //zombieController = zombies[0].GetComponent<CharacterController>();
        
        //zombieController.SimpleMove(Vector3.forward);

    }
}
