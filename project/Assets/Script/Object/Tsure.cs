using UnityEngine;
using System.Collections;

public class Tsure : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(!other.gameObject.tag.Equals("Car"))
		{
			return;
		}
		Chiken.hitCar();
	}

}
