using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloods : MonoBehaviour
{
	public GameObject player;
	public GameObject[] bloods;
	
	private int counter;
	private Animator anim;
	// Start is called before the first frame update
    void Start()
    {
		foreach(GameObject blood in bloods)
		{
			blood.SetActive(false);
		}
		counter = 0;
		anim = bloods[7].GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if(counter < bloods.Length)
		{
			if (player.transform.position.y < bloods[counter].transform.position.y)
			{
				bloods[counter].SetActive(true);
				counter++;
			}
		}
		
    }

}
