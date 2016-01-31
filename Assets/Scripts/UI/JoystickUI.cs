﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class JoystickUI : MonoBehaviour {

    [SerializeField]
    private Color unselectColor;
    [SerializeField]
    private Color selectColor;
    [SerializeField]
    private List<Button> buttons = new List<Button>();
    private float coolDown = 0.2f;
    private float waitTime = 0f;
    [SerializeField]
    private string prefix = "";

    private int _index;
    private int Index
    {
        get { return _index; }
        set { _index = (int)Modulo.Mod(value, 3); }
    }


	// Use this for initialization
	void Start () {
        Index = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (waitTime > 0f)
            waitTime -= Time.deltaTime;
        else
        {
            //buttons.ForEach(x => x.GetComponent<Image>().color = unselectColor);
            if (Input.GetAxis(prefix + "Vertical") > 0.9f)
            {
                Index--;
                waitTime = coolDown;
            }
            else if (Input.GetAxis(prefix + "Vertical") < -0.9f)
            {
                Index++;
                waitTime = coolDown;
            }

            //buttons[Index].GetComponent<Image>().color = selectColor;

            var pointer = new PointerEventData(EventSystem.current); // pointer event for Execute
            ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerEnterHandler);

            if (Input.GetButtonDown(prefix + "Fire1")) // down: press
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerDownHandler);

            if (Input.GetButtonUp(prefix + "Fire1")) // up: release and activate
            {
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerUpHandler);
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerExitHandler);
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.submitHandler);
            }


           

            if (Input.GetButtonDown(prefix + "Fire1")) // down: press
            {
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerDownHandler);
            }
            if (Input.GetButtonUp(prefix + "Fire1")) // up: release
            {
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerUpHandler);
            }
        }
	}
}