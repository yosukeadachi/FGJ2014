using UnityEngine;
using System.Collections;

public class Chiken : MonoBehaviour {

	static float RANE_SPEED = 10.0f;//change range speed;

	static int current_pos_index = 0;

	static int mLife = 0;

	// Use this for initialization
	void Start () {
		mLife = 3;
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
			if(RaneManager.RANE_ARRAY_POS[_next_pos_index] < transform.position.y)
			{
				current_pos_index = _next_pos_index;
				rigidbody2D.velocity = Vector2.zero;
				transform.position = new Vector2(transform.position.x, RaneManager.RANE_ARRAY_POS[current_pos_index]);
			}
		}
		if(rigidbody2D.velocity.y < 0)
		{
			if(current_pos_index < RaneManager.RANE_ARRAY_POS.Length-1)
			{
				_next_pos_index = current_pos_index+1;
			}
			else {
				_next_pos_index = current_pos_index;
			}
			if(RaneManager.RANE_ARRAY_POS[_next_pos_index] > transform.position.y)
			{
				current_pos_index = _next_pos_index;
				rigidbody2D.velocity = Vector2.zero;
				transform.position = new Vector2(transform.position.x, RaneManager.RANE_ARRAY_POS[current_pos_index]);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		GameMainGameScene.gameOver();
	}
	
	private void OnTriggerStay2D(Collider2D other)
	{
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
	}	

}
