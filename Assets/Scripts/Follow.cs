using UnityEngine;
using System.Collections;


// player 를 따다니게 하고 싶다.
public class Follow : MonoBehaviour {
	public GameObject player;
	public float speed = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//1. player 가기위한 방향을 구하자.
		//	- me ---> player = player - me
		Vector3 dir = player.transform.position - transform.position;
		dir.Normalize ();
		transform.position += dir * speed * Time.deltaTime;
	}
}
