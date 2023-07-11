using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IPause
{
    /// <summary>一時停止の時にメッセージを表示するテキスト</summary>
    [SerializeField] Text _text = default;
    [SerializeField] string _pauseMessage = "PAUSE";
    //[SerializeField] Animator _anim = default;

    void IPause.Pause()
    {
        _text.text = _pauseMessage;
    }

    void IPause.Resume()
    {
        // 表示を消す
        _text.text = "";
    }
}
