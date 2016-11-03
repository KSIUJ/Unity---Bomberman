using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerKeySet
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode putBomb;
}

public class MainController : MonoBehaviour
{
    public PlayerKeySet[] playersKeys;
}
