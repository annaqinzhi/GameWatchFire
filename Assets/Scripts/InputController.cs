using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public delegate void ButtonPressed();
    public static event ButtonPressed OnLeftPressed;
    public static event ButtonPressed OnRightPressed;

    public float buttonMargin = 2;

    void Update()
    {


#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Mouse position: " + pos);

            if (OnLeftPressed != null && pos.x < -buttonMargin)
                OnLeftPressed();
            else if (OnRightPressed != null && pos.x > buttonMargin)
                OnRightPressed();


        }

        foreach(Touch touch in Input.touches ){
            if (touch.phase == TouchPhase.Began) {

                Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                Debug.Log("Mouse position: " + pos);

                if (OnLeftPressed != null && pos.x < -buttonMargin)
                    OnLeftPressed();
                else if (OnRightPressed != null && pos.x > buttonMargin)
                    OnRightPressed();

            }
        }

        //if(Input.touchCount > 0 ){
        //    if(Input.GetTouch(0).phase == TouchPhase.Began){
        //        //en ny touch detekterad

        //    }
        //}

        //if (Input.touchCount > 1)
        //{
        //    if (Input.GetTouch(1).phase == TouchPhase.Began)
        //    {
        //        //en ny touch detekterad

        //    }
        //}


#else



#endif


    }
}
