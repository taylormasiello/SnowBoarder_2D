using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float loadDelay = 0.5F;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    SurfaceEffector2D surfaceEffector2D;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Ground" && !hasCrashed && other.IsTouching(gameObject.GetComponent<CircleCollider2D>()))
        {
            hasCrashed = true;
            surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

            surfaceEffector2D.speed = 0F;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
