using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour {
	public static int stage = 0;

	public static void lotStage() {
		stage = Random.Range(0,3);

	}

	public static void setStage(int aStage) {
		GameObject[] _bgList = {
			GameObject.Find("Backgrounds(Clone)"),
			GameObject.Find ("Sakae_Backgrounds(Clone)"),
			GameObject.Find("NagoyaCastel_Backgrounds(Clone)"),
		};
		foreach(GameObject _obj in _bgList)
		{
			_obj.SetActive(false);
		}
		_bgList[stage].SetActive(true);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
