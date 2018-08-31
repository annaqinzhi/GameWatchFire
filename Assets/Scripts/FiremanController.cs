using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiremanController : MonoBehaviour {

    public List<Transform> positions = new List<Transform>();
    int currentPosition = 0;

	private void OnEnable()
	{
        InputController.OnLeftPressed += Input_OnLeftPressed;
        InputController.OnRightPressed += Input_OnRightPressed;
	}

	private void OnDisable()
	{
        InputController.OnLeftPressed -= Input_OnLeftPressed;
        InputController.OnRightPressed -= Input_OnRightPressed;
	}

	private void Start()
	{
        transform.position = positions[currentPosition].position;

    }

    void Input_OnLeftPressed() 
    {

        if (currentPosition > 0){
            currentPosition--;
            transform.position = positions[currentPosition].position;

        }
        Debug.Log("Left pressed!");
    }

    void Input_OnRightPressed()
    {
        if(currentPosition < positions.Count-1){
            currentPosition++;
            transform.position = positions[currentPosition].position;

            
        }
        Debug.Log("Right pressed!");
    }




}
