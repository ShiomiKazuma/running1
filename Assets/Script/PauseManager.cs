using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool _pauseFlg = false;

    void Update()
    {
        // ESC �L�[�������ꂽ��ꎞ��~�E�ĊJ��؂�ւ���
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }

    /// <summary>
    /// �ꎞ��~�E�ĊJ��؂�ւ���
    /// </summary>
    void PauseResume()
    {
        _pauseFlg = !_pauseFlg;

        // �S�Ă� GameObject ������Ă��āAIPause ���p�������R���|�[�l���g���ǉ�����Ă����� Pause �܂��� Resume ���Ă�ł���B
        // �{���� tag �Ȃǂōi�荞�񂾕����悢�ł��傤�B
        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IPause i = o.GetComponent<IPause>();

            if (_pauseFlg)
            {
                i?.Pause();     // �����Łu���Ԑ��v���g���Ă���i? �́unull �������Z�q�v�j
            }
            else
            {
                i?.Resume();    // �����Łu���Ԑ��v���g���Ă���i? �́unull �������Z�q�v�j
            }
        }
    }
}
