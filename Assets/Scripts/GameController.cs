using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public int          lvlSize;
    public GameObject   hardWall;
    public GameObject   floor;

    void Awake()
    {
        lvlSize = 5;
    }

    void Start()
    {
        CreateLvl();
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
}
