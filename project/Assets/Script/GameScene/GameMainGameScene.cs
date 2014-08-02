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
		ObjectManager.eGameObjects.TITLE_BG,
		ObjectManager.eGameObjects.PLAYER,
		ObjectManager.eGameObjects.CAR,
		ObjectManager.eGameObjects.RANE_MANAGER,

	};

	int timer_car_create = 0;
	static int interval_car_create = 45; //per frame
	GameObject car_obj;
	/*
	 * 初期化;
	 */
	public override void init(){
		Debug.Log("to Scene game main");
		initObjects (mList);
		timer_car_create = 0;
		interval_car_create = 450;
		car_obj = GameObject.Find("car(Clone)");
	}
	/*
	 * 更新;
	 */
	public override void update(){
		timer_car_create += 1;
		if(interval_car_create == timer_car_create)
		{
			timer_car_create = 0;
			int _current_car_pos_index = new System.Random().Next(3);
			car_obj.transform.position = new Vector2(10, RaneManager.RANE_ARRAY_POS[_current_car_pos_index]);
		}
		if(InputManager.isTouchObject("btn_end(Clone)")) {
			SceneController.setChangeScene(SceneController.Scene.TITLE_MAIN);
		}
	}
	
	/*
	 * GUI更新;
	 */
	public override void onGui(){
	}
}