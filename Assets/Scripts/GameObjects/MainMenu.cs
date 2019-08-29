using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject optionsObject;
	public EventSystem eventSystem;
	public GameObject optionsButton;

    void Start()
    {
		optionsObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (optionsObject.active == true)
			{
				optionsObject.SetActive(false);
				eventSystem.SetSelectedGameObject(optionsButton);
			}
		}
	}

	public void Play()
	{
		SceneManager.LoadScene(1);
		EventSystem.current.SetSelectedGameObject(null);
	}

	public void ExitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();	
#endif
		EventSystem.current.SetSelectedGameObject(null);
	}
	

	public void Settings()
	{
		optionsObject.SetActive(true);
		EventSystem.current.SetSelectedGameObject(null);
	}

}
