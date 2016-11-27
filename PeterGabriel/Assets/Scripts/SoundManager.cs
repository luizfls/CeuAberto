using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip Theme;
    public AudioClip CollectPaper;
    public AudioClip Lose;
    public AudioClip Win;
    public AudioClip DeliveryAA;
    public AudioClip ClickOk;

    public AudioSource AudioSourceMain;
    private AudioSource AudioTheme;


    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        AudioSourceMain = this.GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start ()
    {
       
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayPaperPickup()
    {
        AudioSourceMain.clip = CollectPaper;
        AudioSourceMain.Play();
    }

    public void PlayClickSound()
    {
        AudioSourceMain.clip = ClickOk;
        AudioSourceMain.Play();
    }

    public void PlayLoseSound()
    {
        AudioSourceMain.clip = Lose;
        AudioSourceMain.Play();
    }

    public void PlayWinSound()
    {
        AudioSourceMain.clip = Win;
        AudioSourceMain.Play();
    }

    public void PlayDeliveryAA()
    {
        AudioSourceMain.clip = DeliveryAA;
        AudioSourceMain.Play();
    }
}
