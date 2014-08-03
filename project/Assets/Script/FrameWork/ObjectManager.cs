/*
 * @file;
 * @brief	オブジェクトマネージャ;
 * @auther	Yosuke Adachi;
 * @data	2014-05-23;
 */
/*------------------------------------------------------------
/ Using
/------------------------------------------------------------*/
using UnityEngine;
using System.Collections;

/*------------------------------------------------------------
/ オブジェクトマネージャ;
/------------------------------------------------------------*/
public class ObjectManager : MonoBehaviour
{
	// ゲーム全体で利用するオブジェクト;
	public enum eGameObjects : int 
	{
		TITLE_BG = 0,
		BTN_START,
		BTN_END,
		PLAYER,
		CAR,
		RANE_MANAGER,
		BACK_TITLE,
		TWEET,
		RESULT_BG,
		SCORE_WINDOW,
		SCORE_WINDOW_RESULT,
		LIFE_WINDOW,
		TSURE,
		TRACK,
		SHIP,
		CAMBUS,
		TITLE_LOGO,
		TOUCH_START,
		YUBI,
	}
	public GameObject[] mGameObjectListBase;
	public static GameObject[] mGameObjectListTemp;
	private static GameObject[] mSceneObjects;				// シーンごとのオブジェクト情報;


	/**
	 * @brief	初期化:
	 * @ntote
	 */
	void Start() {
		mGameObjectListTemp = mGameObjectListBase;
	}

	/**
	 * @brief	シーン内のゲームオブジェクト領域の確保;
	 * @param	aNumber		シーン内のオブジェクトの総数;
	 * @note
	 */
	public static void allocateSceneObjects(int aNumber) {
		mSceneObjects = new GameObject[aNumber];
	}

	/**
	 * @brief	ゲームオブジェクト生成;
	 * @param	aListIndex		オブジェクトリスト内のインデックス;
	 * @return	ゲームオブジェクト;
	 * @note
	 */
	public static GameObject createGameObject(eGameObjects aListIndex) {
		return (GameObject)Instantiate(mGameObjectListTemp[(int)aListIndex]);
	}

	/**
	 * @brief	指定したシーンリストのオブジェクトを作成;
	 * @pram	aList		シーン内のゲームオブジェクト番号リスト
	 * @note
	 */
	public static void makeGameObjectsInScene(eGameObjects[] aList) {
		allocateSceneObjects (aList.Length);
		for(int i = 0; i < aList.Length; i++) {
			mSceneObjects[i] = createGameObject(aList[i]);
		}
	}

	/**
	 * @brief	シーン内のゲームオブジェクトをすべて破棄;
	 * @note
	 */
	public static void destroySceneObjectsAll()
	{
		if (mSceneObjects == null) {
			return;
		}
		foreach (GameObject _object in mSceneObjects) {
			Destroy(_object);
		}
	}
}
