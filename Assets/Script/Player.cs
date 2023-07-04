using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //ジャンプ力調整
    [SerializeField] float jump_power;
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
    PlayerCondition _playerCondition;
    /// <summary>
    /// フォワードアイテム獲得時の前進距離
    /// </summary>
    [SerializeField] float _forwardPower = 1.0f;
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
        if(Input.GetButtonDown("Jump") && _jumpCount < 2)
        {
            _rb.AddForce(transform.up * jump_power, ForceMode2D.Impulse);
            _jumpCount++;
        }
    }

    private void FixedUpdate()
    {
           //_rb.AddForce(transform.right * run_power, ForceMode2D.Force);
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

        if(collision.gameObject.tag == "ItemGod")
        {
            _playerCondition = PlayerCondition.God;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Enemy" && _playerCondition == PlayerCondition.God)
        {
            Destroy(collision.gameObject);
            _playerCondition = PlayerCondition.Normal;
        }
    }

    public void Forward()
    {
        Transform transform = this.transform;

        Vector3 pos = transform.position;
        pos.x += _forwardPower;

        transform.position = pos;
    }

    enum PlayerCondition
    {
        Normal,
        God,
    }
}
