using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public int option;

    public void Press()
    {
        DialogueManager.Instance.SelectOption(option);
    }
}
