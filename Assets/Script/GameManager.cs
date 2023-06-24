using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //オブジェクト
    GameObject gameOver;
    Text _gameover;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("GameOverText");
        _gameover = gameOver.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("ゲームオーバー");
        Time.timeScale = 0f;
        _gameover.text = "GameOver"; 
    }
}
