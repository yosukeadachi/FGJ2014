/*
 * @file;
 * @brief	シーンのコントローラー;
 * @auther	Yosuke Adachi;
 * @data	2014-05-23;
 */
/*------------------------------------------------------------
/ Using
/------------------------------------------------------------*/
using UnityEngine;
using System.Collections;

/*------------------------------------------------------------
/ シーンのコントローラー;
/------------------------------------------------------------*/
public class SceneController : MonoBehaviour
{
	// シーンタイプ;
	public enum Scene : int
	{
		NON = 0, 
		TITLE_MAIN, 				// タイトル;
	}

	private static GameScene[] mGameSceneList = {
		null,
		new TitleMainGameScene(),
	};

	private static Scene	mNowScene = Scene.NON;
	private static Scene	mNextScene = Scene.TITLE_MAIN;

	/**
	 * @brief	更新;
	 * @note
	 */
	void Update()
	{
		//シーン更新;
		updateScene();
	}

	/**
	 * @brief	GUI更新;
	 * @note
	 */
	void OnGUI()
	{
		Scene nowScene = getNowScene();
		//GUI更新;
		if (mGameSceneList [(int)nowScene] != null) {
			mGameSceneList [(int)nowScene].onGui ();
		}
	}

	/**
	 * @brief	シーン更新;
	 * @note
	 */
	private void updateScene()
	{
		Scene nowScene = getNowScene();
		// シーン実行
		if (mGameSceneList [(int)nowScene] != null) {
			mGameSceneList [(int)nowScene].update ();
		}

		// シーン変更要請のある場合;
		Scene nextScene = SceneController.getChangeScene();
		if(nextScene != Scene.NON) {
			// シーンが変わったときタッチ判定をクリアする;
			InputManager.resetAll();
			// シーン初期化;
			if(mGameSceneList[(int)nextScene] != null) {
				mGameSceneList[(int)nextScene].init();
			}
			// シーン移行;
			SceneController.setNowScene(nextScene);
			SceneController.setChangeScene(Scene.NON);
		}
	}

	
	/**
	 * @brief	現在のシーンを取得;
	 * @return	現在のシーン;
	 * @note
	 */
	public static Scene getNowScene() {
		return	mNowScene;
	}

	/**
	 * @brief	現在のシーンを設定;
	 * @param	aScene	シーン情報;
	 * @note
	 */
	public static void		setNowScene(Scene aScene) {
		mNowScene = aScene;
	}
	
	/**
	 * @brief	変更予定のシーンを取得;
	 * @return	シーン情報;
	 * @note
	 */
	public static Scene getChangeScene() {
		return	mNextScene;
	}
	
	/**
	 * @brief	変更予定のシーンを設定;
	 * @param	aScene	シーン情報;
	 * @note
	 */
	public static void setChangeScene(Scene aScene) {
		mNextScene = aScene;
	}
}