using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text[] txtRank = new Text[5];

    // Start is called before the first frame update
    void Start()
    {
        for (int idx = 0; idx < 5; idx++)
        {
            txtRank[idx].text = FindObjectOfType<GameManager>().Rank[idx + 1].ToString(); //ƒ‰ƒ“ƒN•¶Žš
        }
    }
}
