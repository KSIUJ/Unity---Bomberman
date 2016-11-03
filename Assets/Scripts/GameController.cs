using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public int          lvlSize;
    public int          playersNumber;
    public GameObject   hardWall;
    public GameObject   floor;
    public GameObject   player;

    void Awake()
    {
        lvlSize         = 0;
        playersNumber   = 4;
    }

    void Start()
    {
        CreateLvl();
        SpanPlayers();
    }

    void CreateLvl()
    {
        for(int i = 0; i < lvlSize; ++i)
        {
            Instantiate(hardWall, new Vector3(14f + i, 0f, 6f), Quaternion.identity);
            Instantiate(hardWall, new Vector3(14f + i, 0f, -6f), Quaternion.identity);
            Instantiate(floor, new Vector3(14f + i, -0.5f, 0f), Quaternion.identity);

            if(i % 2 == 0)
            {
                for(int z = 4; z > -5; z -= 2)
                    Instantiate(hardWall, new Vector3(14f + i, 0f, z), Quaternion.identity);
            }
        }

        float x = lvlSize + 14;

        for(int i = 0; i < 13; ++i)
        {
            Instantiate(hardWall, new Vector3(x, 0f, 6f - i), Quaternion.identity);
        }
    }

    void SpanPlayers()
    {
        if (playersNumber >= 1)
        {
            GameObject playerObj = Instantiate(player, new Vector3(1f, 0f, 5f), Quaternion.identity) as GameObject;
            playerObj.GetComponent<MeshRenderer>().material.color = Color.red;
            playerObj.GetComponent<Player>().playerNumber = 0;
        }
            

        if (playersNumber >= 2)
        {
            GameObject playerObj = Instantiate(player, new Vector3(1f, 0f, -5f), Quaternion.identity) as GameObject;
            playerObj.GetComponent<MeshRenderer>().material.color = Color.blue;
            playerObj.GetComponent<Player>().playerNumber = 1;
        }
            

        if (playersNumber >= 3)
        {
            GameObject playerObj = Instantiate(player, new Vector3(13f + lvlSize, 0f, 5f), Quaternion.identity) as GameObject;
            playerObj.GetComponent<MeshRenderer>().material.color = Color.green;
            playerObj.GetComponent<Player>().playerNumber = 2;
        }
            

        if (playersNumber >= 4)
        {
            GameObject playerObj = Instantiate(player, new Vector3(13f + lvlSize, 0f, -5f), Quaternion.identity) as GameObject;
            playerObj.GetComponent<MeshRenderer>().material.color = Color.yellow;
            playerObj.GetComponent<Player>().playerNumber = 3;
        }
            
    }
}
