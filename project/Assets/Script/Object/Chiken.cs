using UnityEngine;
using System.Collections;

public class Chiken : MonoBehaviour {

	static float RANE_SPEED = 10.0f;//change range speed;
	enum RANE: int{
		RANE_UP = 0,
		RANE_CENTER,
		RANE_BOTTOM,
		RANE_COUNT,
	};
	static float[] RANE_ARRAY_POS = {
		0.0f,
		-2.0f,
		-4.0f,
	};

	static int current_pos_index = 0;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		//input check
		if(InputManager.isTouchPhaseSlide())
		{
			if(rigidbody2D.velocity.y == 0)
			{
				if(InputManager.isSlideUp())
				{
					rigidbody2D.velocity = Vector2.up * RANE_SPEED;
				}
				else if(InputManager.isSlideDown())
				{
					rigidbody2D.velocity = Vector2.up * -1 * RANE_SPEED;
				}
			}
		}
	
		//position adujst
		int _next_pos_index = 0;
		if(rigidbody2D.velocity.y > 0)
		{
			if(current_pos_index > 0) {
				_next_pos_index = current_pos_index-1;
			}
			else {
				_next_pos_index = current_pos_index;
			}
			if(RANE_ARRAY_POS[_next_pos_index] < transform.position.y)
			{
				current_pos_index = _next_pos_index;
				rigidbody2D.velocity = Vector2.zero;
				transform.position = new Vector2(transform.position.x, RANE_ARRAY_POS[current_pos_index]);
			}
		}
		if(rigidbody2D.velocity.y < 0)
		{
			if(current_pos_index < RANE_ARRAY_POS.Length-1)
			{
				_next_pos_index = current_pos_index+1;
			}
			else {
				_next_pos_index = current_pos_index;
			}
			if(RANE_ARRAY_POS[_next_pos_index] > transform.position.y)
			{
				current_pos_index = _next_pos_index;
				rigidbody2D.velocity = Vector2.zero;
				transform.position = new Vector2(transform.position.x, RANE_ARRAY_POS[current_pos_index]);
			}
		}
	}
}
