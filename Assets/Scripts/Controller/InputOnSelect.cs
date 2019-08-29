using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputOnSelect : MonoBehaviour
{
	public EventSystem eventSystem;
	public GameObject selectedObject;

	private bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") !=0 && !isSelected)
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			isSelected = true;
		}
    }

	private void OnDisable()
	{
		isSelected = false;
	}
}
