using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    /// <summary>�ǂƂ��Đ�������v���n�u</summary>
    [SerializeField] GameObject[] m_wallPrefabs = null;
    //�ǂ̐����ꏊ�̃|�C���g
    [SerializeField] Vector2[] m_position = null; 
    /// <summary>�ǂ𐶐�����Ԋu�i�b�j</summary>
    [SerializeField] float m_wallGenerateInterval = 2f;
    /// <summary>�ǐ����Ԋu���v�邽�߂̃^�C�}�[�i�b�j</summary>
    float m_timer = 0;
    /// <summary>
    /// �ǂ������Ȃ��Ă����b��
    /// </summary>
    [SerializeField] float m_speedUpCount = 60f;
    /// <summary>
    ///�@�X�s�[�h�A�b�v�p�J�E���g
    /// </summary>
    float m_speedUpTimer = 0f;
    /// <summary>
    /// ���b��������̂������߂�ϐ�
    /// </summary>
    [SerializeField] float m_speedUpNum = 0.25f;

    void Start()
    {
        // ���s������ŏ��̕ǂ��������������悤�Ƀ^�C�}�[�ɒl�����Ă���
        m_timer = m_wallGenerateInterval;
    }

    void Update()
    {
        m_timer += Time.deltaTime;

        m_speedUpTimer += Time.deltaTime;
        // �^�C�}�[�̒l�������Ԋu�𒴂�����
        if (m_timer > m_wallGenerateInterval)
        {
            m_timer = 0f;   // �^�C�}�[�����Z�b�g����
            int index = Random.Range(0, m_wallPrefabs.Length);  // �z�񂩂�I�u�W�F�N�g��I�Ԃ��߂̃C���f�b�N�X�i�Y���j�������_���ɑI��
            GameObject go = Instantiate(m_wallPrefabs[index]);  // �v���n�u����I�u�W�F�N�g�𐶐����āA�ϐ� go �ɓ����
            go.transform.position = m_position[index];   // ���������I�u�W�F�N�g�̈ʒu���߂�
        }

        //�X�s�[�h�A�b�v
        if(m_speedUpTimer > m_speedUpCount)
        {
            m_speedUpTimer = 0f;
            m_wallGenerateInterval -= m_speedUpNum;
        }
    }
}