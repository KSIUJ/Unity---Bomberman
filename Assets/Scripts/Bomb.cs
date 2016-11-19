using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    private float   secToBoom;
    private Player  player;
    private float   resizer;

    void Awake()
    {
        secToBoom   = 3.0f;
        resizer     = 0f;
    }

    void Update()
    {
        secToBoom   -= Time.deltaTime;
        resizer     += Time.deltaTime;

        if (resizer >= 0.5f)
            Resize();

        if(secToBoom <= 0f)
            Boom();
    }

    void Boom()
    {
        player.ReturnOneBomb();
        Destroy(gameObject);
    }

    void Resize()
    {
        resizer = 0f;

        if (transform.localScale.x == 0.7f)
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        else
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    public void SetUpOwner(GameObject go)
    {
        player = go.GetComponent<Player>();
    }
}
