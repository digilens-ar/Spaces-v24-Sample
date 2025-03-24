using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    Vector3 newRotation;
    float scrollInput, dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = 0;
        scrollInput = 0;
        newRotation = Vector3.zero;
    }

    /// <summary>
    /// Stores scrollwheel input
    /// </summary>
    void GetScrollVal()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            scrollInput += (20 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            scrollInput -= (20 * Time.deltaTime);


    }

    /// <summary>
    /// Changes the axis in which we are rotating the object
    /// </summary>
    void UpdateRotation()
    {
        switch (dir)
        {
            case 0:
                newRotation.x += scrollInput;
                break;
            case 1:
                newRotation.z += scrollInput;
                break;
            case 2:
                newRotation.y += scrollInput;
                break;
            default:
                dir = 0;
                //newRotation = new Vector3(0, 0, 0);
                break;

        }

        transform.rotation = Quaternion.Euler(newRotation);
    }

    // Update is called once per frame
    void Update()
    {
        GetScrollVal();

        if (Input.GetKeyDown(KeyCode.Return)) //if scroll wheel was pressed, change axis of rotation and reset angle
        {
            dir += 1;
            scrollInput = 0;
        }
        if (scrollInput != 0) //if there is scroll wheel input, rotate cube
        {
            UpdateRotation();
        }
    }
}
