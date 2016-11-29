using UnityEngine;
using System.Collections;

public class LightState : MonoBehaviour {
	bool isTurnOn = true;
	Light light;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
		light.enabled = isTurnOn;
	}

	// 함수가 호출되면
	// 불이 켜져 있을 경우 꺼주고, 반대의 경우 켜준다.
	public void Control()
	{
//		if (isTurnOn) {
//			isTurnOn = false;
//		} else {
//			isTurnOn = true;
//		}
		isTurnOn = !isTurnOn;
		light.enabled = isTurnOn;
	}
}
