using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour,IPause
{
    /// <summary>壁として生成するプレハブ</summary>
    [SerializeField] GameObject[] m_wallPrefabs = null;
    //壁の生成場所のポイント
    [SerializeField] Vector2[] m_position = null; 
    /// <summary>壁を生成する間隔（秒）</summary>
    [SerializeField] float m_wallGenerateInterval = 2f;
    /// <summary>壁生成間隔を計るためのタイマー（秒）</summary>
    float m_timer = 0;
    /// <summary>
    /// 壁が早くなっていく秒数
    /// </summary>
    [SerializeField] float m_speedUpCount = 60f;
    /// <summary>
    ///　スピードアップ用カウント
    /// </summary>
    float m_speedUpTimer = 0f;
    /// <summary>
    /// 何秒早くするのかを決める変数
    /// </summary>
    [SerializeField] float m_speedUpNum = 0.25f;
    /// <summary>
    /// 最高速度
    /// </summary>
    [SerializeField] float m_speedMaxNum = 1f;

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    void Start()
    {
        // 実行したら最初の壁がすぐ生成されるようにタイマーに値を入れておく
        m_timer = m_wallGenerateInterval;
    }

    void Update()
    {
        m_timer += Time.deltaTime;

        m_speedUpTimer += Time.deltaTime;
        // タイマーの値が生成間隔を超えたら
        if (m_timer > m_wallGenerateInterval)
        {
            m_timer = 0f;   // タイマーをリセットする
            int indexPrefabs = Random.Range(0, m_wallPrefabs.Length);  // 配列からオブジェクトを選ぶためのインデックス（添字）をランダムに選ぶ
            GameObject go = Instantiate(m_wallPrefabs[indexPrefabs]);  // プレハブからオブジェクトを生成して、変数 go に入れる
            int indexPosition = Random.Range(0, m_position.Length);
            go.transform.position = m_position[indexPosition];   // 生成したオブジェクトの位置を定める
        }

        //スピードアップ
        if(m_speedUpTimer > m_speedUpCount)
        {
            m_speedUpTimer = 0f;
            m_wallGenerateInterval -= m_speedUpNum;
            if (m_wallGenerateInterval < m_speedMaxNum)
            {
                m_wallGenerateInterval = m_speedMaxNum;
            }
            
        }
    }
}