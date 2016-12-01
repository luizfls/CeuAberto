using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject player;
    private GameObject AAReference;
    private GameObject AFReference;

    [Header("Prefabs")]
    public GameObject Paper;
    public GameObject AA;
    public GameObject AF;
    public GameObject Baloon;

    [Header("General Variables")]
    public int MinRadiusToSpawnPaper;
    public int MaxRadiusToSpawnPaper;
    public int MinRadiusToSpawnAA;
    public int MaxRadiusToSpawnAA;
    public int MinRadiusToSpawnAF;
    public int MaxRadiusToSpawnAF;
    public float DistanceToShowBaloonAgain;
    private Vector3 LastSpawnBaloon = Vector3.zero;

    [Header("Player Variables")]
    public int PaperCount;
    public int LevelCount = 1;
    public int TotalPapersCollected;
    public float TimeRemaining;

    void Awake ()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
        SpawnPrefab(Paper, MinRadiusToSpawnPaper, MaxRadiusToSpawnPaper);
        SpawnPrefab(Paper, MinRadiusToSpawnPaper, MaxRadiusToSpawnPaper);
        SpawnPrefab(Paper, MinRadiusToSpawnPaper, MaxRadiusToSpawnPaper);
        TimeRemaining = 30;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if( PaperCount == 3 && AAReference == null && AFReference == null)
        {
            SpawnPrefab(AA, MinRadiusToSpawnAA, MaxRadiusToSpawnAA);
            SpawnPrefab(AF, MinRadiusToSpawnAF, MaxRadiusToSpawnAF);
        } 

        UIManager.Instance.Score.text = PaperCount.ToString() + "/3";
        UIManager.Instance.Level.text = "Level: "+ LevelCount.ToString();
        UIManager.Instance.TotalPapers.text = TotalPapersCollected.ToString();
        UIManager.Instance.TimeRemaining.text = Mathf.CeilToInt(TimeRemaining).ToString();

        
        TimeRemaining = (TimeRemaining - Time.deltaTime);

        if (Vector3.Distance(player.transform.position, LastSpawnBaloon) >= DistanceToShowBaloonAgain )
        {
            LastSpawnBaloon = player.transform.position;
            GameObject.Destroy(GameObject.Instantiate(Baloon, player.transform.position + new Vector3(0, -10, 10), Quaternion.identity), 60);
        }

        if ( TimeRemaining <= 0)
        {
            // lose game
            UIManager.Instance.GameOverMenu.SetActive(true);
            Time.timeScale = 0;
            SoundManager.Instance.PlayLoseSound();
        }

    }

    public void SpawnPrefab(GameObject prefab, float min, float max)
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 randomOffset = new Vector3(Mathf.Sign(Random.RandomRange(-1, 1)) * Random.RandomRange(min, max),
                                           Mathf.Sign(Random.RandomRange(-1, 1)) * Random.RandomRange(min, max),
                                           0);
        Vector3 auxPosition = playerPosition + randomOffset;

        if (prefab == AA)
            AAReference = GameObject.Instantiate(prefab, auxPosition, Quaternion.identity) as GameObject;
        else if (prefab == AF)
            AFReference = GameObject.Instantiate(prefab, auxPosition, Quaternion.identity) as GameObject;
        else
            GameObject.Instantiate(prefab, auxPosition, Quaternion.identity);

    }

    public void RestardGame()
    {
        // Lvl ++
        LevelCount++;
        PaperCount = 0;
        TimeRemaining += 15;


        GameObject.Destroy(AAReference);
        GameObject.Destroy(AFReference);

        SpawnPrefab(Paper, MinRadiusToSpawnPaper, MaxRadiusToSpawnPaper);
        SpawnPrefab(Paper, MinRadiusToSpawnPaper, MaxRadiusToSpawnPaper);
        SpawnPrefab(Paper, MinRadiusToSpawnPaper, MaxRadiusToSpawnPaper);

    }

    public void RestartAfterGameOver()
    {
        // Lvl ++
        LevelCount = 0;
        PaperCount = 0;
        TimeRemaining = 30;
        TotalPapersCollected = 0;


        GameObject.Destroy(AAReference);
        GameObject.Destroy(AFReference);

        SpawnPrefab(Paper, MinRadiusToSpawnPaper, MaxRadiusToSpawnPaper);
        SpawnPrefab(Paper, MinRadiusToSpawnPaper, MaxRadiusToSpawnPaper);
        SpawnPrefab(Paper, MinRadiusToSpawnPaper, MaxRadiusToSpawnPaper);

    }


}
