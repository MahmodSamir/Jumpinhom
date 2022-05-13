using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public float offset;
    private Vector3 playerpsition;
    public float offsetsmothing;
    public PlayerControll1 thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMove;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerControll1>();
        lastPlayerPosition = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = new Vector3(  transform.position.x, player.transform.position.y, transform.position.z);
        /* if(player.transform.localScale.x>0f)
         {
             playerpsition = new Vector3(playerpsition.y, playerpsition.x+offset, playerpsition.z);
         }
         else { playerpsition = new Vector3(playerpsition.y, playerpsition.x-offset, playerpsition.z); }*/
        // transform.position = Vector3.Lerp(transform.position, playerpsition, offsetsmothing * Time.deltaTime);
        distanceToMove = (thePlayer.transform.position.y - lastPlayerPosition.y);

        if (distanceToMove > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);

            lastPlayerPosition = thePlayer.transform.position;
        }
    }
}
 