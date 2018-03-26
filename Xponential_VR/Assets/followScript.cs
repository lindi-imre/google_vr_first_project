using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour {

    private GameObject wayPoint;
    private Vector3 wayPointPos;
    private float speed = 0.6f;
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        wayPoint = GameObject.Find("Player");
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        //Here, the zombie's will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        transform.LookAt(player.transform);
        //transform.rotation(Vector3.RotateTowards(transform.position, wayPointPos, speed * Time.deltaTime));
    }
}
