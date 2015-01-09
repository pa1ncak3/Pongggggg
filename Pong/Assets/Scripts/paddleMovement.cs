using UnityEngine;
using System.Collections;

public class paddleMovement : MonoBehaviour {

	public KeyCode up = new KeyCode();
	public KeyCode down = new KeyCode();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (up))
			transform.Translate(new Vector2(0f,.025f));
		if (Input.GetKey (down))
			transform.Translate(new Vector2 (0f,-.025f));
	}
}
