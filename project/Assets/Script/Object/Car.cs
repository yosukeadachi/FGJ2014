using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = Vector2.right * -1 * 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
