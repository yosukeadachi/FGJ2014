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
		ObjectManager.eGameObjects.RANE_MANAGER,
		ObjectManager.eGameObjects.CAR,
	};

	int timer_car_create;
	static int interval_car_create; //per frame
	/*
	 * 初期化;
	 */
	public override void init(){
		Debug.Log("to Scene game main");
		initObjects (mList);
		timer_car_create = 0;
		interval_car_create = Random.Range(30, 60);
	}
	/*
	 * 更新;
	 */
	public override void update(){
		timer_car_create += 1;
		if(interval_car_create == timer_car_create)
		{
			timer_car_create = 0;
			int _current_car_pos_index = Random.Range(0, RaneManager.RANE_ARRAY_POS.Length);
			GameObject _car_obj = (GameObject)GameObject.Instantiate(GameObject.Find("car(Clone)"));
			_car_obj.transform.position = new Vector2(10, RaneManager.RANE_ARRAY_POS[_current_car_pos_index]);
			float _speed = 5.0f;
			_car_obj.rigidbody2D.velocity = Vector2.right * -1 * _speed;
			interval_car_create = Random.Range (30, 60);
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


	public static void gameOver() {
		GameObject[] clones = GameObject.FindGameObjectsWithTag ("Car");
		foreach(GameObject obj in clones) {
			GameObject.Destroy(obj);
		}
		SceneController.setChangeScene(SceneController.Scene.RESULT);
	}
}