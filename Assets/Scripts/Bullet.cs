using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public int DAMAGE_POWER = 10;
	public float Speed = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up * Speed * Time.deltaTime;
	}


	// 충돌이 일어나면 부딛힌 녀석 제거
	// 1. 충돌 이벤트 체크
	// 2. 부딛힌 녀석 제거
	// Unity 내부에서 물체가 충돌 했을 경우 자동으로 호출 됨.
	void OnTriggerEnter(Collider other)
	{
		//Destroy (other.gameObject);
		// 총알 제거
		//Destroy (gameObject); 
		gameObject.SetActive(false);
	}
}
