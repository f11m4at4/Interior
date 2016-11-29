using UnityEngine;
using System.Collections;

// 1. Player 를 오른쪽으로 움직여보자
// 2. 사용자의 입력에 따라 상하좌우 로 움직이기
// 3. Player 는 탄창을 갖을 수 있다.
//	- Bullet 을 한번에 여러개를 미리 로드 해놓아야 한다. 
//	- 배열을 사용 (ObjectPool)
//	- 비활성화 되어 있는 녀석을 찾아서 활성화 시키기
//	- 위치 지정

// 4. 총쏠때 사운드 재생
//	- AudioSource component 가 필요
//	- 재생, 만약 재생이 되고 있는 중이면, Stop then Play

public class Player : MonoBehaviour {

	// 전역변수로 Bullet 변수를 만든다.
	// prefab -> 링크만 걸려 있다.
	public GameObject prefabBullet;

	// Bullet ObjectPool 만들기
	public int BULLET_POOL_SIZE = 20;
	GameObject []bulletPool;

	//AudioSource component 가 필요
	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = gameObject.GetComponent<AudioSource> ();

		// bullet pool 공간 할당
		bulletPool = new GameObject[BULLET_POOL_SIZE];

		// bulletpool 에 데이타(bullet GameObject) 삽입
		for (int i = 0; i < BULLET_POOL_SIZE; i++) {
			GameObject bullet = Instantiate (prefabBullet);

			//비활성화 시키자.
			bullet.SetActive(false);

			bulletPool [i] = bullet;
		}


	}
	
	// Update is called once per frame
	void Update () {
		// 2. 사용자의 입력에 따라 상하좌우 로 움직이기
		// 	- 사용자 입력 받아오기
		// h => -1 ~ +1 값이 된다.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		//	- Player 이동시키기
		Vector3 dir = h * Vector3.right + v * Vector3.up;
		transform.position += dir * 5 * Time.deltaTime;
		//transform.Translate(h * Vector3.right * 5 * Time.deltaTime);
		//transform.Translate(v * Vector3.up * 5 * Time.deltaTime);
		// Player 의 위치(Position) 을 오른쪽으로 매번 움직인다.


		// 사용자 입력을 받아서 총알을 발사
		// 1. 사용자 입력 처리 (mouse left or left ctrl 키)

		//	- 만약 mouse left 키나 left ctrl 키가 눌리면 2번 실행
		if (Input.GetButtonDown ("Fire1")) {
			audio.Stop ();
			audio.Play ();

			// 2. 총알 발사
			//	- 총알 만든다.
			// bullet Pool 을 반복하여 검색
			// 비활성화 되어 있는 녀석을 찾아내어 활성화 시키기
			for (int i = 0; i < BULLET_POOL_SIZE; i++) 
			{
				if (bulletPool [i].activeSelf == false) {
					GameObject bullet = bulletPool [i];
					bullet.SetActive (true);
					//	- 총알의 위치를 지정
					//	- Player 의 위치로 지정
					bullet.transform.position = transform.position;
					// 회전 초기화
					break;
				}
			}
		}




	}
}
