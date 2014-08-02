using UnityEngine;
using System.Collections;

public class Chiken : MonoBehaviour {

	static float RANE_SPEED = 20.0f;//change range speed;
	enum RANE: int{
		RANE_UP = 0,
		RANE_CENTER,
		RANE_BOTTOM,
		RANE_COUNT,
	};
	static float[] RANE_ARRAY_POS = {
		100.0f,
		200.0f,
		300.0f,
	};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(InputManager.isTouchPhaseSlide())
		{
			rigidbody2D.velocity = Vector2.up * RANE_SPEED;
		}
	
	}
}
