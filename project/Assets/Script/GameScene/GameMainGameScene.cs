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
		ObjectManager.eGameObjects.SCORE_WINDOW,
		ObjectManager.eGameObjects.LIFE_WINDOW,
		ObjectManager.eGameObjects.TSURE,
		ObjectManager.eGameObjects.YUBI,
	};

	int timer_car_create;
	static int interval_car_create; //per frame

	public static int INTERVAL_MIN = 60;
	public static int INTERVAL_MAX = 120;

	public static int ONE_UP_SCORE = 1000;
	/*
	 * 初期化;
	 */
	public override void init(){
		Debug.Log("to Scene game main");
		initObjects (mList);
		timer_car_create = 0;
		interval_car_create = Random.Range(INTERVAL_MIN, INTERVAL_MAX);
		SoundController.StopSoundBGM ((int)GameSound.BgmList.TITLE);
		SoundController.PlaySoundBGM((int)GameSound.BgmList.PLAY);
	}
	/*
	 * 更新;
	 */
	public override void update(){
		// update score
		ScoreManager.setMeter(ScoreManager.getMeter()+1);

		// display score
		SpriteFont _font = (SpriteFont)GameObject.Find("score_window(Clone)").transform.FindChild("SpriteFont").gameObject.GetComponent("SpriteFont");
		_font.SetText("" + ScoreManager.getMeter());

		// display life
		SpriteFont _life_font = (SpriteFont)GameObject.Find("life_window(Clone)").transform.FindChild("SpriteFont").gameObject.GetComponent("SpriteFont");
		_life_font.SetText("" + Chiken.mTsureList.Count);

		timer_car_create += 1;
		if(interval_car_create == timer_car_create)
		{
			timer_car_create = 0;
			interval_car_create = Random.Range (INTERVAL_MIN, INTERVAL_MAX-(ScoreManager.getMeter()/100));
			int _current_car_pos_index = Random.Range(0, RaneManager.RANE_ARRAY_POS.Length);
			GameObject _car_obj = (GameObject)GameObject.Instantiate(GameObject.Find("car(Clone)"));
			Car _car_sprite = (Car)_car_obj.GetComponent("Car");
			_car_sprite.setup(Random.Range(0, RaneManager.RANE_ARRAY_POS.Length));
		}

		//update tsure
		if((ScoreManager.getMeter() % ONE_UP_SCORE) == 0) {
			Chiken _chiken_spr = (Chiken)GameObject.Find("Player(Clone)").GetComponent("Chiken");
			_chiken_spr.createTsure();
		}
	}
	
	/*
	 * GUI更新;
	 */
	public override void onGui(){
	}


	public static void gameOver() {
		GameObject[] clones_car = GameObject.FindGameObjectsWithTag ("Car");
		foreach(GameObject obj in clones_car) {
			GameObject.Destroy(obj);
		}
		GameObject[] clonse_chicken = GameObject.FindGameObjectsWithTag("Chiken");
		foreach(GameObject obj in clonse_chicken) {
			GameObject.Destroy(obj);
		}
		SceneController.setChangeScene(SceneController.Scene.RESULT);
	}
}