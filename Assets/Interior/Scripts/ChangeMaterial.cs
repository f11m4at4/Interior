using UnityEngine;
using System.Collections;

// 1. Player 가 벽(wall) 을 클릭하면(Fire1)
// 2. 벽의 재질을 바꾼다.
public class ChangeMaterial : MonoBehaviour {
	public Material[] mats;
	int index = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// 1. Player 가 벽(wall) 을 클릭하면(Fire1)
		// - 사용자의 click event 확인하기
		if(Input.GetButtonDown("Fire1"))
		{
		// - 참이면 클릭된 녀석이 벽인지 확인하기
		// - click 했을때 Ray 를 쏜다.
		// - Ray 와 부딛힌 녀석이 벽인지 확인
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitinfo;
			// Ray 쏜다.
			int layer = 1 << LayerMask.NameToLayer ("Wall");
			if (Physics.Raycast (ray, out hitinfo, 20)) {
				if (hitinfo.transform.gameObject.layer == LayerMask.NameToLayer ("Wall")) {
					// 2. 벽의 재질을 바꾼다.
					MeshRenderer mr = hitinfo.transform.GetComponent<MeshRenderer>();
					mr.material = mats [index];
					//index = (index + 1) % mats.Length;
					index++;
					if (index >= mats.Length) {
						index = 0;
					}
				}
			}
		
		}
	}
}
