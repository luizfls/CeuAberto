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


    public void DestroyMe()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void PlayPaperPickup()
    {
        AudioSourceMain.clip = CollectPaper;
        AudioSourceMain.Play();
        //StartCoroutine(playRoutine(CollectPaper));
    }

    public void PlayClickSound()
    {
        AudioSourceMain.clip = ClickOk;
        AudioSourceMain.Play();
        //StartCoroutine(playRoutine(ClickOk));
    }

    public void PlayLoseSound()
    {
        StartCoroutine(playRoutine(Lose));
    }

    public void PlayWinSound()
    {
        StartCoroutine(playRoutine(Win));
    }

    public void PlayDeliveryAA()
    {
        StartCoroutine(playRoutine(DeliveryAA));
    }

    // Routine to play sounds..
    IEnumerator playRoutine(AudioClip clip)
    {
        AudioTheme.volume = 0.2f;
        AudioSourceMain.clip = clip;
        AudioSourceMain.Play();
        yield return new WaitForSeconds(AudioSourceMain.clip.length);
        AudioSourceMain.Pause();
        AudioTheme.volume = 1;
    }

}
