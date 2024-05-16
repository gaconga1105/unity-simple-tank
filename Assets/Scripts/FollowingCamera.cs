using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public GameObject Target;
    public float Smoothness;
    public Vector3 Velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(Target.transform.position.x, this.transform.position.y, -10f),
            ref Velocity,
            Smoothness);
    }
}
