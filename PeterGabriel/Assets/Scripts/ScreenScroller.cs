using UnityEngine;
using System.Collections;

public class ScreenScroller : MonoBehaviour {

    private GameObject MainCamera;
    private GameObject PlatformSpawner;
    private GameObject PlatformRemover;

	// Use this for initialization
	void Awake ()
    {
        MainCamera = GameObject.Find("Main Camera");
        PlatformSpawner = GameObject.Find("PlatformSpawner");
        PlatformRemover = GameObject.Find("PlatformRemover");
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        // Check if player is colliding with this object..
        if (col.tag == "Player" && this.transform.position.y < col.gameObject.transform.position.y)
        { 
            // Move up this game object
            this.transform.position = new Vector3(0, col.gameObject.transform.position.y, 0);
            // Move up camera
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, col.gameObject.transform.position.y, MainCamera.transform.position.z);
            // Move up spawnbar
            PlatformSpawner.transform.position = new Vector3(PlatformSpawner.transform.position.x, col.gameObject.transform.position.y + 6, PlatformSpawner.transform.position.z);
            // Move up destroybar
            PlatformRemover.transform.position = new Vector3(PlatformRemover.transform.position.x, col.gameObject.transform.position.y - 6, PlatformRemover.transform.position.z);
        }

    }

}
