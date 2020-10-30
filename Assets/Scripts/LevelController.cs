using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private DestroyEnemy[] _enemies;
    private static int _nextLevelIndex = 1;
    
    private void OnEnable() {
        _enemies = FindObjectsOfType<DestroyEnemy>();
    }
    // Update is called once per frame
    void Update()
    {
        foreach(DestroyEnemy enemy in _enemies){
            if( enemy != null){
                return;
            }
        }

        string nextLevelName = "Scene" + _nextLevelIndex;
        
        SceneManager.LoadScene(nextLevelName);
        
        _nextLevelIndex++;
    }
}
