using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private bool IsTitleScreen = true;

    [Header("FirstMenu")]
    public Button MainMenuTouch;

    [Header("Game UI")]
    public Button Pause;
    public Button Home;
    public Text Score;
    public Text Level;

    public GameObject GameOverMenu;

    public GameObject StoryPanelFade;
    public GameObject BOB;

    public GameObject PausePanel;

    private GameObject FadeImage;
    private bool shouldLoad;
    
    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        GameObject temp = GameObject.Find("PauseButton");
        FadeImage = GameObject.Find("Fade");
        if (temp != null)
        {
            Pause = temp.GetComponent<Button>();
        }
        
    }

    public void ActivateInGameMenu()
    {
        Time.timeScale = 0;        
        Home = GameObject.Find("HomeButton").GetComponent<Button>();
        PausePanel.SetActive(true);

    }

    public void ActivateHomeMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void ActivateGameOverMenu()
    {
        this.GameOverMenu.SetActive(true);
    }

    void Update()
    {

#if UNITY_ANDROID
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
         SceneManager.LoadScene("Game");
                //GameObject.Find("Fade").GetComponent<Fade>().StartFading();

#endif

#if UNITY_EDITOR
        // Check if there is a touch..
        if (FadeImage != null && Input.GetMouseButtonUp(0))
        {
            //GameObject.Find("Fade").GetComponent<Fade>().StartFading();
            //StoryPanelFade.GetComponent<Fade>().StartFading();
           // IsTitleScreen = false;
            SceneManager.LoadScene("Game");
            //BOB.SetActive(true);
        }
               
        #endif


        if ( FadeImage != null && IsTitleScreen)
        {
            if (FadeImage.GetComponent<Image>().color.a > 0.9f )
            {
                IsTitleScreen = false;
                SceneManager.LoadScene("Game");
            }
        }
        if (shouldLoad)
        {
            if (StoryPanelFade.GetComponent<Image>().color.a > 0.9f)
            {
                IsTitleScreen = false;
                SceneManager.LoadScene("Game");
            }
        }        
    }
    public void ContinueButtonStory()
    {
        shouldLoad = true;
       // GameObject.Find("Fade").GetComponent<Fade>().StartFading();
    }
}
