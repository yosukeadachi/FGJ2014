/*
 * @file;
 * @brief	ゲームシーン  game main;
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
public class GameMainGameScene : GameScene {
	/*
	 * シーン内オブジェクト;
	 */
	public ObjectManager.eGameObjects[] mList = {
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
	}
	
	/*
	 * GUI更新;
	 */
	public override void onGui(){
	}
}