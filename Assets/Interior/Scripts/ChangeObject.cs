using UnityEngine;
using System.Collections;

public class ChangeObject : MonoBehaviour {
	public GameObject[] tables;
	public GameObject[] tablesPosition;
	int index = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 1. Player 가 벽(wall) 을 클릭하면(Fire1)
		// - 사용자의 click event 확인하기
		if(Input.GetButtonDown("Fire2"))
		{
			// - 참이면 클릭된 녀석이 벽인지 확인하기
			// - click 했을때 Ray 를 쏜다.
			// - Ray 와 부딛힌 녀석이 벽인지 확인
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitinfo;
			// Ray 쏜다.
			if (Physics.Raycast (ray, out hitinfo, 20)) {
				if (hitinfo.transform.gameObject.layer == LayerMask.NameToLayer ("Table")) {
					// 2. table 을 바꾼다
					GameObject table = Instantiate(tables[index]);
					table.transform.position = hitinfo.transform.position;
					Destroy (hitinfo.transform.gameObject);
					//index = (index + 1) % mats.Length;
					index++;
					if (index >= tables.Length) {
						index = 0;
					}
				}
			}

		}	
	}
}
