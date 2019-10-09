using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    public GameObject AudioController;
    public Sprite MuteSprite;
    public Sprite UnmuteSprite;
    
    private AudioSource audio;

    private bool muted = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = AudioController.GetComponent<AudioSource>();
    }

    public void Click()
    {
        if ((muted))
        {
            UnMute();
            muted = false;
        }
        else
        {
            Mute();
            muted = true;
        }
    }

    private void Mute()
    {
        audio.mute = true;
        SetSpriteToMainButton(MuteSprite);
    }

    private void UnMute()
    {
        audio.mute = false;
        SetSpriteToMainButton(UnmuteSprite);
    }
    
    private void SetSpriteToMainButton(Sprite spr)
    {
        GetComponent<Image>().sprite = spr;
    }
}
