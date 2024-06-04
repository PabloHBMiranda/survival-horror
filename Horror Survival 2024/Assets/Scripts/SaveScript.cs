using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SaveScript : MonoBehaviour
{
    public static bool inventoryOpen = false;
    public static int weaponID = 0;
    public static bool[] weaponsPickedUp = new bool[8];
    public static int itemID = 0;
    public static bool[] itemsPickedUp = new bool[13];
    public static int[] weaponAmts = new int[8];
    public static int[] itemAmts = new int[13];

    // Start is called before the first frame update
    void Start()
    {
        weaponsPickedUp[0]= true;
        weaponAmts[0] = 1;

        itemsPickedUp[0] = true;
        itemsPickedUp[1] = true;
        itemAmts[0] = 1;
        itemAmts[1] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(FirstPersonController.inventorySwitchedOn == true)
        {
            inventoryOpen = true;
        }
        else
        {
            inventoryOpen = false;
        }
    }
}
