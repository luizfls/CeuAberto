using UnityEngine;
using System.Collections;

public class AccelerometerController : MonoBehaviour
{
    public bool ControlXAxis; // Horizontal Axis
    public bool ControlYAxis; // Vertical Axis
    public bool ControlZAxis; // Depth Axis

    public float SlowFactor = 2; // Number that will make accelorometer controller less sensitive

	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(ControlXAxis ? Input.acceleration.x / SlowFactor : 0,
                            ControlYAxis ? Input.acceleration.x / SlowFactor : 0,
                            ControlZAxis ? Input.acceleration.x / SlowFactor : 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f,0,0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0, 0);
        }


    }

        
}
