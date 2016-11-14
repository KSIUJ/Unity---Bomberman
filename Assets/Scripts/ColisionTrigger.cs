using UnityEngine;
using System.Collections;

public class ColisionTrigger : MonoBehaviour
{
    public bool hardWallTouch;
    public bool playerTouch;

    void Awake()
    {
        hardWallTouch   = false;
        playerTouch     = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.hardWall)
            hardWallTouch   = true;

        if (other.tag == Tags.player)
            playerTouch     = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.hardWall)
            hardWallTouch   = false;

        if (other.tag == Tags.player)
            playerTouch     = false;
    }
}
