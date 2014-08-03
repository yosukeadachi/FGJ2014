using UnityEngine;
using System.Collections;

public class ShipCreater : MonoBehaviour
{
	
	// PlayerBulletプレハブ
	public GameObject bullet;
	
	// Startメソッドをコルーチンとして呼び出す
	IEnumerator Start ()
	{
		while (true) {
			// 弾をプレイヤーと同じ位置/角度で作成
			Instantiate (bullet, transform.position, transform.rotation);
			// 10秒待つ
			yield return new WaitForSeconds (2.0f);
		}
	}
	
	void Update ()
	{

	}
}