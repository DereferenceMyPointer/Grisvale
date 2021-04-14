using UnityEngine;

public abstract class Interactable : MonoBehaviour
{

    public abstract void Interact(PlayerController c);

    // behavior for when in range of an interacting object
    public abstract void DisplayNotif();
}