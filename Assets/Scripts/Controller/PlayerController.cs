﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float[] listMoveSpeed = { 1, 5, 4 }, listRunning = { 1, 10, 9};
	public float moveSpeed;
	public int status; //   0 define cut, 1 define base, 2 define mutated
	public int stamina;
	public GameObject shadow;
	
	private bool run;
	public bool stopPlayer;
	private Animator anim;
	private bool playerMoving;
	private Vector2 lastMove;

	// Start is called before the first frame update
    void Start()
    {
		shadow.SetActive(true);
		anim = GetComponent<Animator>();
		playerMoving = false;
	}

    // Update is called once per frame
    void Update()
    {
		anim.SetInteger("Status", status);
		if (!stopPlayer) Move();
		else playerMoving = false;
		//Debug.Log(status + " " + playerMoving + " " + lastMove.x + " " + lastMove.y);

	}

	public int CharacterStatus
	{
		get => status;
		set => status = value;
	}

	public bool CharacterStop
	{
		get => stopPlayer;
		set
		{
			stopPlayer = value;
			if (value == true) anim.SetBool("PlayerMoving", value: false);
		}	
	}

	public bool Run
	{
		get => run;
		set
		{
			if (value == true) moveSpeed = listRunning[status];
			else moveSpeed = listMoveSpeed[status];
			run = value;
		}
	}

	private void Move()
	{
		playerMoving = false;
		Run = Input.GetKey(KeyCode.LeftShift) ? true : false;

		if (status == 0)
		{
			if (Input.GetAxisRaw("Vertical") < -0.5f)
			{
				transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				playerMoving = true;
				lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
			}
			if (Input.GetAxisRaw("Vertical") > 0.5f)
			{
				Fungus.Flowchart.BroadcastFungusMessage("noUp");
				Debug.Log("Up button clicked");
			}
			if (Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				Fungus.Flowchart.BroadcastFungusMessage("noLeft");
				Debug.Log("Left button clicked");
			}
		}
		else
		{
			if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				playerMoving = true;
				lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
			}
			if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
			{
				transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				playerMoving = true;
				lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
			}
		}
		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}

	public void Fall()
	{
		anim.SetBool("Death", true);
		shadow.SetActive(false);
		transform.Translate(new Vector3(0f, -0.1f, 0f));
	}


}
