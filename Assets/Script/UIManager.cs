using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IPause
{
    /// <summary>�ꎞ��~�̎��Ƀ��b�Z�[�W��\������e�L�X�g</summary>
    [SerializeField] Text _text = default;
    [SerializeField] string _pauseMessage = "PAUSE";
    //[SerializeField] Animator _anim = default;

    void IPause.Pause()
    {
        _text.text = _pauseMessage;
    }

    void IPause.Resume()
    {
        // �\��������
        _text.text = "";
    }
}
