using UnityEngine;
using System.Collections;

public class gameControl : MonoBehaviour {

	public static int scorePlayer1 = 0;
	public static int scorePlayer2 = 0;
	public GUISkin layout;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void updateScore(string borderName)
	{
		//Called by Ball Script and updates scores
		if (borderName == "borderLeft")
			scorePlayer2++;
		if (borderName == "borderRight")
			scorePlayer1++;
	}

	//Displays scores.
	void OnGUI()
	{
		GUI.skin = layout;
		GUI.Label (new Rect (Screen.width / 2 - 150 - 12, 20, 100, 100), "" + scorePlayer1);
		GUI.Label (new Rect (Screen.width / 2 + 150 + 12, 20, 100, 100), "" + scorePlayer2);
	}
}
