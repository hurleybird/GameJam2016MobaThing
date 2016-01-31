using UnityEngine;
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
        var pointer = new PointerEventData(EventSystem.current); // pointer event for Execute
        ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerEnterHandler);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (waitTime > 0f)
            waitTime -= Time.deltaTime;
        else
        {
            var pointer = new PointerEventData(EventSystem.current); // pointer event for Execute

            if (!buttons[Index].IsInteractable())
            {
                SelectNextButton(true);
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerEnterHandler);
            }

            if (Input.GetAxis(prefix + "Vertical") > 0.9f)
            {
                SelectNextButton(false);
                waitTime = coolDown;
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerEnterHandler);
            }
            else if (Input.GetAxis(prefix + "Vertical") < -0.9f)
            {
                SelectNextButton(true);
                waitTime = coolDown;
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerEnterHandler);
            }

            PointerExitButtons(pointer);

            //if (Input.GetButtonDown(prefix + "Fire1")) // down: press
            //ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerDownHandler);

            if (Input.GetButtonUp(prefix + "Fire1")) // up: release and activate
            {
                //ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerUpHandler);
                ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.submitHandler);
                //ExecuteEvents.Execute(buttons[Index].gameObject, pointer, ExecuteEvents.pointerExitHandler);
                waitTime = coolDown;
            }
        }
	}

    private void SelectNextButton(bool forward)
    {
        int add = 1;
        if (!forward)
            add = -1;
        for (int i = 0; i < 3; i++)
        {
            Index += add;
            if (buttons[Index].IsInteractable())
                break;
        }
    }

    private void PointerExitButtons(PointerEventData pointer)
    {
        foreach (Button button in buttons)
        {
            if (button != buttons[Index])
                ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerExitHandler);
        }
    }
}
