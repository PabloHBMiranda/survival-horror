using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightScript : MonoBehaviour
{

    private Image batteryChunks;
    public float batteryPower = 1.0f;
    public float drainTime = 2;

    private LookMode lookMode;
    private float lastDrainTime;

    // Start is called before the first frame update
    void Start()
    {
        batteryChunks = GameObject.Find("FLBatteryChunks").GetComponent<Image>();
        InvokeRepeating("FLBatteryDrain", drainTime, drainTime);
    }

    // Update is called once per frame
    void Update()
    {
        batteryChunks.fillAmount = batteryPower;
    }

    private void FLBatteryDrain()
    {
        if (batteryPower > 0.0f)
            batteryPower -= 0.25f;

        if (lookMode != null && lookMode.IsNightVisionOn() && Time.time >= lastDrainTime + drainTime)
        {
            if (batteryPower > 0.0f)
                batteryPower -= 0.25f;
        }
    }
}
