using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class land : MonoBehaviour
{
    public GameObject platformprefab;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();
        for(int i=0; i<1000;i++)
        {
            SpawnerPosition.x = Random.Range(-10f, 8f);
            SpawnerPosition.y += Random.Range(2f, 3f);
            Instantiate(platformprefab, SpawnerPosition, Quaternion.identity);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
