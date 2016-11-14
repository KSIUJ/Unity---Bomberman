using UnityEngine;
using System.Collections;

//Zmienilem GetKeyDown na GetKey
//Zienilem predkosc na 3

public class Player : MonoBehaviour
{
    public int              playerNumber;
    public float            playerSpeed;

    public ColisionTrigger  colTriUp;
    public ColisionTrigger  colTriDown;
    public ColisionTrigger  colTriLeft;
    public ColisionTrigger  colTriRight;

    private MainController  mainController;
    private bool            moving;
    private Vector3         target;

    void Awake()
    {
        moving = false;
        mainController = GameObject.FindGameObjectWithTag(Tags.mainController).GetComponent<MainController>();
    }

    void Update()
    {
        if (!moving)
            WaitForMove();
        else
            Moving();
    }

    void WaitForMove()
    {
        if (!colTriUp.playerTouch && !colTriUp.hardWallTouch && Input.GetKey(mainController.playersKeys[playerNumber].up))
        {
            moving = true;
            target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
        }

        if (!colTriDown.playerTouch && !colTriDown.hardWallTouch && Input.GetKey(mainController.playersKeys[playerNumber].down))
        {
            moving = true;
            target = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
        }

        if (!colTriLeft.playerTouch && !colTriLeft.hardWallTouch && Input.GetKey(mainController.playersKeys[playerNumber].left))
        {
            moving = true;
            target = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
        }

        if (!colTriRight.playerTouch && !colTriRight.hardWallTouch && Input.GetKey(mainController.playersKeys[playerNumber].right))
        {
            moving = true;
            target = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        }
    }

    void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, playerSpeed * Time.deltaTime);

        if (transform.position == target)
            moving = false;
    }
}
