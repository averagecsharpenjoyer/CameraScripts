using UnityEngine;

public class Camera_movement : MonoBehaviour {

    public Transform player_cam, center_point;
    public float distance, max_height, min_height ,orbiting_speed, vertical_speed;
    float height;
    bool cursor_locked;

    void Start()
    {
        cursor_locked = true;
    }
 
    void Update()
    {
        center_point.position = gameObject.transform.position + new Vector3(0, 1.58f, 0);
        center_point.eulerAngles += new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * orbiting_speed, 0);
        height += Input.GetAxis("Mouse Y") * Time.deltaTime * -vertical_speed;
        height = Mathf.Clamp(height, min_height, max_height);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursor_locked = !cursor_locked;
        } 

        if(cursor_locked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }

    void LateUpdate()
    {
        player_cam.position = center_point.position + center_point.forward * -1 * distance + Vector3.up * height ;
        player_cam.LookAt(center_point);
    }

}

