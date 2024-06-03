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

    // Start is called before the first frame update
    void Start()
    {
        weaponsPickedUp[0]= true;
        weaponsPickedUp[1] = true;
        weaponsPickedUp[6] = true;
        weaponsPickedUp[7] = true;

        itemsPickedUp[0] = true;
        itemsPickedUp[1] = true;
        itemsPickedUp[2] = true;
        itemsPickedUp[3] = true;
        itemsPickedUp[9] = true;
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
