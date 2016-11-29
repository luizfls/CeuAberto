using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // This class will control the animation of the menu.

    public static Manager Instance;     // A reference to this class.
    public string NameOfTheSceneToLoad; // Name of the scene that this menu will load.
    public float WaitToLoad;            // Amount of time the splash screen will remain on screen before loading next scene.
    public bool IsTouchToLoad;          // True if requires the player to touch the screen in order to load the next scene.

    public Animator AnimationController;

    private float timeCounter;

    // Use this for initialization
    void Start()
    {
        if (Instance == null)
            Instance = this;
        
        //  Counter time for letting the player through the menu.
        timeCounter = 0;

        // If the menu don't require the player to touch on the screen to load next scene.
        if (!Manager.Instance.IsTouchToLoad)
            FadeAnimation();


    }

    // Update is called once per frame
    void Update()
    {
        // Time before user able to skip animation
        timeCounter += Time.deltaTime;
        if ( timeCounter >= WaitToLoad)
        {
            #if UNITY_EDITOR
            // Check if there is a touch..
            if ( Input.GetMouseButtonUp(0))
                AnimationController.Play("FadeLogo");
            #endif

            #if UNITY_ANDROID
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
                AnimationController.Play("FadeLogo");

            #endif
        }
    }

    // Fade Animation
    void FadeAnimation()
    {
        StartCoroutine(FaidAfter());
    }

    IEnumerator FaidAfter()
    {
        yield return new WaitForSeconds(WaitToLoad);
        AnimationController.Play("FadeLogo");
    }

}
