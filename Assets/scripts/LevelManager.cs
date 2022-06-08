using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int coins;
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = coins + " :ﻱﺎﺷ ﺵﻮﺑﺮﺧ ";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Collect(int NoOfcoins)
    {
        coins += NoOfcoins;
        coinText.text = coins + " :ﻱﺎﺷ ﺵﻮﺑﺮﺧ ";
    }
}
