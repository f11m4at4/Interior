using UnityEngine;
using System.Collections;

//1. 위에서 아래로 떨어지기
//2. Player 쪽으로 떨어지기
//	- 계속 따라다니지 않는다.
//3. Player 따라 다니기
//4. 총알쏘기
public class Enemy : MonoBehaviour {
	// 전역변수
	public float speed = 5.0f;
	public GameObject player;
	Vector3 target;

	public int MAX_HP = 3;
	int hp = 0;

	// Player 쪽으로 따라다니기
	// 1. Player 는 어디에 있는가?
	//	- Player 의 위치를 알아야.
	//	- Player 가 있는 방향 알아내기 (Vector)
	//		-> 방향을 구하는 공식은? target (vector) =  player - me
	//	- vector 크기를 1로 만들어 준다.
	// 2. vector 로 이동


	public GameObject prefabExplosion;

	// Use this for initialization

	// 활성화 될때 호출
	void OnEnable()
	{
		hp = MAX_HP;
	}

	void Start () {
		hp = MAX_HP;
		// Scene 에 올라가 있는 GameObject 찾기
		// 동적으로 GameObject 찾는 방법
		player = GameObject.Find("Player");


		// target vector 구하기 target = player - me
		target = player.transform.position - transform.position;
		target.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {
		// 아래로 떨어지기
		// position = position + vect3.up * -1
		transform.position += Vector3.up * -1 * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Player") {
			/*
			PlayerState.hp--;
			if (PlayerState.hp <= 0) {
				Destroy (other.gameObject);
			}*/
			// PlayerState 의 Get, Set 함수를 통해 제어

			//PlayerState ps = other.GetComponent<PlayerState> ();
			PlayerState.Instance.MyHp--;//  (PlayerState.Instance.GetHP () - 1);

			hp--;
		} else if (other.gameObject.name.Contains ("Bullet")) {
			Bullet bullet = other.gameObject.GetComponent<Bullet> ();

			hp -= bullet.DAMAGE_POWER;
		}

		if (hp <= 0) {
			//Destroy (gameObject);
			GameObject explosion = Instantiate(prefabExplosion);
			explosion.transform.position = transform.position;

			gameObject.SetActive(false);
		}
	} 
}
