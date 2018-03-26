using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieCollision : MonoBehaviour {

    public Animation animation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Zombie1")
        {
            Debug.Log("collision");
            animation = col.gameObject.GetComponent<Animation>();
            animation.Play("Zombie_Walk_01");
            
        }
    }
}
