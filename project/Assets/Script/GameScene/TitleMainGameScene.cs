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
		// ここに追加
		ObjectManager.eGameObjects.PLAYER
	};

	/*
	 * 初期化;
	 */
	public override void init(){
		Debug.Log("to Scene title");
		initObjects (mList);
		SoundController.PlaySoundBGM(GameSound.BgmList.TITLE);
	}
	/*
	 * 更新;
	 */
	public override void update(){
		if (InputManager.isTouchObject("btn_start(Clone)")) {
			SoundController.PlaySoundSE(GameSound.SeList.GAME_START);
			SceneController.setChangeScene(SceneController.Scene.GAME_MAIN);
		}
	}
	
	/*
	 * GUI更新;
	 */
	public override void onGui(){
	}
}