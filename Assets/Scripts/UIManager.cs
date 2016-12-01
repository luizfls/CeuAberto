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
    public Text TotalPapers;
    public Text TimeRemaining;

    public GameObject GameOverMenu;

    public GameObject StoryPanelFade;
    public GameObject StoryPanel;
    public GameObject StoryPanel2;
    public GameObject StoryPanel3;

    public GameObject PauseMenu;

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
        PauseMenu.SetActive(true);

    }

    public void ActivateHomeMenu()
    {
        //SceneManager.LoadScene("MainMenu");
        GameOverMenu.SetActive(false);
        GameManager.Instance.RestartAfterGameOver();
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameObject.Find("Player").GetComponent<AccelerometerController>().enabled = false;
        PauseMenu.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<AccelerometerController>().enabled = true;
        PauseMenu.SetActive(false);
    }

    public void RateThisAppPLZ()
    {
        Application.OpenURL("market://details?id=YOUR_APP_ID");
    }

    public void LearnMore()
    {
        Application.OpenURL("https://en.wikipedia.org/wiki/Open_access");
    }

    public void ActivateGameOverMenu()
    {
        this.GameOverMenu.SetActive(true);
    }

    void Update()
    {

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
        //shouldLoad = true;
        StoryPanel.SetActive(false);
        StoryPanel2.SetActive(true);
         
    }
    public void ContinueButtonStory2()
    {
        //shouldLoad = true;
        StoryPanel2.SetActive(false);
        StoryPanel3.SetActive(true);
    }
    public void ContinueButtonStory3()
    {
        //shouldLoad = true;
        SceneManager.LoadScene("Game");
    }

    public void HomeButton()
    {
        //shouldLoad = true;
        Time.timeScale = 1;
        SoundManager.Instance.DestroyMe();
        SceneManager.LoadScene("MainMenu");
    }

    public void FirstClick()
    {
        StoryPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
