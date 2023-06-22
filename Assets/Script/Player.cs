using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�W�����v�͒���
    [SerializeField] float jump_power;
    Rigidbody2D _rb;
    //��i�W�����v����p
    int _jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g��Rigidbody���擾
        _rb = GetComponent<Rigidbody2D>();
        //��i�W�����v�����������
        _jumpCount = 0;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
        }
    }
}
