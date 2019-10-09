using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject TakenPhoto;

    public GameObject Pointer;
    public GameObject PhotoMenu;
    public GameObject BottomMenu;
    public void Click()
    {
        TakenPhoto.GetComponent<Animator>().Play("ScreenShotPopDownAnim");
        BottomMenu.SetActive(false);
        if(!Pointer.activeInHierarchy)
            PhotoMenu.SetActive(true);
    }
}
