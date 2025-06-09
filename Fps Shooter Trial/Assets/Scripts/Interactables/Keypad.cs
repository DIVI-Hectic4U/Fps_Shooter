using UnityEngine;

public class Keypad : Interactable
{

    //This function is where we design our interaction using code
    protected override void Interact()
    {
        Debug.Log("Interacted with" + gameObject.name);
    }
}
