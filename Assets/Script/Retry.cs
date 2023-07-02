using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    /// <summary>
    /// ÉVÅ[Éìñº
    /// </summary>
    string _sceneName;
    // Start is called before the first frame update
    void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    public void RetryScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(_sceneName);
    }
}
