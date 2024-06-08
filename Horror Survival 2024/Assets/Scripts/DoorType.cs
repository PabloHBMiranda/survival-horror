using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorType : MonoBehaviour
{
    public enum typeOfDoor
    {
        cabinet,
        house,
        cabin
    }
    public typeOfDoor chooseDoor;
    public bool opened = false;
    public bool locked = false;
    [HideInInspector]
    public string message = "Pressione E para abrir a porta";
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (opened == true)
        {
            anim.SetTrigger("Open");
            message = "Pressione E para fechar a porta";
        }
    }
}