using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float loadDelay = 0.2F;

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Ground" && other.IsTouching(gameObject.GetComponent<CircleCollider2D>()))
        {
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
