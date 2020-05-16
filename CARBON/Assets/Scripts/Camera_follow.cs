using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public bool yMaxEnabled = false;
    public float yMax = 0f;
    public bool yMinEnabled = false;
    public float ymin = 0f;
    public bool xMaxEnabled = false;
    public float xMax = 0f;
    public bool xMinEnabled = false;
    public float xMin = 0f;
    public Transform target;
    Vector3 velocity = Vector3.zero;
    public float smoothTime = 1.5f;
    void FixedUpdate() {
        Vector3 targetPos = target.position;
        targetPos.Set(target.position.x+5,target.position.y,transform.position.z);

        //vertical clamping
        if (yMinEnabled && yMaxEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, ymin, yMax);
        }
        else if (yMinEnabled)
        {
            targetPos.y = Mathf.Clamp(target.position.y, ymin, target.position.y);
        }
        else if (yMaxEnabled) {
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, yMax);
        }


        //horizontal clamping
        if (xMinEnabled && xMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, xMin, xMax);
        }
        else if (xMinEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, xMin, target.position.x);
        }
        else if (xMaxEnabled)
        {
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, xMax);
        }






        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

    }


}
