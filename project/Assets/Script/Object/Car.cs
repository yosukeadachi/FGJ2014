using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	public static float START = -10.0f;
	public static float LIMIT_VANISH_MAX = 20.0f;
	public static float LIMIT_VANISH_MIN = -20.0f;

	public float mSpeed = 5.0f;
	// Use this for initialization
	void Start () {
	}

	public void setup(int aPosIndex) {
		transform.position = new Vector2(START, RaneManager.RANE_ARRAY_POS[aPosIndex]);
		rigidbody2D.velocity = Vector2.right * mSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > LIMIT_VANISH_MAX)
		{
			Object.Destroy(gameObject);
		}
		else if(transform.position.x < LIMIT_VANISH_MIN)
		{
			Object.Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(!other.gameObject.tag.Equals("Chiken"))
		{
			return;
		}
		rigidbody2D.velocity = Vector2.right * -1 * 2.0f;
	}
}
