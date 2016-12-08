using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public int              playerNumber;
    public float            playerSpeed;

    public ColisionTrigger  colTriUp;
    public ColisionTrigger  colTriDown;
    public ColisionTrigger  colTriLeft;
    public ColisionTrigger  colTriRight;

	public GameObject 		bombermanModel;
	public GameObject 		bombermanBoy;
    public GameObject       bomb;

    private MainController  mainController;
    private bool            moving;
    private Vector3         target;
    private int             bombsOnMap;
    private int             bombsLimit;

    void Awake()
    {
        moving          = false;
        mainController  = GameObject.FindGameObjectWithTag(Tags.mainController).GetComponent<MainController>();
        bombsOnMap      = 0;
        bombsLimit      = 1;
    }

    void Update()
    {
        if (!moving)
            WaitForMove();
        else
            Moving();

        WaitForBomb();
    }

    void WaitForMove()
    {
        if (!colTriUp.bombTouch && !colTriUp.softWallTouch && !colTriUp.playerTouch && !colTriUp.hardWallTouch && Input.GetKey(mainController.playersKeys[playerNumber].up))
        {
            moving = true;
            target = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
			bombermanBoy.transform.localRotation = Quaternion.Euler (0f, 0f, 0f);
        }

        if (!colTriDown.bombTouch && !colTriDown.softWallTouch && !colTriDown.playerTouch && !colTriDown.hardWallTouch && Input.GetKey(mainController.playersKeys[playerNumber].down))
        {
            moving = true;
            target = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
			bombermanBoy.transform.rotation = Quaternion.Euler (0f, 180f, 0f);

        }

        if (!colTriLeft.bombTouch && !colTriLeft.softWallTouch && !colTriLeft.playerTouch && !colTriLeft.hardWallTouch && Input.GetKey(mainController.playersKeys[playerNumber].left))
        {
            moving = true;
            target = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
			bombermanBoy.transform.localRotation = Quaternion.Euler (0f, 270f, 0f);
        }

        if (!colTriRight.bombTouch && !colTriRight.softWallTouch && !colTriRight.playerTouch && !colTriRight.hardWallTouch && Input.GetKey(mainController.playersKeys[playerNumber].right))
        {
            moving = true;
            target = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
			bombermanBoy.transform.localRotation = Quaternion.Euler (0f, 90f, 0f);
        }
    }

    void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, playerSpeed * Time.deltaTime);

        if (transform.position == target)
            moving = false;
    }

    void WaitForBomb()
    {
        if(!moving && Input.GetKeyDown(mainController.playersKeys[playerNumber].putBomb) && bombsOnMap < bombsLimit)
        {
            GameObject bombObj = Instantiate(bomb, transform.position, Quaternion.identity) as GameObject;
            bombObj.GetComponent<Bomb>().SetUpOwner(gameObject, 1);
            ++bombsOnMap;
        }
    }

    public void ReturnOneBomb()
    {
        --bombsOnMap;
    }
}
