using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    //スクロール速度
    [SerializeField] float _scrollSpeed;

    //リセットポジション
    [SerializeField] private float ResetPosition;

    //スタートポジション
    private Vector3 StartPosition;

    //オブジェクトのレンダラーを取得
    //SpriteRenderer _sprite = default;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //_sprite.transform.Translate(-1 * _scrollSpeed * Time.deltaTime, 0f, 0f);

        //// 背景画像がある程度左に動いたら、右に戻す
        //if (_sprite.transform.position.x < -1 * _sprite.bounds.size.x)
        //{
        //    _sprite.transform.Translate(_sprite.bounds.size.x * 2, 0f, 0f);
        //}

        transform.Translate(-1 * _scrollSpeed, 0, 0, Space.World);
        if (transform.position.x < ResetPosition)
            transform.position = StartPosition;
    }
}
