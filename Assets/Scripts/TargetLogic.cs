using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    public GameObject targetToActivate;
    public bool deactivate = false;
    public AudioClip hitSoundEffect;
    private LevelManager levelManager;
    private bool hit = false;
    public static int targetCount = 0;

    void Start() {
        targetCount += 1; 
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        print("Count is: " + targetCount);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            if (!hit) {
                Debug.Log("Target Hit");
                AudioSource.PlayClipAtPoint(hitSoundEffect, gameObject.transform.position);
                levelManager.IncrementHitTargets();
                hit = true;

                Renderer renderer = gameObject.GetComponent<Renderer> ();
                Material mat = renderer.material;
                mat.EnableKeyword("_EMISSION");

                targetToActivate.SetActive(!deactivate);
            }
        }
    }

    public bool isHit() {
        targetCount -= 1;
        return hit;
    }
}
