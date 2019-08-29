using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
	//Game scenario for prolog
	public GameObject player;
	public GameObject transition;
	public GameObject cinematicView;

	public int scenarioCounter;
    // Start is called before the first frame update
    void Start()
    {
		cinematicView.SetActive(false);
		player.GetComponent<PlayerController>().CharacterStatus = 0;
		scenarioCounter = 0;
		StopCharacter();
		player.transform.SetPositionAndRotation(new Vector3(2.91f, 0.31f, 0f), Quaternion.LookRotation(new Vector3(0f, 0f, 0f)));
    }

    // Update is called once per frame
    void Update()
    {
		if (player.transform.position.y < -3.41 && scenarioCounter == 0)
		{
			Fungus.Flowchart.BroadcastFungusMessage("talk2");
			scenarioCounter++;
		}
		if (player.transform.position.y < -10.41 && scenarioCounter == 1)
		{
			Fungus.Flowchart.BroadcastFungusMessage("jatuh");
			scenarioCounter++;
		}
	}

	void StopCharacter()
	{
		player.GetComponent<PlayerController>().CharacterStop = true;
	}

	void UnstopCharacter()
	{
		player.GetComponent<PlayerController>().CharacterStop = false;
	}

	void FadeInTransition()
	{
		transition.GetComponent<TransitionController>().FadeIn();
	}

	void FadeOutTransition()
	{
		transition.GetComponent<TransitionController>().FadeOut();
	}

	void MakeHerFall()
	{
		player.GetComponent<PlayerController>().Fall();
	}

	void ActivateCinematic()
	{
		cinematicView.SetActive(true);
	}

	void DeactivateCinematic()
	{
		cinematicView.SetActive(false);
	}
}
