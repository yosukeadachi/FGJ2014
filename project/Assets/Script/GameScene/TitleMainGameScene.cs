/*
 * @file;
 * @brief	ゲームシーン タイトル;
 * @auther	Yosuke Adachi;
 * @data	2014-07-01;
 */
/*------------------------------------------------------------
/ Using
/------------------------------------------------------------*/
using UnityEngine;
using System.Collections;

/*------------------------------------------------------------
/ タイトル ;
/------------------------------------------------------------*/
public class TitleMainGameScene : GameScene {
	/*
	 * シーン内オブジェクト;
	 */
	public ObjectManager.eGameObjects[] mList = {
		ObjectManager.eGameObjects.BTN_START,
		// ここに追加;
		ObjectManager.eGameObjects.TITLE_BG,
	};

	/*
	 * 初期化;
	 */
	public override void init(){
		Debug.Log("to Scene title");
		initObjects (mList);
		SoundController.PlaySoundBGM((int)GameSound.BgmList.TITLE);
		ScoreManager.setMeter(0);
	}
	/*
	 * 更新;
	 */
	public override void update(){
		GameObject _track = GameObject.Find ("Track");
		if (InputManager.isTouchObject("btn_start(Clone)")) {
			SoundController.PlaySoundSE((int)GameSound.SeList.GAME_START);
			_track.rigidbody2D.velocity = Vector2.right * -1 * 10.0f;
		}
		if (_track.transform.position.x <  -20.0f) {
			SceneController.setChangeScene(SceneController.Scene.GAME_MAIN);
		}
	}
	
	/*
	 * GUI更新;
	 */
	public override void onGui(){
	}
}