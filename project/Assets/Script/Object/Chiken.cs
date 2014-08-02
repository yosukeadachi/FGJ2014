using UnityEngine;
using System.Collections;

public class Chiken : MonoBehaviour {

	static float RANE_SPEED = 10.0f;//change range speed;

	static int mCurrent_pos_index = 0;

	public static int mLife = 0;

	int mInvisibleTimer = 0;
	int invisible_time = 60;

	// Use this for initialization
	void Start () {
		mLife = 3;
	}
	// Update is called once per frame
	void Update () {
		//update ivisible timer
		if(mInvisibleTimer > 0)
		{
			mInvisibleTimer--;
		}


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
			if(mCurrent_pos_index > 0) {
				_next_pos_index = mCurrent_pos_index-1;
			}
			else {
				_next_pos_index = mCurrent_pos_index;
			}
			if(RaneManager.RANE_ARRAY_POS[_next_pos_index] < transform.position.y)
			{
				mCurrent_pos_index = _next_pos_index;
				rigidbody2D.velocity = Vector2.zero;
				transform.position = new Vector2(transform.position.x, RaneManager.RANE_ARRAY_POS[mCurrent_pos_index]);
			}
		}
		if(rigidbody2D.velocity.y < 0)
		{
			if(mCurrent_pos_index < RaneManager.RANE_ARRAY_POS.Length-1)
			{
				_next_pos_index = mCurrent_pos_index+1;
			}
			else {
				_next_pos_index = mCurrent_pos_index;
			}
			if(RaneManager.RANE_ARRAY_POS[_next_pos_index] > transform.position.y)
			{
				mCurrent_pos_index = _next_pos_index;
				rigidbody2D.velocity = Vector2.zero;
				transform.position = new Vector2(transform.position.x, RaneManager.RANE_ARRAY_POS[mCurrent_pos_index]);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(!other.gameObject.tag.Equals("Car"))
		{
			return;
		}

		if(mInvisibleTimer == 0){
			mInvisibleTimer = invisible_time;
			if(mLife > 0){
				mLife--;
				if(mLife == 0){
					GameMainGameScene.gameOver();
				}
				other.gameObject.rigidbody2D.velocity = Vector2.right * -1 * 2.0f;
			}
		}
	}
	
	private void OnTriggerStay2D(Collider2D other)
	{
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
	}	

}
