using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class LevelManager : MonoBehaviour
{
    public TMP_Text levelClearText;
    private int levelTargets;
    private int hitTargets;

    // Start is called before the first frame update
    void Start()
    {
        levelTargets = GameObject.FindGameObjectsWithTag("Target").Length;
        hitTargets = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementHitTargets() {
        hitTargets++;
        Debug.Log(hitTargets);
        if (hitTargets >= levelTargets) {
            LevelClear();
        }
    }

    public bool IsGameOver() {
        return hitTargets >= levelTargets;
    }

    void LevelClear() {
        levelClearText.gameObject.SetActive(true);
        Invoke("RestartLevel", 5f);
    }

    void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
