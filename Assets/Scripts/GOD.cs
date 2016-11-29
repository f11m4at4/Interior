using UnityEngine;
using System.Collections;

// 1. Enemy 를 만들어 준다.
//	- 일정 시간이 경과 하면 enemy 생성
//		- 일정 시간이 몇초인지 정할 변수 필요 --> 생성시간 이라 명명
//		- 시간 얼마나 흘렀는지 체크하자
//	- enemy 위치는 GOD 위치로 설정
public class GOD : MonoBehaviour {
	public GameObject prefabEnemy;

	public int MAX_POOL = 10;
	GameObject []enemyPool;

	public float MIN_TIME = 1;
	public float MAX_TIME = 4;

	float createTime = 2.0f;
	float currentTime = 0;
	// Use this for initialization
	void Start () {
		createTime = Random.Range (MIN_TIME, MAX_TIME);

		enemyPool = new GameObject[MAX_POOL];
		for (int i = 0; i < MAX_POOL; i++) {
			enemyPool [i] = Instantiate (prefabEnemy);
			enemyPool [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// 흘러간 시간 누적
		currentTime += Time.deltaTime;
		//시간 얼마나 흘렀는지 체크하자
		if (currentTime > createTime) {
			currentTime = 0;
			createTime = Random.Range (MIN_TIME, MAX_TIME);

			for (int i = 0; i < MAX_POOL; i++) {
				if (enemyPool [i].activeSelf == false) {
					enemyPool [i].SetActive (true);
					enemyPool [i].transform.position = transform.position;
					break;
				}

			}

			//Enemy 를 만들어 준다.
			//GameObject enemy = Instantiate(prefabEnemy);
			//enemy 위치는 GOD 위치로 설정
			//enemy.transform.position = transform.position;
		}
	}
}
