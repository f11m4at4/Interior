using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
	public int MAX_HP = 3;
	private int hp;

	public static PlayerState Instance = null;

	void Awake()
	{
		if (Instance == null) {
			Instance = this;
		}
	}

	public int MyHp
	{
		get {
			return hp;
		}
		set {
			hp = value;
			if (hp <= 0) {
				Destroy (gameObject);
			}
		}
	}

	/*
	public int GetHP()
	{
		return hp;
	}

	public void SetHP(int value)
	{
		hp = value;
		if (hp <= 0) {
			Destroy (gameObject);
		}
	}
*/

	// Use this for initialization
	void Start () {
		hp = MAX_HP;
	}
}
















