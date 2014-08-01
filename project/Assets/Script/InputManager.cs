/*
 * @file;
 * @brief	入力マネージャー;
 * @auther	Taiki Furui;
 * @data	2014-05-23;
 */
/*------------------------------------------------------------
/ Using
/------------------------------------------------------------*/
using UnityEngine;
using System.Collections;

/*------------------------------------------------------------
/ 入力マネージャー;
/------------------------------------------------------------*/
public class InputManager : MonoBehaviour
{
	// タッチステータス;
	private enum TouchState : int
	{
		NON = 0,
		SLIDE_START,					// スライド開始;
		SLIDE_END,						// スライド終了;
		EVENT_CNT
	}

	private static GameObject mHitObject = null;							// タッチオブジェクト情報格納領域;
	private static Vector2[] mMousePos = null, mTempMousePos = null;		// タッチ座標;
	private static TouchState mTouchState = TouchState.NON;					// タッチステータス;
	private static bool mScreenSlide = false;								// スライド判定;


	/**
	 * @brief	初期化;
	 * @note
	 */
	void Start()
	{
		mMousePos = new Vector2[(int)TouchState.EVENT_CNT];
		mTempMousePos = new Vector2[(int)TouchState.EVENT_CNT];
		mTouchState = TouchState.NON;
		mScreenSlide = false;
	}

	/**
	 * @brief	更新;
	 * @note
	 */
	void Update()
	{
		// オブジェクトタッチ情報更新;
		updateHitObject();

		// 画面スライド情報更新;
		updateScreenSlide();
	}

	/**
	 * @brief	タッチイベント(押したとき);
	 * @note
	 */
	public void OnMouseDown()
	{
		// タッチをした時;
	//	Debug.Log ("MouseDown X:"+Input.mousePosition.x+" Y:"+Input.mousePosition.y);
		mTempMousePos[(int)TouchState.SLIDE_START] = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		mTouchState = TouchState.SLIDE_START;
	}

	/**
	 * @brief	タッチイベント(離したとき);
	 * @note
	 */
	public void OnMouseUp()
	{
		// タッチを離した時;
	//	Debug.Log ("MouseUp X:"+Input.mousePosition.x+" Y:"+Input.mousePosition.y);
		mTempMousePos[(int)TouchState.SLIDE_END] = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
		mTouchState = TouchState.SLIDE_END;
	}

	/**
	 * @brief	タッチされたか判定;
	 * @param	aObjName	オブジェクト名;
	 * @note
	 */
	public static bool		isTouchObject(string aObjName) {
		return (mHitObject != null && mHitObject.name.CompareTo (aObjName) == 0) ? true : false;
	}

	/**
	 * @brief	スライドタッチされたか判定;
	 * @note
	 */
	public static bool		isTouchPhaseSlide() {
		return mScreenSlide;
	}

	/**
	 * @brief	タッチ情報オールリセット;
	 * @note
	 */
	public static void resetAll()
	{
		mHitObject = null;
		mTouchState = TouchState.NON;
		mMousePos[(int)TouchState.SLIDE_START] = mTempMousePos[(int)TouchState.SLIDE_START] = new Vector2(0.0f, 0.0f);
		mMousePos[(int)TouchState.SLIDE_END] = mTempMousePos[(int)TouchState.SLIDE_END] = new Vector2(0.0f, 0.0f);
		mScreenSlide = false;
	}
	
	/**
	 * @brief	タッチステータスクリア;
	 * @note
	 */
	private void resetTouchState() {
		mTouchState = TouchState.NON;
	}

	/**
	 * @brief	オブジェクトタッチ判定更新;
	 * @note
	 */
	private void updateHitObject()
	{
		
		// タッチオブジェクト情報クリア;
		if (mHitObject != null) {
			mHitObject = null;
		}
		
		// オブジェクトタッチ情報更新;
		if (Input.GetMouseButtonDown(0)) {
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collition = Physics2D.OverlapPoint(tapPoint);
			if (collition) {
				RaycastHit2D hitObject = Physics2D.Raycast(tapPoint,-Vector2.up);
				if (hitObject) {
					mHitObject = hitObject.collider.gameObject;
					Debug.Log("hit object is " + hitObject.collider.gameObject.name);
					//	Debug.Log("hit object is " + hitObject.collider.gameObject.name);
				}
			}
		}
	}

	/**
	 * @brief	スライド情報更新;
	 * @note
	 */
	private void	updateScreenSlide()
	{
		switch (mTouchState) {
			case TouchState.NON:
				// 座標情報クリア;
				mMousePos[(int)TouchState.SLIDE_START] = mTempMousePos[(int)TouchState.SLIDE_START] = new Vector2(0.0f, 0.0f);
				mMousePos[(int)TouchState.SLIDE_END] = mTempMousePos[(int)TouchState.SLIDE_END] = new Vector2(0.0f, 0.0f);
				mScreenSlide = false;
				break;
			
			case TouchState.SLIDE_START:
				mMousePos[(int)TouchState.SLIDE_START] = mTempMousePos[(int)TouchState.SLIDE_START];
				break;
			
			case TouchState.SLIDE_END:
				mMousePos[(int)TouchState.SLIDE_END] = mTempMousePos[(int)TouchState.SLIDE_END];
				mScreenSlide = true;				// 無条件でスライド判定をONにする;
				resetTouchState();					// タッチステータスクリア;
				break;
		}
	}
}
