using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int              playerNumber;
    public float            playerSpeed;

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
        if (Input.GetKeyDown(mainController.playersKeys[playerNumber].up))
        {
            moving = true;
            target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
        }

        if (Input.GetKeyDown(mainController.playersKeys[playerNumber].down))
        {
            moving = true;
            target = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
        }

        if (Input.GetKeyDown(mainController.playersKeys[playerNumber].left))
        {
            moving = true;
            target = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(mainController.playersKeys[playerNumber].right))
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
