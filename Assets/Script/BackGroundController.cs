using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    //�X�N���[�����x
    [SerializeField] float _scrollSpeed;

    //���Z�b�g�|�W�V����
    [SerializeField] private float ResetPosition;

    //�X�^�[�g�|�W�V����
    private Vector3 StartPosition;

    //�I�u�W�F�N�g�̃����_���[���擾
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

        //// �w�i�摜��������x���ɓ�������A�E�ɖ߂�
        //if (_sprite.transform.position.x < -1 * _sprite.bounds.size.x)
        //{
        //    _sprite.transform.Translate(_sprite.bounds.size.x * 2, 0f, 0f);
        //}

        transform.Translate(-1 * _scrollSpeed, 0, 0, Space.World);
        if (transform.position.x < ResetPosition)
            transform.position = StartPosition;
    }
}
