using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsScript : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask excludeLayers;

    private int objID = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 30, ~excludeLayers))
        {
            if(hit.transform.gameObject.CompareTag("weapon"))
            {
                objID = (int)hit.transform.gameObject.GetComponent<WeaponType>().chosenWeapon;
                Debug.Log("Pickup: " + objID);
            }
        }
    }
}
