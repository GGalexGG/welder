using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weldingPlace : MonoBehaviour
{
    public bool active = false;
   public void Weld()
   {
        active = true;
        transform.GetComponent<MeshRenderer>().enabled = true;
        GameManager.instace.CountWelding();
   }
}
