using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
	public GameObject[] panelIndex;
	private int currIndex;

    // Start is called before the first frame update
    void Start()
    {
		currIndex = 0;
		for(int i = 0; i < panelIndex.Length; i++)
		{
			panelIndex[i].GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
		}
        
    }

    // Update is called once per frame
    void Update()
    {
		for(int i = 0; i< panelIndex.Length; i++)
		{
			if(i == currIndex) panelIndex[i].GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 5.0f);
			else panelIndex[i].GetComponent<Image>().color = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
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
	}
}
