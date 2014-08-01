/*
 * @file;
 * @brief	ゲームシーンの基礎;
 * @auther	Yosuke Adachi;
 * @data	2014-07-01;
 */
/*------------------------------------------------------------
/ Using
/------------------------------------------------------------*/

/*------------------------------------------------------------
/ ゲームシーンの基礎;
/------------------------------------------------------------*/
public abstract class GameScene {
	public abstract void init();	//シーン変更時の開始時の初期化;
	public abstract void update();	//シーン更新;
	public abstract void onGui ();	//GUI関連更新;

	/**
	 * @brief オブジェクト初期設定;
	 * @note
	 */
	protected void initObjects(ObjectManager.eGameObjects[] aList) {
		// オブジェクト破棄;
		ObjectManager.destroySceneObjectsAll ();
		// オブジェクト生成;
		ObjectManager.makeGameObjectsInScene (aList);
	}
}