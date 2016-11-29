using UnityEngine;
using System.Collections;


//1. 배경 이미지 스크롤 되도록 하기
//2. 필요사항
//	- Renderer 컴포넌트 찾기
//	- 재질을 알아와야 함.
//	- Material 의 offset 속성 값을 변경 (y)
public class BG : MonoBehaviour {
	MeshRenderer mr;
	Vector2 currentOffset;
	// Use this for initialization
	void Start () {
		//	- Renderer 컴포넌트 찾기
		mr = gameObject.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentOffset += Vector2.down * -0.1f * Time.deltaTime;
		//	- Material 의 offset 속성 값을 변경 (y)
		mr.material.SetTextureOffset("_MainTex", currentOffset);
	}
}
