using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ImageTarget : MonoBehaviour, ITrackableEventHandler
{ 
    private TrackableBehaviour mTrackableBehaviour;

    public GameObject PhotoMenu;
    public GameObject Pointer;
    public GameObject BottomMenu;
    public Camera camera;
    public GameObject model;


    void Start()
        {
    		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
    			mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }
        
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                if (!BottomMenu.activeInHierarchy)
                {
                    PhotoMenu.SetActive(true);
                    Pointer.SetActive(false);
                    if (model != null)
                    {
                        model.transform.LookAt(camera.transform.position);
                        model.transform.rotation = Quaternion.Euler(0.0f, model.transform.eulerAngles.y, 0.0f);
                    }
                }
            }
            else
            {
                PhotoMenu.SetActive(false);
                Pointer.SetActive(true);
            }
        }	
}
