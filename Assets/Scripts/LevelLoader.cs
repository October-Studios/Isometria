using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {
	public int levelToLoad;
	public GameObject padlock;
	private string loadPrompt;
	private bool inRange;
	private int completedLevel;
	private bool canLoadLevel;

	void Start()
	{
		completedLevel = PlayerPrefs.GetInt("Level Completed");
		canLoadLevel = levelToLoad <= completedLevel ? true : false;
		if (!canLoadLevel)
		{
			Instantiate(padlock, new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z), Quaternion.identity);
		}
	}

	void Update()
	{
		if (canLoadLevel && Input.GetButtonDown("Action") && inRange)
		{
			Application.LoadLevel("Level " + levelToLoad.ToString());
		}
	}

	void OnTriggerStay(Collider other)
	{
		inRange = true;
		if (canLoadLevel)
		{
			loadPrompt = "[E] to load level " + levelToLoad.ToString();
		} else {
			loadPrompt = "Level " + levelToLoad.ToString() + " is locked";
		}
	}

	void OnTriggerExit ()
	{
		inRange = false;
		loadPrompt = "";
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 40, 400, 200, 40), loadPrompt); 
	}
}
