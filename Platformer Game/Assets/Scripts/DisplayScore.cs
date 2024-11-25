using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public GameManager gm;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetScore()); 
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score " + gm.score;

    }
    IEnumerator GetScore()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("score appears");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
}
