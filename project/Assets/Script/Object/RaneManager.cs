using UnityEngine;
using System.Collections;

public class RaneManager : MonoBehaviour {

	public enum RANE: int{
		UP = 0,
		CENTER,
		BOTTOM,
		COUNT,
	};
	public static float[] RANE_ARRAY_POS = {
		-0.5f,
		-2.0f,
		-4.0f,
	};

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
