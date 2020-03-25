using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlatform : MonoBehaviour
{
    public int xStartingScale = 5;
    public int yStartingScale = 1;
    public int zStartingScale = 10;
    public float platformSpeed = 0.05f;
    public float platfromHeight = 10;
    public float deltaTimeScaler = 10;
    public bool isActive = true;
    
    float yCurrentScale;
    float ystartingPosition;
    bool isGrowing = true;

    // Start is called before the first frame update
    void Start()
    {
        yCurrentScale = yStartingScale;
        ystartingPosition = transform.position.y;
        isGrowing = true;
        transform.localScale = new Vector3(xStartingScale, yStartingScale, zStartingScale);
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive) {
             MovePlatform();
        }
        
    }

    void MovePlatform() {
        if (isGrowing) {
            yCurrentScale = yCurrentScale + platformSpeed;
            if (yCurrentScale >= platfromHeight) {
                isGrowing = false;
                yCurrentScale = platfromHeight;
            }
        }
        else {
            yCurrentScale = yCurrentScale - platformSpeed;
            if (yCurrentScale <= 0) {
                isGrowing = true;
                yCurrentScale = 0;
            }
        }

        transform.localScale =  Vector3.Lerp(transform.localScale, 
            new Vector3(5, yCurrentScale + yCurrentScale, 10), deltaTimeScaler * Time.deltaTime);
    }
}
