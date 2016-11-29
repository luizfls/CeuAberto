using UnityEngine;
using System.Collections;

public class ScreenScroller : MonoBehaviour {

    private GameObject MainCamera;
    private GameObject ScreenScrollers;
    private GameObject ScreenScrollerTop;
    private GameObject ScreenScrollerBottom;
    private GameObject ScreenScrollerLeft;
    private GameObject ScreenScrollerRight;
    private GameObject PlatformSpawnerTop;
    private GameObject PlatformSpawnerBottom;
    private GameObject PlatformSpawnerLeft;
    private GameObject PlatformSpawnerRight;
    private GameObject PlatformRemover;
    public bool isTop;
    public bool isBottom;
    public bool isLeft;
    public bool isRight;

    // Use this for initialization
    void Awake ()
    {
        MainCamera = GameObject.Find("Main Camera");
        ScreenScrollers = GameObject.Find("ScreenScrollers");
        ScreenScrollerTop = ScreenScrollers.transform.FindChild("Top").gameObject;
        ScreenScrollerBottom = ScreenScrollers.transform.FindChild("Bottom").gameObject;
        ScreenScrollerLeft = ScreenScrollers.transform.FindChild("Left").gameObject;
        ScreenScrollerRight = ScreenScrollers.transform.FindChild("Right").gameObject;
        PlatformSpawnerTop = GameObject.Find("PlatformSpawnerTop");
        PlatformSpawnerBottom = GameObject.Find("PlatformSpawnerBottom");
        PlatformSpawnerLeft = GameObject.Find("PlatformSpawnerLeft");
        PlatformSpawnerRight = GameObject.Find("PlatformSpawnerRight");
        PlatformRemover = GameObject.Find("PlatformRemover");
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        // Check if player is colliding with this object..
        if (col.tag == "Player")
        {
            if ((isTop && this.transform.position.y < col.gameObject.transform.position.y) ||
                (isBottom && this.transform.position.y > col.gameObject.transform.position.y) ||
                (isRight && this.transform.position.x < col.gameObject.transform.position.x) ||
                (isLeft && this.transform.position.x > col.gameObject.transform.position.x))
            {
                if(isTop || isBottom) // Vertical reaction
                {
                    // Move all screen scrollers
                    ScreenScrollerTop.transform.position = new Vector3(ScreenScrollerTop.transform.position.x, col.gameObject.transform.position.y + (isTop ? 0.0f : 4.5f), 0);
                    ScreenScrollerBottom.transform.position = new Vector3(ScreenScrollerBottom.transform.position.x, col.gameObject.transform.position.y + (isTop ? -4.5f : 0.0f), 0);
                    ScreenScrollerRight.transform.position = new Vector3(ScreenScrollerRight.transform.position.x, col.gameObject.transform.position.y + (isTop ? -1.5f : 3.0f), 0);
                    ScreenScrollerLeft.transform.position = new Vector3(ScreenScrollerLeft.transform.position.x, col.gameObject.transform.position.y + (isTop ? -1.5f : 3.0f), 0);
                    
                    // Move camera
                    MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, col.gameObject.transform.position.y + (isTop ? -1.5f : +3.0f), MainCamera.transform.position.z);
                    
                    // Move all spawnbars
                    PlatformSpawnerTop.transform.position = new Vector3(PlatformSpawnerTop.transform.position.x, col.gameObject.transform.position.y + (isTop ? 3.5f : 8.0f), PlatformSpawnerTop.transform.position.z);
                    PlatformSpawnerBottom.transform.position = new Vector3(PlatformSpawnerBottom.transform.position.x, col.gameObject.transform.position.y + (isTop ? -6.5f : -2.0f), PlatformSpawnerTop.transform.position.z);
                    PlatformSpawnerRight.transform.position = new Vector3(PlatformSpawnerRight.transform.position.x, col.gameObject.transform.position.y + (isTop ? -1.5f : 3.0f), PlatformSpawnerRight.transform.position.z);
                    PlatformSpawnerLeft.transform.position = new Vector3(PlatformSpawnerRight.transform.position.x, col.gameObject.transform.position.y + (isTop ? -1.5f : 3.0f), PlatformSpawnerLeft.transform.position.z);
                }
                else // Horizontal reaction
                {
                    // Move all screen scrollers
                    ScreenScrollerTop.transform.position = new Vector3(col.gameObject.transform.position.x + (isRight ? -2.0f : 2.0f ), ScreenScrollerTop.transform.position.y, 0);
                    ScreenScrollerBottom.transform.position = new Vector3(col.gameObject.transform.position.x + (isRight ? -2.0f : 2.0f), ScreenScrollerBottom.transform.position.y, 0);
                    ScreenScrollerRight.transform.position = new Vector3(col.gameObject.transform.position.x + (isRight ? 0.0f : 4.0f), ScreenScrollerRight.transform.position.y, 0);
                    ScreenScrollerLeft.transform.position = new Vector3(col.gameObject.transform.position.x + (isRight ? -4.0f : 0.0f), ScreenScrollerLeft.transform.position.y, 0);

                    // Move camera
                    MainCamera.transform.position = new Vector3(col.gameObject.transform.position.x + (isRight ? -2.0f : +2.0f), MainCamera.transform.position.y, MainCamera.transform.position.z);
                    
                    // Move all spawnbars
                    PlatformSpawnerTop.transform.position = new Vector3(col.gameObject.transform.position.x + (isRight ? -2.0f : 2.0f), PlatformSpawnerTop.transform.position.y, PlatformSpawnerTop.transform.position.z);
                    PlatformSpawnerBottom.transform.position = new Vector3(col.gameObject.transform.position.x + (isRight ? -2.0f : 2.0f), PlatformSpawnerBottom.transform.position.y, PlatformSpawnerTop.transform.position.z);
                    PlatformSpawnerRight.transform.position = new Vector3(col.gameObject.transform.position.x + (isRight ? 2.0f : 6.0f), PlatformSpawnerRight.transform.position.y, PlatformSpawnerRight.transform.position.z);
                    PlatformSpawnerLeft.transform.position = new Vector3(col.gameObject.transform.position.x + (isRight ? -6.0f : -2.0f), PlatformSpawnerLeft.transform.position.y, PlatformSpawnerLeft.transform.position.z);
                }
            }
        }

    }

}
