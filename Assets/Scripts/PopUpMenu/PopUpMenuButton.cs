using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMenuButton : MonoBehaviour
{
    public GameObject PopUpMenu;

    public Sprite openedMenu;
    public Sprite closedMenu;

    private bool opened = false;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = PopUpMenu.GetComponent<Animator>();
    }

    public void Click()
    {
        if (opened == false)
        {
            PopUp();
            opened = true;
        }
        else
        {
            PopDown();
            opened = false;
        }
    }

    private void PopUp()
    {
        anim.Play("PopUpMenuAnimation");
        SetSpriteToMainButton(openedMenu);
    }

    private void PopDown()
    {
        anim.Play("PopDownMenuAnim");
        SetSpriteToMainButton(closedMenu);
    }

    private void SetSpriteToMainButton(Sprite spr)
    {
        GetComponent<Image>().sprite = spr;
    }
    
    
}
