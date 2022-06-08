using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public LevelManager gameLevelManager;
    public int CoinValue;
    public AudioClip sof;
    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            gameLevelManager.Collect(CoinValue);
            AudioSource.PlayClipAtPoint(sof, transform.position);
            Destroy(gameObject);
        }
    }
}
