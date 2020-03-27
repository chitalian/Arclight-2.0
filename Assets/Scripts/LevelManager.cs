using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class LevelManager : MonoBehaviour
{
    public TMP_Text levelClearText;
    private int levelTargets;
    private int hitTargets;
    public Text targetCountText;

    // Start is called before the first frame update
    void Start()
    { 
        levelTargets = GameObject.FindGameObjectsWithTag("Target").Length;
        hitTargets = 0;
    }

    void Update()
    {
        print(TargetLogic.targetCount);
        targetCountText.text = "Remaining Target Count Is: " + TargetLogic.targetCount.ToString();
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

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
