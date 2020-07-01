using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class OpenChest : MonoBehaviour
{
    private Interactable interactable;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>(); 
    }

    private void OnHandHoverBegin(Hand hand){
        hand.ShowGrabHint();
    }

    private void OnHandHoverEnd(Hand hand){
        hand.HideGrabHint();
    }

    private void HandHoverUpdate(Hand hand){
        
        /*GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //grab the object
        if( grabType != GrabTypes.None){
            gameObject.transform.Rotate(-50* Time.deltaTime,0,0);
            hand.HoverLock(interactable);
        }

        else if(isGrabEnding)
        {
            gameObject.transform.Rotate(5,0,0);
            hand.HoverUnlock(interactable);
        }*/
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //grab the object
        if(interactable.attachedToHand == null && grabType != GrabTypes.None){
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
        }

        else if(isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }
}
