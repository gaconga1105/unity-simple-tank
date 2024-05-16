using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vehicle1Controller : MonoBehaviour
{
    public Joystick JoystickObject;
    public GameObject Vehicle1Object;
    public Button ButtonObject;
    public GameObject BulletPrefab;
    public float GunRotationSpeed;
    public float VehicleSpeed; // The max speed if Joystick value is 1
    public float BulletSpeed;
    private GameObject VehicleBody;
    private WheelJoint2D[] VehicleWheelJoint2D;
    private HingeJoint2D[] VehicleGunRotatorJoint2D;
    private GameObject VehicleFrontGun;
    private GameObject VehicleRearGun;

    // Start is called before the first frame update
    void Start()
    {
        this.VehicleBody = Vehicle1Object.transform.GetChild(0).gameObject;
        this.VehicleRearGun = Vehicle1Object.transform.GetChild(1).transform.GetChild(0).gameObject;
        this.VehicleFrontGun = Vehicle1Object.transform.GetChild(2).transform.GetChild(0).gameObject;
        this.VehicleWheelJoint2D = VehicleBody.GetComponents<WheelJoint2D>();
        this.VehicleGunRotatorJoint2D = VehicleBody.GetComponents<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (HingeJoint2D gun_rotator in this.VehicleGunRotatorJoint2D)
        {
            JointMotor2D newMotor = gun_rotator.motor;
            newMotor.motorSpeed = GunRotationSpeed * JoystickObject.Vertical;
            gun_rotator.motor = newMotor;
        }

        foreach (WheelJoint2D wheel in this.VehicleWheelJoint2D)
        {
            JointMotor2D newMotor = wheel.motor;
            newMotor.motorSpeed = -VehicleSpeed * JoystickObject.Horizontal;
            wheel.motor = newMotor;
        }
    }

    public void Fire()
    {
        Vector3 NewBulletVector3 = VehicleFrontGun.transform.TransformPoint(0, 0, 0);
        Quaternion NewBulletQuaternion = VehicleFrontGun.transform.rotation;
        GameObject NewBulletObject = Instantiate(BulletPrefab, NewBulletVector3, NewBulletQuaternion);
        //NewBulletObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-NewBulletVector3.x, 0).normalized * BulletSpeed);
        NewBulletObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-NewBulletVector3.x, 0).normalized * BulletSpeed);
    }

    
}
