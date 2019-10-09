using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject InfoPanel;

    private Animator anim;
    private bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = InfoPanel.GetComponent<Animator>();
    }

    public void PopUp()
    {
        opened = true;
        anim.Play("InfoPanelPopUpAnim");
    }

    public void PopDown()
    {
        opened = false;
        anim.Play("InfoPanelPopDownAnim");
    }
}
