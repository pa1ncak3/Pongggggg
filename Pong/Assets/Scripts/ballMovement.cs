using UnityEngine;
using System.Collections;

public class ballMovement : MonoBehaviour {

	public float speed = 2.0f;
	public float speedAdd = .1f;

	// Use this for initialization
	void Start () {
		//Gives ball initial movement
		rigidbody2D.velocity = Vector2.one.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(rigidbody2D.velocity.ToString());
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		//Collision with borders to score points
		if (col.gameObject.name == "borderLeft") {
			gameControl.updateScore("borderLeft");
			resetBall(1);
		}
		if (col.gameObject.name == "borderRight") {
			gameControl.updateScore("borderRight");
			resetBall(-1);
		}

		//Collision with paddle to change angle
		if (col.gameObject.name == "paddleLeft") {
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			//Calculate direction
			Vector2 dir = new Vector2(1,y).normalized;
			//Set velocity
			rigidbody2D.velocity = dir * speed;
		}
		if (col.gameObject.name == "paddleRight") {
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
			//Calculate direction
			Vector2 dir = new Vector2(-1,y).normalized;
			//Set velocity
			rigidbody2D.velocity = dir * speed;
		}
	}

	float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight) {
		return (ballPos.y - paddlePos.y) / paddleHeight;
	}

	void resetBall(int side) {
		gameObject.transform.position = new Vector2 (0,0);
		rigidbody2D.velocity = Vector2.one.normalized * 0;
		rigidbody2D.velocity = Vector2.one.normalized * (speed + speedAdd) * side;
	}
}
