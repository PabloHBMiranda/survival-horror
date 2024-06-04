using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupsScript : MonoBehaviour
{
    private RaycastHit hit;
    public LayerMask excludeLayers;
    public GameObject pickupPanel;
    public float pickupDisplayDistance = 3;

    public Image mainImage;
    public Sprite[] weaponIcons;
    public Sprite[] itemIcons;
    public Sprite[] ammoIcons;

    public Text mainTitle;
    public string[] weaponTitles;
    public string[] itemTitles;
    public string[] ammoTitles;

    private int objID = 0;
    private AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        pickupPanel.SetActive(false);
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 30, ~excludeLayers))
        {
            if(Vector3.Distance(transform.position, hit.transform.position) < pickupDisplayDistance)
            {
                if (hit.transform.gameObject.CompareTag("weapon"))
                {
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<WeaponType>().chosenWeapon;
                    mainImage.sprite = weaponIcons[objID];
                    mainTitle.text = weaponTitles[objID];

                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.weaponsPickedUp[objID] = true;
                        SaveScript.weaponAmts[objID]++;
                        audioPlayer.Play();
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                } else if (hit.transform.gameObject.CompareTag("item")){
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<ItemsType>().chooseItem;
                    mainImage.sprite = itemIcons[objID];
                    mainTitle.text = itemTitles[objID];

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.itemsPickedUp[objID] = true;
                        SaveScript.itemAmts[objID]++;
                        audioPlayer.Play();
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }else if (hit.transform.gameObject.CompareTag("ammo")){
                    pickupPanel.SetActive(true);
                    objID = (int)hit.transform.gameObject.GetComponent<AmmoType>().chooseAmmo;
                    mainImage.sprite = ammoIcons[objID];
                    mainTitle.text = ammoTitles[objID];

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SaveScript.itemsPickedUp[objID] = true;
                        SaveScript.ammoAmts[objID]++;
                        audioPlayer.Play();
                        Destroy(hit.transform.gameObject, 0.2f);
                    }
                }
            }
            else
            {
                pickupPanel.SetActive(false);
            }
        }
    }
}
