using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chiken : MonoBehaviour {

	static float RANE_SPEED = 10.0f;//change range speed;

	static int mCurrent_pos_index = 0;

	static bool mIsHitTrigger = false;
	public static int mInvisibleTimer = 0;
	public static int invisible_time = 60;

	int DEFAULT_LIFE = 3;

	public static Stack<GameObject> mTsureList;
	float tsureSpan = -2.0f;

	// Use this for initialization
	void Start () {
		mTsureList = new Stack<GameObject>();
		for(int i = 0; i < DEFAULT_LIFE-1; i++) {
			createTsure();
		}
		mIsHitTrigger = false;
	}

	public void createTsure() {
		GameObject _tsure = (GameObject)GameObject.Instantiate(GameObject.Find("tsure(Clone)"));
		if(mTsureList.Count == 0) {
			_tsure.transform.position = new Vector2(transform.position.x + tsureSpan,transform.position.y);
		}
		else {
			GameObject _peek = mTsureList.Peek ();
			_tsure.transform.position = new Vector2(_peek.transform.position.x + tsureSpan,_peek.transform.position.y);
		}
		mTsureList.Push(_tsure);
	}
	
	// Update is called once per frame
	void Update () {
		//hit trigger
		if(mIsHitTrigger)
		{
			mIsHitTrigger = false;
			if(mInvisibleTimer == 0){
				mInvisibleTimer = invisible_time;
				if(mTsureList.Count > 0){
					GameObject.Destroy(mTsureList.Pop());
				}
				else if(mTsureList.Count == 0){
					GameMainGameScene.gameOver();
				}
			}
		}


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

		//update tsure position
		foreach(GameObject _tsure_obj in mTsureList) {
			_tsure_obj.transform.position = new Vector2(_tsure_obj.transform.position.x, transform.position.y);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(!other.gameObject.tag.Equals("Car"))
		{
			return;
		}
		hitCar();
	}

	public static void hitCar() {
		mIsHitTrigger = true;
	}
}
