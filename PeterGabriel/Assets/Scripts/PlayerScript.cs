using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public ParticleSystem FireRight;
    public ParticleSystem SmokeRight;
    public ParticleSystem FireLeft;
    public ParticleSystem SmokeLeft;

    private Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start ()
    {
        myRigidBody = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (myRigidBody.velocity.y > 0)
        {
            FireLeft.Play();
            SmokeRight.Play();
            FireRight.Play();
            SmokeLeft.Play();
        }
        else
        {
            FireLeft.Stop();
            SmokeRight.Stop();
            FireRight.Stop();
            SmokeLeft.Stop();
        }
	}
}
