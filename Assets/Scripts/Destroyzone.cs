using UnityEngine;
using System.Collections;

// 물체와 부딛히면 물체 제거
public class Destroyzone : MonoBehaviour {

	// other 와 충돌 할경우 호출됨.
	void OnTriggerEnter(Collider other)
	{
		// 1. 이름으로 구분
		// 2. Tag
		// 3. Layer
		if (other.gameObject.name.Contains("Enemy")) {
			//Destroy (other.gameObject);
			gameObject.SetActive(false);
		} else {
			other.gameObject.SetActive (false);
		}
	}
}
