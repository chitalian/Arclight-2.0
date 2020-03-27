using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public string sceneName;
    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.LoadLevel(sceneName);
        }
    }
}
