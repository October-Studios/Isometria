using UnityEngine;
using System.Collections;

public class CreditsGUI : MonoBehaviour {
	public GUISkin skin;
	
	void OnGUI()
	{
		GUI.skin = skin;
		if (GUI.Button (new Rect (Screen.width/2+300, 500, 100, 45), "QUIT"))				
		{
			Application.LoadLevel (0);
		}
	}
}
