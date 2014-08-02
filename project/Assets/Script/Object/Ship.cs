using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	public static float START = -10.0f;
	public static float LIMIT_VANISH_MAX = 20.0f;
	public static float LIMIT_VANISH_MIN = -20.0f;

	int timer_ship_create;
	static int interval_ship_create; //per frame
	
	public static int INTERVAL_MIN = 60;
	public static int INTERVAL_MAX = 120;
	
	public float mSpeed = 5.0f;
	// Use this for initialization
	void Start () {
	}
	
	public void setup(int aPosIndex) {
		rigidbody2D.velocity = Vector2.right * -1.0f * mSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < LIMIT_VANISH_MIN)
		{
			Object.Destroy(gameObject);
		}

		timer_ship_create += 1;
		if(interval_ship_create == timer_ship_create)
		{
			timer_ship_create = 0;
			interval_ship_create = Random.Range (INTERVAL_MIN, INTERVAL_MAX);
			//int _current_car_pos_index = Random.Range(0, RaneManager.RANE_ARRAY_POS.Length);
			GameObject _ship_obj = (GameObject)GameObject.Instantiate(GameObject.Find("Ship(Clone)"));
			Ship _ship_sprite = (Ship)_ship_obj.GetComponent("Ship");
			//_car_sprite.setup(Random.Range(0, RaneManager.RANE_ARRAY_POS.Length));
		}
	}
}
