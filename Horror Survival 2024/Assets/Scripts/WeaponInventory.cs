using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInventory : MonoBehaviour
{
    public Sprite[] bigIcons;
    public Image bigIcon;
    public string[] titles;
    public Text title;
    public string[] descriptions;
    public Text description;

    private AudioSource audioPlayer;
    public AudioClip click, select;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();

        bigIcon.sprite = bigIcons[0];
        title.text = titles[0];
        description.text = descriptions[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseWeapon(int weaponNumber)
    {
        bigIcon.sprite = bigIcons[weaponNumber];
        title.text = titles[weaponNumber];
        description.text = descriptions[weaponNumber];
        audioPlayer.clip = click;
        audioPlayer.Play();
    }
}
