using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchSceneAfter : MonoBehaviour
{

    public string SceneName;
    public int TimeOnLogo;
    public int OverallTime;

    public Fade fadeIn;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(fadeAfter());
        
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Routine to play sounds..
    IEnumerator fadeAfter()
    {   
        yield return new WaitForSeconds(TimeOnLogo);
        // Fade
        fadeIn.StartFading();
        StartCoroutine(ChangeSceneAfterFade());
    }

    // Routine to play sounds..
    IEnumerator ChangeSceneAfterFade()
    {      
        yield return new WaitForSeconds(OverallTime);
        SceneManager.LoadScene(SceneName);
    }

    public void ChangeScene()
    {
        fadeIn.StartFading();
        StartCoroutine(ChangeSceneAfterFade());
    }
}
