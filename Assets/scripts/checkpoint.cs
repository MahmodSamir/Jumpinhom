using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Sprite Before;
    public Sprite After;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointreached;
    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("done");

        if (other.tag == "player")
        {
            checkpointSpriteRenderer.sprite = After;
            //checkpointreached = true;
           // Debug.Log("done");
        }
    }
}
