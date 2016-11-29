using UnityEngine;
using System.Collections;

// 1. L 버튼을 누르면 라이트를 껏다 켯다 할 수 있다.
//	- 필요한 것
//		- Sphere (light) 바라봐야 한다.

public class LightControl : MonoBehaviour {
		
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Light"))
		{
			Ray ray = new Ray (Camera.main.transform.position,
				          Camera.main.transform.forward);
			RaycastHit hitinfo;
			// Ray 쏜다.
			if (Physics.Raycast (ray, out hitinfo)) {
				if (hitinfo.transform.gameObject.layer == LayerMask.NameToLayer ("Light")) {

					// 부모의 LightState 컴포넌트를 얻어 온다.
					GameObject lit = hitinfo.transform.parent.gameObject;
					LightState ls = lit.GetComponent<LightState> ();
					ls.Control ();

				}
			}

		}
	}
}
