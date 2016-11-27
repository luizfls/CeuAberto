using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour
{
    public float lifeSpan = 30;
    public float MaxDistance = 10;
    private float timeCounter;
    private GameObject player;

	// Use this for initialization
	void Start ()
    {
        timeCounter = 0;
        player = GameObject.Find("Player");

	}
	
	// Update is called once per frame
	void Update ()
    {
        if ( Vector3.Distance(this.transform.position, player.transform.position) > MaxDistance)
            GameObject.Destroy(this.gameObject);
        if (timeCounter > lifeSpan)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            timeCounter += Time.deltaTime;
        }
	}
}
