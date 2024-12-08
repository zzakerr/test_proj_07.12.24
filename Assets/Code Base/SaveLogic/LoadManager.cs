using System;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : SingletonBase<LoadManager>
{
    private SaveManager _saveManager;
    private string _saveName;
    private void Awake()
    {
        Init();
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _saveManager = GetComponent<SaveManager>();
    }
    
    public void LoadScene(int sceneIndex, string saveName)
    {
        SceneManager.LoadScene(sceneIndex);
        StartCoroutine(LoadAsync_Delayed(sceneIndex, saveName));
    }

    private IEnumerator LoadAsync_Delayed(int sceneIndex, string saveName)
    {
        AsyncOperation LoadAsync = SceneManager.LoadSceneAsync(sceneIndex);
        Debug.Log(LoadAsync.progress);
        
        while (!LoadAsync.isDone)
        {
            yield return null;
        }
        Debug.Log("Done");
        _saveManager.Load(saveName);
    }
}
