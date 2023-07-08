using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private bool firstPush_start = false;
    /// <summary>フェード用 Image</summary>
    [SerializeField] Image _fadeImage = default;
    /// <summary>フェードアウト完了までにかかる時間（秒）/summary>
    [SerializeField] float _fadeTime = 1;
    float _timer = 0;
    Text _text;

    private void Start()
    {
        float bestScore = PlayerPrefs.GetFloat("BestScore", 0.0f);
        _text = GameObject.Find("BestScore").GetComponent<Text>();
        _text.text = "Best Score:" + bestScore.ToString() + "m";
    }
    //startボタンが押された時の処理
    public void PressStart()
    {
        Debug.Log("スタートボタンがおされました");

        if (!firstPush_start)
        {

            //次のシーンに行く処理
            StartCoroutine(FadeRoutine());
            firstPush_start = true;
        }
    }
    IEnumerator FadeRoutine()
    {
        // Image から Color を取得し、時間の進行に合わせたアルファを設定して Image に戻す
        while (true)
        {
            _timer += Time.deltaTime;
            Color c = _fadeImage.color; // 現在の Image の色を取得する
            c.a = _timer / _fadeTime;   // 色のアルファを 1 に近づけていく
            // TODO: 色を Image にセットする
            _fadeImage.color = c;
            // _fadeTime が経過したら処理は終了する
            if (_timer > _fadeTime)
            {
                Debug.Log("コルーチンによる Fade 完了");
                SceneManager.LoadScene("Main");
                yield break;
            }

            yield return new WaitForEndOfFrame();
        }


    }
}
