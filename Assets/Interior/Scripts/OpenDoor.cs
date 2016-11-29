using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UGUI UI 전용 라이브러리

public class OpenDoor : MonoBehaviour {
	public GameObject text;
	public float DISTANCE = 1;
	Animator anim;

	Text msg;



	// 현재 문이 열려 있는지 기억 하기 위한 변수
	bool isOpen = false;

	// Use this for initialization
	void Start () {
		GameObject doorPivot = GameObject.Find ("DoorPivot");
		anim = doorPivot.GetComponent<Animator> ();
		msg = text.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (Camera.main.transform.position,
			          Camera.main.transform.forward); 
		RaycastHit hitinfo;
		bool isShowText = false;
		// Ray 쏜다.
		if (Physics.Raycast (ray, out hitinfo)) {
			if (hitinfo.transform.gameObject.layer == LayerMask.NameToLayer ("Door")) {
				// Text 띄우기
				// 1. Door 과 Player(FPS) 사이의 거리가 1M 이내 일때
				Vector3 distance = transform.position - hitinfo.transform.position;
				// 2. Text 띄우기
				if (distance.magnitude < DISTANCE) {
					isShowText = true;
				}
			}
		}
		// 보일 수 있는 조건에만 보여주기
		if (isShowText) {
			text.SetActive (true);
			//1. door 가 open 있다면
			if(isOpen)
			{
				// - c 키 눌르세요 text show
				msg.text = "문을 닫기위해 C 키를 눌러주세요";
				// 만약 O 키가 눌리면
				if (Input.GetButtonDown("Close")) {
					// 문을 닫고 싶다.
					anim.SetTrigger ("Close");
					// 닫기 상태로 전환
					isOpen = false;
				}
			}
			//2. door 가 close 있다면
			else
			{
				// - o 키 누르세요 text show
				msg.text = "문을 열기위해 O 키를 눌러주세요"; 
				// 만약 O 키가 눌리면
				if (Input.GetButtonDown("Open")) {
					// 문을 열고 싶다.
					print("문을 열어라~~");
					anim.SetTrigger ("Open");
					isOpen = true;
				}
			}



		} else {
			text.SetActive (false);
		}
	}
}
