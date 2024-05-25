using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookMode : MonoBehaviour
{
    private PostProcessVolume vol;
    public PostProcessProfile standard;
    public PostProcessProfile nightVision;
    public GameObject nightVisionOverlay;
    private bool nightVisionOn = false;

    // Start is called before the first frame update
    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        nightVisionOverlay.SetActive(false);
        vol.profile = standard;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N)  )
        {
            nightVisionOn = !nightVisionOn;
            if(nightVisionOn)
            {
                vol.profile = nightVision;
                nightVisionOverlay.SetActive(true);
            }
            else
            {
                vol.profile = standard;
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOverlay.SetActive(false);
            }
        }
    }
}
