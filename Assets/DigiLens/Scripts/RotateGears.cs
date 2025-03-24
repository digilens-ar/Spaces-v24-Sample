using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGears : MonoBehaviour
{
    [Tooltip("Direction in which to spin object: 1,2,3,4")]
    public float direction = 1;
    Vector3 gearPosition;

    // Start is called before the first frame update
    void Start()
    {
        gearPosition = GetComponent<Renderer>().bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        RotateGear();

    }

    /// <summary>
    /// Rotate gear object in designated direction
    /// </summary>
    void RotateGear()
    {
        Vector3 rotationAxis;

        switch (direction)
        {
            case 1:
                rotationAxis = Vector3.up;
                break;
            case 2:
                rotationAxis = Vector3.down;
                break;
            case 3:
                rotationAxis = Vector3.forward;
                break;
            case 4:
                rotationAxis = Vector3.back;
                break;
            default:
                rotationAxis = Vector3.up;
                break;

        }

        transform.Rotate(rotationAxis, Space.Self);
    }
}
