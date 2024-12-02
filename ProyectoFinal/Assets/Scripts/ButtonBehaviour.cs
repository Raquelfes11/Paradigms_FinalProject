using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public enum ButtonId
    {
        roomChangeButton, returnButton
    }

    public ButtonId thisButtonId;

    private DisplayImage currentDisplay;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayImage>();

    }

    void HideDisplay()
    {
        if (currentDisplay.CurrentState == DisplayImage.State.normal && thisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b,0);

            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
    }
}
