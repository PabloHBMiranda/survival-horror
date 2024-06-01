using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public enum weaponSelect
    {
        knife,
        cleaver,
        bat,
        axe,
        pistol,
        shotgun,
        sprayCan,
        bottle
    }

    public weaponSelect chosenWeapon;
    public GameObject[] weapons;
    private Animator anim;
    private AudioSource audioPlayer;
    public AudioClip[] weaponSounds;
    private int currentWeaponID;

    // Start is called before the first frame update
    void Start()
    {
        SaveScript.weaponID = (int)chosenWeapon;
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
        ChangeWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.weaponID != currentWeaponID)
        {
            ChangeWeapons();
        }

        if (SaveScript.inventoryOpen == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Attack");
                audioPlayer.clip = weaponSounds[SaveScript.weaponID];
                audioPlayer.Play();
            }
        }
    }

    private void ChangeWeapons()
    {
        foreach(GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[SaveScript.weaponID].SetActive(true);
        chosenWeapon = (weaponSelect)SaveScript.weaponID;
        anim.SetInteger("WeaponID", SaveScript.weaponID);
        anim.SetBool("weaponChanged", true);
        currentWeaponID = SaveScript.weaponID;

        Move();
        StartCoroutine(WeaponReset());
    }

    private void Move()
    {
        switch (chosenWeapon)
        {
            case weaponSelect.shotgun:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.46f);
                break;

            default:
                transform.localPosition = new Vector3(0.02f, -0.193f, 0.66f);
                break;
        }
    }

    IEnumerator WeaponReset()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("weaponChanged", false);
    }
}
