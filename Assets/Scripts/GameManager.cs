using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool maskTake = false;
    bool suitTake = false;
    bool glowsTake = false;
    public TMP_Text text;
    public AudioSource source;
    public AudioClip glowsSound;
    public AudioClip suitSound;

    public void OnMaskTake(GameObject mask)
    {
        SteamVR_Fade.Start(Color.black, 0);
        SteamVR_Fade.Start(Color.clear, 3);
        maskTake = true;
        Destroy(mask);
        print("Mask on");


    }
    public void OnSuitequip(GameObject suit)
    {
        suitTake = true;
        Destroy(suit);
        source.PlayOneShot(suitSound);
        print("suit on");
        text.text= "suitOn";
        print(ReadyToWork());
        // Проиграй звук
        
    }

    public void Onglows(GameObject glows)
    {
        glowsTake = true;
        source.PlayOneShot(glowsSound);
        Destroy(glows);
        //text 
        
    }

    public int ReadyToWork()
    {
        if (maskTake && suitTake && glowsTake) return 0;
        else if (!maskTake) return 1;
        else if (!suitTake) return 2;
        else if (!glowsTake) return 3;
        return 4;

    }
}
