using UnityEngine;
using System.Collections;

public class ColisionTrigger : MonoBehaviour
{
    public bool hardWallTouch;
    public bool playerTouch;
    public bool softWallTouch;

    void Awake()
    {
        hardWallTouch   = false;
        playerTouch     = false;
        softWallTouch   = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == Tags.hardWall)
            hardWallTouch   = true;

        if (other.tag == Tags.player)
            playerTouch     = true;

        if (other.tag == Tags.softWall)
            softWallTouch = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.hardWall)
            hardWallTouch   = false;

        if (other.tag == Tags.player)
            playerTouch     = false;

        if (other.tag == Tags.softWall)
            softWallTouch = false;
    }
}
