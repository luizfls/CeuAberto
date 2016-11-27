using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Remover : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ( col.tag == "Player")
        {
            // Game Over
            SceneManager.LoadScene("Game");
        }
        else if ( col.tag == "Platform")
        {
            // Destroy the platform
            GameObject.Destroy(col.gameObject);
        }
    }
}
