using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    public Player _player;
    public Transform _playerTransform;
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
    }
    // �T�C�Y�𒲐�
    public void SetWall(Vector2 size)
    {
        transform.localScale = new Vector3(size.x, size.y, 1);
    }
    // ��ʊO�ɏo����j��
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

    //��ʊO�ɏo����f�X�g���C
    public abstract void OnCollisionEnter2D(Collision2D collision);
    //{
    //    if (collision.gameObject.tag == "Destroy")
    //    {
    //        Activate();
    //    }

    //    if (collision.gameObject.tag == "Destroy")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public abstract void Activate();
}
