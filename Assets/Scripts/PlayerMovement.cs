using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Velocidad
    public float speed = 2.5f;
    public Transform CameraPlayer;
    public float AngleLin = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        float Angle = CameraPlayer.rotation.eulerAngles.x;
        if (Angle > AngleLin)
        {
            Vector3 Direction = CameraPlayer.forward * speed;
            Direction = new Vector3(Direction.x, 0.05f, Direction.z);
            GetComponent<Rigidbody>().velocity = Direction;
        }
        else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }
}
