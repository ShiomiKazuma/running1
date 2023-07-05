using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    float speed = 5;
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
