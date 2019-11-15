using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SettingsHandler : MonoBehaviour
{
	public GameObject[] settingPanels;
	public AudioMixer audioMixer;
	private int currIndex;

	Resolution[] resolutions;
	int currentResolutionIndex;

	public Text viewValues;
	List<string> optionsResolution;


	// Start is called before the first frame update
	void Start()
    {
		currIndex = 0;

		for (int i = 0; i < settingPanels.Length; i++)
		{
			settingPanels[i].GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
		}

		optionsResolution = new List<string>();

		resolutions = Screen.resolutions;

		currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{

			string option = resolutions[i].width + "x" + resolutions[i].height;
			optionsResolution.Add(option);


			if (resolutions[i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}

		}

		viewValues.text = Screen.currentResolution.width + "x" + Screen.currentResolution.height;

	}

    // Update is called once per frame
    void Update()
    {
		for(int i = 0; i< settingPanels.Length; i++)
		{
			if(i == currIndex) settingPanels[i].GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 5.0f);
			else settingPanels[i].GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
		}

        if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			currIndex -= 1;
			if (currIndex < 0) currIndex = 4;
		}

		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			currIndex += 1;
			if (currIndex > 4) currIndex = 0;
		}


			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (currentResolutionIndex > 0)
				{
					currentResolutionIndex -= 1;
					Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, false);
					viewValues.text = optionsResolution[currentResolutionIndex];
				}
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (currentResolutionIndex < resolutions.Length)
				{
					currentResolutionIndex += 1;
					Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, false);
					viewValues.text = optionsResolution[currentResolutionIndex];
				}
			}
		
			
		
	}

	public void setResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void setMasterVolume(float vol)
	{
		audioMixer.SetFloat("master", vol);
	}

	public void setBGMVolume(float vol)
	{
		audioMixer.SetFloat("background", vol);
	}

	public void setSFXVolume(float vol)
	{
		audioMixer.SetFloat("effect", vol);
	}

	public void setCharacterVolume(float vol)
	{
		audioMixer.SetFloat("voice", vol);
	}

	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}
}
