using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript1 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpspeed = 5f;
    private float moavement = 0f;
    private Rigidbody2D rigidBody;
    private bool facinRight = true;
    public Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moavement = Input.GetAxis("Horizontal");
        if (moavement > 0)
        {
            rigidBody.velocity = new Vector2(moavement * speed, rigidBody.velocity.y);
        }
        else if(moavement<0)
        {
            rigidBody.velocity = new Vector2(moavement * speed, rigidBody.velocity.y);

        }
        else { rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);}
        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpspeed);
        }
        if(facinRight==false && moavement > 0)
        {
            flip();
        }
        else if (facinRight ==true && moavement < 0)
        {
            flip();
        }

    }
    void flip()
    {
        facinRight = !facinRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "falldetector") {
            transform.position = respawnPoint;
            SceneManager.LoadScene("GameOver");
        }
        if(other.tag == "checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }
}
