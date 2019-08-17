using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressData 
{
	public GameObject player;
	public GameObject transition;
	public int scenarioCounter;

	public ProgressData(Prologue prologue)
	{
		player = prologue.player;
		transition = prologue.transition;
		scenarioCounter = prologue.scenarioCounter;
	}
}
