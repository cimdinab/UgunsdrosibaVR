using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject classTeleport;
    public GameObject natureTeleport;
    public GameObject daba;
    public GameObject backToClass;

    public void teleportToNature()
    {
            player.transform.position = new Vector3(natureTeleport.transform.position.x,natureTeleport.transform.position.y + 1.5f, natureTeleport.transform.position.z);
        //player.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
    }

    public void teleportToClass()
    {
        //player.transform.position = new Vector3(-1.5f, 1.5f, -3.5f);
        player.transform.position = new Vector3(classTeleport.transform.position.x, classTeleport.transform.position.y + 1.5f, classTeleport.transform.position.z);
    }
}
