using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public enum ObjectTypes { Image, Text, Material, Sprite };
    public ObjectTypes Type;
    public float TotalFadeTime;
    public bool FadeOnStart = true;

    [Range (0.0f, 1.0f)]
    public float FadeStartValue;
    [Range (0.0f, 1.0f)]
    public float FadeEndValue;

    private float timeCounter;
    private bool isFading = false;

    private Color colorFadeAuxiliary;

    #region Specific case variables
    private Text textToFade;
    private Image imageToFade;
    private SpriteRenderer spriteToFade;
    #endregion


    // Use this for initialization
    void Start ()
    {
        timeCounter = 0;
        if (FadeOnStart)
            StartFading();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ( isFading )
        {
            timeCounter += Time.deltaTime;

            // Case we are fading a text..
            if (Type == ObjectTypes.Text  && textToFade != null)
            {
                colorFadeAuxiliary = textToFade.color;
                colorFadeAuxiliary.a = Mathf.Lerp(FadeStartValue, FadeEndValue, timeCounter / TotalFadeTime);
                textToFade.color = colorFadeAuxiliary;
            }
            // Case we are fading an image..
            if (Type == ObjectTypes.Image && imageToFade != null)
            {
                colorFadeAuxiliary = imageToFade.color;
                colorFadeAuxiliary.a = Mathf.Lerp(FadeStartValue, FadeEndValue, timeCounter / TotalFadeTime);
                imageToFade.color = colorFadeAuxiliary;
            }
            // Case we are fading a sprite..
            if (Type == ObjectTypes.Sprite && spriteToFade != null)
            {
                colorFadeAuxiliary = spriteToFade.color;
                colorFadeAuxiliary.a = Mathf.Lerp(FadeStartValue, FadeEndValue, timeCounter / TotalFadeTime);
                spriteToFade.color = colorFadeAuxiliary;
            }
            // Case we are fading a material.. (to code)
        }
    }

    public void StartFading()
    {
        // If already fading we must return..
        if (isFading)
            return;

        timeCounter = 0;
        isFading = true;
        
        // Case we are fading a text..
        if (Type == ObjectTypes.Text)
        {
            textToFade =  this.GetComponent<Text>();
        }

        // Case we are fading an image..
        if (Type == ObjectTypes.Image)
        {
            imageToFade = this.GetComponent<Image>();
        }

        if (Type == ObjectTypes.Sprite)
        {
            spriteToFade = this.GetComponent<SpriteRenderer>();
        }

        // Case we are fading a material.. (to code)
    }

   
}
