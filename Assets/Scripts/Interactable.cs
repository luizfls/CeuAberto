using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public float MaxDistance;
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance(player.transform.position, this.transform.position) > MaxDistance  )
        {
            if (this.tag == "Paper")
                GameManager.Instance.SpawnPrefab(GameManager.Instance.Paper, GameManager.Instance.MinRadiusToSpawnPaper, GameManager.Instance.MaxRadiusToSpawnPaper);
            if (this.tag == "AA")
                GameManager.Instance.SpawnPrefab(GameManager.Instance.AA, GameManager.Instance.MinRadiusToSpawnAA, GameManager.Instance.MaxRadiusToSpawnAA);
            if (this.tag == "AF")
                GameManager.Instance.SpawnPrefab(GameManager.Instance.AF, GameManager.Instance.MinRadiusToSpawnAF, GameManager.Instance.MaxRadiusToSpawnAF);

            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (this.tag == "Paper" && col.tag == "Player")
        {
            GameManager.Instance.PaperCount++;
            GameManager.DestroyObject(this.gameObject);
            SoundManager.Instance.PlayPaperPickup();
        }
        if (this.tag == "AA" && col.tag == "Player")
        {
            // restart game
            GameManager.Instance.RestardGame();
            SoundManager.Instance.PlayDeliveryAA();
            SoundManager.Instance.PlayWinSound();

        }
        if (this.tag == "AF" && col.tag == "Player")
        {
            UIManager.Instance.GameOverMenu.SetActive(true);
            Time.timeScale = 0;
            // lose game
            SoundManager.Instance.PlayLoseSound();
        }
    }
}
