using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Controller : MonoBehaviour
{
    public Transform InitTranform;
    public float MovingSpeed;
    public float DropDown;

    private Transform GunSight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.Rotate(0, 0, -DropDown);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
