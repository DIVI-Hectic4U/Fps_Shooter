using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    //message displayed whenever player is looking at an object
    public string promptMessage;

    //this function will be called by our player.
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //we won't have any code written in this function
        // this is a template function to be overridden by our subclasses.

    }
}
