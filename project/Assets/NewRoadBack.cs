using UnityEngine;

public class NewRoadBack : MonoBehaviour
{
	// スクロールするスピード
	public float speed = 0.1f;
	
	void Start ()
	{
		// 画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		
		// スケールを求める。
		Vector2 scale = max * 2;
		

	}
	
	void Update ()
	{
		// 時間によってXの値が0から1に変化していく。1になったら0に戻り、繰り返す。
		float x = Mathf.Repeat (Time.time * speed, 1);
		
		// Xの値がずれていくオフセットを作成
		Vector2 offset = new Vector2 (x, 0);
		
		// マテリアルにオフセットを設定する
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}