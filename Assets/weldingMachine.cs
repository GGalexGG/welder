using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class weldingMachine : MonoBehaviour

{
     Interactable interactable;
    public SteamVR_Action_Boolean fireAction;
    public Transform muzzle;
    public ParticleSystem WelderEffect;

   


    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    
    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;
            if (fireAction[hand].state)
            {
                RaycastHit hit;
                if (Physics.Raycast(muzzle.position, muzzle.forward, out hit, 20))
                {
                    weldingPlace welding = hit.transform.GetComponent<weldingPlace>();

                    if (welding == null) return;

                    //code is weldingPlace

                    if (!welding.active)
                    {
                        welding.Weld();
                        WelderEffect.Play();
                    }

                    WelderEffect.Play();


                }
            }


            

        }
    }
}









