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
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (nightVisionOn == false)
            {
                vol.profile = nightVision;
                nightVisionOverlay.SetActive(true);
                nightVisionOn = true;
                NightVisionOff();
            }
            else if (nightVisionOn == true)
            {
                vol.profile = standard;
                nightVisionOverlay.SetActive(false);
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOn = false;
            }
        }

        if (nightVisionOn == true)
        {
            NightVisionOff();
        }
    }

    public bool IsNightVisionOn()
    {
        return nightVisionOn;
    }

    private void NightVisionOff()
    {
        if (nightVisionOverlay.GetComponent<NightVisionScript>().batteryPower <= 0)
        {
            vol.profile = standard;
            nightVisionOverlay.SetActive(false);
            this.gameObject.GetComponent<Camera>().fieldOfView = 60;
            nightVisionOn = false;
        }
    }
}
