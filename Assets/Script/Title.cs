using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private bool firstPush_start = false;
    /// <summary>�t�F�[�h�p Image</summary>
    [SerializeField] Image _fadeImage = default;
    /// <summary>�t�F�[�h�A�E�g�����܂łɂ����鎞�ԁi�b�j/summary>
    [SerializeField] float _fadeTime = 1;
    float _timer = 0;
    Text _text;

    private void Start()
    {
        float bestScore = PlayerPrefs.GetFloat("BestScore", 0.0f);
        _text = GameObject.Find("BestScore").GetComponent<Text>();
        _text.text = "Best Score:" + bestScore.ToString() + "m";
    }
    //start�{�^���������ꂽ���̏���
    public void PressStart()
    {
        Debug.Log("�X�^�[�g�{�^����������܂���");

        if (!firstPush_start)
        {

            //���̃V�[���ɍs������
            StartCoroutine(FadeRoutine());
            firstPush_start = true;
        }
    }
    IEnumerator FadeRoutine()
    {
        // Image ���� Color ���擾���A���Ԃ̐i�s�ɍ��킹���A���t�@��ݒ肵�� Image �ɖ߂�
        while (true)
        {
            _timer += Time.deltaTime;
            Color c = _fadeImage.color; // ���݂� Image �̐F���擾����
            c.a = _timer / _fadeTime;   // �F�̃A���t�@�� 1 �ɋ߂Â��Ă���
            // TODO: �F�� Image �ɃZ�b�g����
            _fadeImage.color = c;
            // _fadeTime ���o�߂����珈���͏I������
            if (_timer > _fadeTime)
            {
                Debug.Log("�R���[�`���ɂ�� Fade ����");
                SceneManager.LoadScene("Main");
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }


    }
}
