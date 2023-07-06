using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�W�����v�͒���
    [SerializeField] float jump_power;
    //���͒���
    [SerializeField] public float run_power;
    Rigidbody2D _rb;
    //��i�W�����v����p
    int _jumpCount = 0;
    //�Q�[���}�l�[�W���[
    GameManager gameManager;
    /// <summary>
    /// �v���C���[�̏��
    /// </summary>
    PlayerCondition _playerCondition;
    /// <summary>
    /// �t�H���[�h�A�C�e���l�����̑O�i����
    /// </summary>
    [SerializeField] float _forwardPower = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g��Rigidbody���擾
        _rb = GetComponent<Rigidbody2D>();
        //��i�W�����v�����������
        _jumpCount = 0;

        //�Q�[���}�l�[�W���[���擾
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
