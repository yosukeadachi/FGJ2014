/*
 * @file;
 * @brief	result;
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
public class ResultGameScene : GameScene {
	/*
	 * シーン内オブジェクト;
	 */
	public ObjectManager.eGameObjects[] mList = {
		ObjectManager.eGameObjects.RESULT_BG,
		ObjectManager.eGameObjects.BACK_TITLE,
		ObjectManager.eGameObjects.TWEET,
		ObjectManager.eGameObjects.SCORE_WINDOW_RESULT
	};
	
	/*
	 * 初期化;
	 */
	public override void init(){
		Debug.Log("to Scene game main");
		initObjects (mList);
	}
	/*
	 * 更新;
	 */
	public override void update(){
		// view score
		SpriteFont _font = (SpriteFont)GameObject.Find("score_window_result(Clone)").transform.FindChild("SpriteFont").gameObject.GetComponent("SpriteFont");
		_font.SetText("" + ScoreManager.getMeter());


		if(InputManager.isTouchObject("backtitle(Clone)")) {
			SceneController.setChangeScene(SceneController.Scene.TITLE_MAIN);
		}
		if(InputManager.isTouchObject("tweet(Clone)")) {
			string message = "" + ScoreManager.getMeter() + "m走ったぜ！ 爆走ヤンキーコーチン!! #fgj2014 #fgj2014nagoya";
			Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(message));
		}
	}
	
	/*
	 * GUI更新;
	 */
	public override void onGui(){
	}
}