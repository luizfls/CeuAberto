using UnityEngine;
using System.Collections;

public class TransladeTop : MonoBehaviour {

    public Vector3 SpeedUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(SpeedUp);
    }
}
