using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;

    public Scene currentScene;
    public TMP_Text finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "End Screen 1")
        {
            Debug.Log("in end screen");
            finalScoreText.text = "Score: " + score;
        }
    }
}
