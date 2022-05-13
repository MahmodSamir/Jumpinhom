using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public GameObject soundCntrl;
    public Sprite audioOff;
    public Sprite audioOn;
    // Start is called before the first frame update
    void Start()
    {
        if(AudioListener.pause == true)
        {
            soundCntrl.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            soundCntrl.GetComponent<Image>().sprite = audioOn;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PP()
    {
        if(AudioListener.pause == true)
        {
            AudioListener.pause = false;
            soundCntrl.GetComponent<Image>().sprite = audioOn;
        }
        else
        {
            AudioListener.pause = true;
            soundCntrl.GetComponent<Image>().sprite = audioOff;
        }
    }
}
