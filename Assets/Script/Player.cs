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
    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトのRigidbodyを取得
        _rb = GetComponent<Rigidbody2D>();
        //二段ジャンプ判定を初期化
        _jumpCount = 0;

        //ゲームマネージャーを取得
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
    }
}
