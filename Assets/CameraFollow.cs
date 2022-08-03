using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Text text;
    public Vector3 offset;
    private float time = 0.0f;


    public void LateUpdate()
    {
        time += Time.deltaTime;
        text.text = "Score: "+time*20;

        if (BallMovement.gravity)
        {
            offset.y = 1.25f;
            if (transform.rotation.z != 0)
                transform.rotation = Quaternion.Euler(0,90,0);
        }

        if (!BallMovement.gravity)
        {
            offset.y = -1.25f;
            if (transform.rotation.z == 0)
                transform.rotation = Quaternion.Euler(0, 90, -180);
        }

        transform.position = target.position + offset;
    }
}
