using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Run : MonoBehaviour
{

    public AudioClip runClip;

    public AudioClip defaultClip;

    public GameObject AudioController;
    public GameObject container;

    private AudioSource audio;
    private Animator anim;
    private BoxCollider collider;
    public Transform parent;

    private bool run = false;
    
    // Start is called before the first frame update
    void Start()
    {
        audio = AudioController.GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            
            audio.clip = defaultClip;
            audio.enabled = false;
            audio.enabled = true;
            collider.enabled = true;
            audio.loop = true;
            anim.enabled = false;
            run = false;
            SetToDefautPosition();
        }
        
    }
    void OnMouseDown()
    {
        run = true;
        audio.clip = runClip;
        audio.enabled = false;
        audio.enabled = true;
        collider.enabled = false;
        audio.loop = false;
        anim.enabled = true;
        
    }

    private void SetToDefautPosition()
    {
        GameObject newModel = Instantiate(container.transform.GetChild(0).gameObject, parent);
        newModel.transform.rotation = parent.GetChild(0).rotation;
        newModel.GetComponent<Run>().AudioController = AudioController;
        newModel.GetComponent<Run>().container = container;
        newModel.GetComponent<Run>().parent = parent;
        parent.gameObject.GetComponent<ImageTarget>().model = newModel;
        Destroy(parent.GetChild(0).gameObject);
    }
}
