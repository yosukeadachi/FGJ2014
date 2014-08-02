using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
	public static float LIMIT_VANISH = -20.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < LIMIT_VANISH)
		{
			Object.Destroy(gameObject);
		}
	}
}
