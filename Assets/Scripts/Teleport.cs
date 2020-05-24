using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject classTeleport;
    public GameObject natureTeleport;
    public GameObject toNatureText;
    public GameObject backFromNatureText;

    public void teleportToNature()
    {
        player.transform.position = 
            new Vector3(natureTeleport.transform.position.x,
            natureTeleport.transform.position.y + 1.5f,
            natureTeleport.transform.position.z);
    }

    public void teleportToClass()
    {
        player.transform.position = 
            new Vector3(classTeleport.transform.position.x,
            classTeleport.transform.position.y + 1.5f,
            classTeleport.transform.position.z);
    }
}
