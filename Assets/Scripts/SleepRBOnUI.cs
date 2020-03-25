using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepRBOnUI : MonoBehaviour
{

    private LevelManager levelManager;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.IsGameOver()) {
            rb.Sleep();
        }
    }
}
