using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUISkin skin;

	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Label (new Rect(Screen.width/2-175,10,700,100), "");
		if (PlayerPrefs.GetInt("Level Completed") > 1)
		{
			if (GUI.Button (new Rect (Screen.width/2-145, 175, 300, 90), "Continue"))				
			{
				Application.LoadLevel(1);
			}
		}
		if (GUI.Button (new Rect (Screen.width/2-95, 305, 200, 90), "New"))				
		{
			PlayerPrefs.SetInt("Level Completed", 1);
			Application.LoadLevel(1);
		}
		if (GUI.Button (new Rect (Screen.width/2-95, 435, 200, 90), "Quit"))				
		{
			Application.Quit ();
		}

	}
}
