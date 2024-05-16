using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AppsFlyerSDK;

public class GameController : MonoBehaviour
{
    public Joystick TankJoystick;
    public Button TankButton;
    public GameObject TankObject;
    public GameConstants GameConstants;
    public GameObject EventSystem;
    public GameObject MenuHandlerScript;

    private bool TankDirection = false; // false: Left, true: Right
    private GameObject TankCannonRotatorObject;

    // Start is called before the first frame update
    void Start()
    {
        this.TankCannonRotatorObject = TankObject.transform.GetChild(0).gameObject;
        Dictionary<string,string> EventValues = new Dictionary<string, string>();
        EventValues.Add("time",Time.time.ToString());
        AppsFlyer.sendEvent("scene_play_start", EventValues);
    }

    void AlignObjectByDirection(GameObject gameObject, float horizontal)
    {
        Vector3 newScale = TankObject.GetComponent<Transform>().localScale;
        if (horizontal > 0 && TankDirection == false)
        {
            this.TankDirection = true;
            newScale.x = -UnityEngine.Mathf.Abs(newScale.x);
        }

        if (horizontal < 0 && TankDirection == true)
        {
            this.TankDirection = false;
            newScale.x = UnityEngine.Mathf.Abs(newScale.x);
        }
        TankObject.GetComponent<Transform>().localScale = newScale;
    }

    // Update is called once per frame
    void Update()
    {
        TankObject.GetComponent<Rigidbody2D>().velocity = new Vector2(TankJoystick.Horizontal * GameConstants.TankSpeed, 0);
        TankCannonRotatorObject.transform.Rotate(0, 0, -TankJoystick.Vertical);
        AlignObjectByDirection(TankObject, TankJoystick.Horizontal);

    }
}
