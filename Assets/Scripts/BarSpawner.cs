using UnityEngine;
using System.Collections;

public class BarSpawner : MonoBehaviour
{

    /*
        This class is responsible for spawning objects inside a bar-like object.

        You are able to set if the bar is vertical or horizontal, the spawn frequency of the object and which object it is.
        To keep things organized in your inspector I suggest setting a GameObject as the OrganizeUnder variable.
        In that way objects spawned will be pu under that variable and things will look clean in the Inspector.

        There are two modes for spawning, based on distance or time.

        */
    #region External (public) Variables
    [Header("General")]
    public GameObject OrganizeUnder;
    public float LenghtOfSpawner;
    public bool IsHorizontal;
    public GameObject PrefabToSpawn;
    
    [Header("Time Based Variables")]
    public bool SpawnBasedOnTime;
    public float SpawnFrequency;     // Amount of seconds in between a spawn
    
    [Header("Distance Based Variables")]
    public bool SpawnBasedOnDistance;
    public float MinDistanceToSpawn; // Distance diference between this and the last spawn;
    public float MaxDistanceToSpawn;
    public float TimeBetweenSpawns;
    #endregion

    #region Internal Variables
    private float timeCounter;
    private int timeActive;
    private int timeLastSpawn;
    private Vector3[] lastSpawnPosition; // The last positions spawned
    private GameObject temporaryPlatform;
    #endregion

    // Use this for initialization
    void Start ()
    {
        timeCounter = 0;
        timeLastSpawn = -1;
        lastSpawnPosition = new Vector3[2];
        lastSpawnPosition[0] = this.transform.position;
        lastSpawnPosition[1] = Vector3.zero; // Initialize it with (0,0,0)
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        timeCounter += Time.deltaTime;
        timeActive = Mathf.FloorToInt(timeCounter);

        // It spawns whenever timeActive is multiple of SpawnFrequency and the position is different than the last spawned position.
        if (SpawnBasedOnTime && timeActive % SpawnFrequency == 0)
        {
            // Check if we are not spawning more than one object at the same time. 
            if (timeActive != timeLastSpawn)
            {
                // Check if we are not spawning two objects in the same position.
                if ( IsHorizontal && lastSpawnPosition[0].y != this.transform.position.y)
                    SpawnPlatform();
            }
        }
        if ( SpawnBasedOnDistance )
        {
            // If the minimum vertical distance is reached
            if ( IsHorizontal && ( Mathf.Abs(lastSpawnPosition[0].y -  this.transform.position.y) >= Random.Range(MinDistanceToSpawn, MaxDistanceToSpawn)))
                SpawnPlatform();
            else if ( !IsHorizontal && (Mathf.Abs(lastSpawnPosition[0].x - this.transform.position.x) >= Random.Range(MinDistanceToSpawn, MaxDistanceToSpawn)))
                SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        if (timeCounter < TimeBetweenSpawns)
        {
            return;
        }
        // Time to spawn something
        temporaryPlatform = GameObject.Instantiate(PrefabToSpawn, this.transform.position
            + new Vector3(IsHorizontal ? Random.Range(-LenghtOfSpawner / 2, LenghtOfSpawner / 2) : 0,
                          !IsHorizontal ? Random.Range(-LenghtOfSpawner / 2, LenghtOfSpawner / 2) : 0,
                          0),
                           Quaternion.identity) as GameObject;

        if (OrganizeUnder != null)
            temporaryPlatform.transform.SetParent(OrganizeUnder.transform);     

        lastSpawnPosition[1] = lastSpawnPosition[0];
        lastSpawnPosition[0] = temporaryPlatform.transform.position;
        timeLastSpawn = timeActive;
        timeCounter = 0;
    }

}
