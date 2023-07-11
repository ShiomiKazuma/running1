using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPause
{
    //ジャンプ力調整
    [SerializeField] float jump_power;
    float _saveJumpPower;
    //走力調整
    [SerializeField] public float run_power;
    Rigidbody2D _rb;
    //二段ジャンプ判定用
    int _jumpCount = 0;
    //ゲームマネージャー
    GameManager gameManager;
    /// <summary>
    /// プレイヤーの状態
    /// </summary>
    public PlayerCondition _playerCondition;
    /// <summary>
    /// フォワードアイテム獲得時の前進距離
    /// </summary>
    [SerializeField] public float _forwardPower = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトのRigidbodyを取得
        _rb = GetComponent<Rigidbody2D>();
        //二段ジャンプ判定を初期化
        _jumpCount = 0;

        //ゲームマネージャーを取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _playerCondition = PlayerCondition.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerCondition == PlayerCondition.Normal) 
        { 
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        else if(_playerCondition == PlayerCondition.God)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if(Input.GetButtonDown("Jump") && _jumpCount < 2)
        {
            _rb.AddForce(transform.up * jump_power, ForceMode2D.Impulse);
            _jumpCount++;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
        }

        if(collision.gameObject.tag == "Destroy")
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }

    }

    public void Forward()
    {
        Transform transform = this.transform;

        Vector3 pos = transform.position;
        pos.x += _forwardPower;

        transform.position = pos;
    }

    public void Pause()
    {
        _saveJumpPower = jump_power;
        jump_power = 0;
    }

    public void Resume()
    {
        jump_power = _saveJumpPower;
    }

    public enum PlayerCondition
    {
        Normal,
        God,
    }

    
}
