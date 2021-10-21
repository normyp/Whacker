using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void IncrementScore()
    {
        score += 1;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
    }
}
