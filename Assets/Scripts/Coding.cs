using UnityEngine;
using System.Collections;

public class Coding : MonoBehaviour {
	// 전역 변수
	public int number1 = 2;
	public int number2 = 3;

	// Use this for initialization
	void Start () {
		// while (반복) test
		// 100 회 반복 하는 동안
		// i % 2 == 0 일때의 값을 더하여 결과를 출력


		int result = 0;

		// for (변수초기값;조건;증감분)
		for(int i = 0; i < 100 ; i += 1)
		{
			// i % 2 == 0 일때의 값을 더하여 결과를 출력
			if (i % 2 == 0) {
				result += i;
			}
		}

		print ("결과값은 : " + result);
	}
	
	// 반환자료형 함수이름 ( 인자 -> 자료형 변수이름 ...)
	// { }

	// 더하기 함수
	// 지역 변수가 전역변수와 이름이 같으면 전역 변수는 무시 된다.
	int Sum(int number1, int number2)
	{
		int result = number1 + number2;

		return result;
	}

}
