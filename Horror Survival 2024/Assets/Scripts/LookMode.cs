using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookMode : MonoBehaviour
{
    private PostProcessVolume vol;
    public PostProcessProfile standard;
    public PostProcessProfile nightVision;
    public PostProcessProfile invetory;
    public GameObject nightVisionOverlay;
    public GameObject flashLightOverlay;
    private Light flashLight;
    private bool nightVisionOn = false;
    private bool flashLightOn = false;
    private bool invetoryOn = false;

    // Start is called before the first frame update
    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        flashLight = GameObject.Find("FlashLight").GetComponent<Light>();
        flashLight.enabled = false;
        nightVisionOverlay.SetActive(false);
        flashLightOverlay.SetActive(false);
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
                nightVisionOverlay.GetComponent<NightVisionScript>().StopDrain();
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOn = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if(flashLightOverlay != null)
            {
                flashLightOverlay.SetActive(!flashLightOn);
                flashLight.enabled = !flashLightOn;
                flashLightOverlay.GetComponent<FlashLightScript>().StopDrain(flashLightOn);
                flashLightOn = !flashLightOn;
                if(!flashLightOn)
                {
                    FlashLightSwitchOff();
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            if(invetoryOn == false)
            {
                vol.profile = invetory;
                invetoryOn = true;
            }
            else if(invetoryOn == true)
            {
                vol.profile = standard;
                invetoryOn = false;
            }
        }

        if (nightVisionOn == true)
        {
            NightVisionOff();
        }

        if (flashLightOn == true)
        {
            FlashLightSwitchOff();
        }
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

    private void FlashLightSwitchOff()
    {
        if (flashLightOverlay.GetComponent<FlashLightScript>().batteryPower <= 0)
        {
            flashLightOverlay.SetActive(false);
            flashLight.enabled = false;
            flashLightOverlay.GetComponent<FlashLightScript>().StopDrain(false);
            flashLightOn = false;
        }
    }
}
