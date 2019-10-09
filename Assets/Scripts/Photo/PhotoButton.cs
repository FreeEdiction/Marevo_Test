using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PhotoButton : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject TakenImage;

    public GameObject PhotoMenu;
    public GameObject BottomMenu;
    
    public bool takingScreenshot = false;

    private Canvas _canvas;
    private Texture2D ss;
    private string name;
    private void Start()
    {
        _canvas = Canvas.GetComponent<Canvas>();
    }

    public void CaptureScreenshot()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
        _canvas.enabled = false;
        takingScreenshot = true;
        yield return new WaitForEndOfFrame();

        ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        name = string.Format("{0}_Capture{1}.png", Application.productName, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName + " Captures", name));
        takingScreenshot = false;
        _canvas.enabled = true;

        ShowScreenShot();
        ActivateBottomMenu();
    }


    private void ShowScreenShot()
    { 
        Sprite mySprite = Sprite.Create(ss, new Rect(0.0f, 0.0f, ss.width, ss.height), new Vector2(0.5f, 0.5f), 100.0f);
        TakenImage.GetComponent<Image>().sprite = mySprite;
        TakenImage.GetComponent<Image>().preserveAspect = true;
        TakenImage.GetComponent<Animator>().Play("ScreenShotPopUpAnim");
        TakenImage.transform.GetChild(0).GetComponent<Text>().text = name;
    }

    private void ActivateBottomMenu()
    {
        PhotoMenu.SetActive(false);
        BottomMenu.SetActive(true);
    }
}
