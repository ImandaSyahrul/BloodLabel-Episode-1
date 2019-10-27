using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    // Start is called before the first frame update
    // GameObject player;
    PlayerController playerController;
    private Slider staminaBar;
    void Start()
    {
        staminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null) staminaBar.value = playerController.updatedStamina;
        else Debug.Log("NULL");
    }
}
