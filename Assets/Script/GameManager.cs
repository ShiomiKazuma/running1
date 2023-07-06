using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //オブジェクト
    [SerializeField] GameObject gameOverUi;
    //Text _gameover;

    GameObject time;
    Text time_tx;
    Text _score;

    float _time;
    // Start is called before the first frame update
    void Start()
    {
        _time = 0;

        time = GameObject.Find("Time");
        time_tx = time.GetComponent<Text>();

        //gameOverUi = GameObject.Find("GameOverUI").GetComponent<GameObject>();
        //_gameover = gameOver.GetComponent<Text>();

        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        time_tx.text = "Time:" + _time.ToString("F2");
    }

    public void GameOver()
    {
        Debug.Log("ゲームオーバー");
        Time.timeScale = 0f;
        gameOverUi.SetActive(true);

        _score = GameObject.Find("Score").GetComponent<Text>();
        _score.text = _time.ToString("F2") + "ｍ";

    }
}
