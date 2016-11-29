using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	
	public float m_Speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// 앞뒤로 움직이기
		float v = Input.GetAxis("Vertical");

		transform.position += v * transform.forward * m_Speed * Time.deltaTime;
	}
}
