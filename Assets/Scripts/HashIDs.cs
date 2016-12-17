using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int walkingBool;

    private void Awake()
    {
        walkingBool = Animator.StringToHash("Walking");
    }

}
