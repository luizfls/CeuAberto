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
    public GameObject StoryPanel;
    public GameObject StoryPanel2;
    public GameObject StoryPanel3;


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

    public void FirstClick()
    {
        StoryPanel.SetActive(true);
    }

}
