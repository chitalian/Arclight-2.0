using UnityEngine;

public class TargetLogic : MonoBehaviour
{
    public GameObject targetToActivate;
    public bool deactivate = false;
    public AudioClip hitSoundEffect;

    private LevelManager levelManager;

    private bool hit = false;

    void Start() {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
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
        return hit;
    }
}
