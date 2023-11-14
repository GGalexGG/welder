using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;

    bool maskTake = false;
    bool suitTake = false;
    bool glovesTake = false;
    public AudioSource source;
    public AudioClip glowsSound;
    public AudioClip suitSound;
    public TMP_Text maskText;
    public TMP_Text GlovesText;
    public TMP_Text suitText;
    private int countWeldings = 0;
    public ParticleSystem WelderEffect;

    


    private void Awake()
    {
        instace = this;
    }

    public void CountWelding()
    {
        countWeldings = countWeldings + 1;
        if (countWeldings > 2)
        {
            print(countWeldings);
        }
    }

    public void OnMaskTake(GameObject mask)
    {
        SteamVR_Fade.Start(Color.black, 0);
        SteamVR_Fade.Start(Color.clear, 3);
        maskTake = true;
        Destroy(mask);
        print("Mask-OFF");
        maskText.text = "Mask-ONN";
        maskText.color = Color.green;


    }
    public void OnSuitequip(GameObject suit)
    {
        suitTake = true;
        Destroy(suit);
        source.PlayOneShot(suitSound);
        print("Suit-OFF");
        suitText.text= "Suit-ONN";
        print(ReadyToWork());
        suitText.color = Color.green;
        // Проиграй звук
        
    }

    public void Onglows(GameObject glows)
    {
        glovesTake = true;
        source.PlayOneShot(glowsSound);
        Destroy(glows);
        print("Gloves-OFF");
        GlovesText.text = "Gloves-ONN";
        GlovesText.color = Color.green;

    }

    public int ReadyToWork()
    {
        if (maskTake && suitTake && glovesTake) return 0;
        else if (!maskTake) return 1;
        else if (!suitTake) return 2;
        else if (!glovesTake) return 3;
        return 4;
    }

    




}

