using UnityEngine;

// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
	public float speed = 2.0f;
	
	void Start ()
	{
		rigidbody2D.velocity = transform.right.normalized * -1.0f * speed;
	}
}