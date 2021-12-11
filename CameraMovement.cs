using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using Photon.Pun;
//using Photon.Realtime;
//using ExitGames.Client.Photon;


public class CameraMovement : MonoBehaviour
{

    public Slider sliderX, sliderY;
    public Text speedXText, speedYText;
    public FixedTouchField touchField;
    public Transform player_cam, center_point;
    public float cameraAngleX, cameraAngleHorizontalSpeed = 0.1f , cameraAngleVerticalSpeed = 0.1f, minHeight, maxHeight;
    public static float height;
    [SerializeField]
    int cameraTouchCount;

    public bool is_lookingat;
    float rotX, rotY, deltaX, deltaY;
    Vector3 origRot;
    

    Touch initTouch = new Touch();



    void Start()
    {
        origRot = transform.eulerAngles;
        rotX = origRot.x;
        rotY = origRot.y;
        cameraAngleX = player_cam.eulerAngles.x;
    }

    void Update()
    {
        cameraAngleHorizontalSpeed = sliderX.value;
        cameraAngleVerticalSpeed = sliderY.value;

        speedXText.text = cameraAngleHorizontalSpeed.ToString("f2");
        speedYText.text = cameraAngleVerticalSpeed.ToString("f2");
        //x euler -5, 15
        cameraAngleX -= touchField.TouchDist.y * cameraAngleVerticalSpeed;
        cameraAngleX = Mathf.Clamp(cameraAngleX, minHeight, maxHeight); //maxHeight determines how low you can look
        player_cam.localEulerAngles = new Vector3(cameraAngleX, player_cam.localEulerAngles.y, player_cam.localEulerAngles.z);
       transform.eulerAngles += new Vector3(0, touchField.TouchDist.x * cameraAngleHorizontalSpeed, 0);



            //if (photonView.IsMine)
          // {
                


         // }

    //    if (!photonView.IsMine)
      //      return;

        if (IsPointerOverGameObject())
            return;  
        /*
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                deltaX = initTouch.position.x - touch.position.x;
                deltaY = initTouch.position.y - touch.position.y;
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,  transform.eulerAngles + new Vector3(0, -deltaX * Time.deltaTime * orbiting_speed, 0), Time.deltaTime);
              //  player_cam.eulerAngles = Vector3.Lerp(player_cam.eulerAngles, player_cam.eulerAngles + new Vector3(-deltaY * Time.deltaTime * -vertical_speed, 0), Time.deltaTime);
               //  player_cam.eulerAngles = new Vector3(Mathf.Clamp(player_cam.eulerAngles.x, -10, 15) ,player_cam.eulerAngles.y, player_cam.eulerAngles.z);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();

            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                initTouch = touch;
            }
        }

        */
    }

     void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        
            
     //   if (Physics.Linecast(center_point.position, player_cam.position, out hit))
       // {
            /* if (hit.collider.CompareTag("Terrain"))
             {
                 player_cam.position = hit.point + hit.normal * 0.14f;
             }
             */
     //   }
     

    }

  

    public static bool IsPointerOverGameObject()
    {

        if (EventSystem.current.IsPointerOverGameObject(0) || EventSystem.current.IsPointerOverGameObject())
            return true;
        return false;
    }

}
