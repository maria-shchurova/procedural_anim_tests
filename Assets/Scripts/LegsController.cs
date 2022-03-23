using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsController : MonoBehaviour
{
    public Transform left, right, right_front, left_front;
    public Step leftStep, rightStep, right_frontStep, left_frontStep;
    public bool rightWasLast; //true if last step was made with right leg

    public Transform closestFoot; // to check if distance to it is too far
    public float maxDistanceBetweenBodyAndFoot;
    public float minDistanceBetweenBodyAndFoot;

    public bool needCrunch;//if body is too far from the feet
    public bool needStandUp;//if body is too close to the feet

    void Start()
    {
        Messenger.AddListener<string>("Step made", OnFinishStep);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray rayLeft = new Ray(left.position, Vector3.down);
        Ray rayRight = new Ray(right.position, Vector3.down);
        RaycastHit hitLeft;
        RaycastHit hitRight;
        float rayLength = 0.5f;
        if (Physics.Raycast(rayLeft, out hitLeft, rayLength))
        {
            rightStep.canStep = true;
            left_frontStep.canStep = true;
        }
        if (Physics.Raycast(rayRight, out hitRight, rayLength))
        {
            leftStep.canStep = true;
            right_frontStep.canStep = true;
        }

        if(rightWasLast == false)
        {
            rightStep.canStep = true;
            left_frontStep.canStep = true;
            leftStep.canStep = false;
            right_frontStep.canStep = false;
        }
        else
        {
            rightStep.canStep = false;
            left_frontStep.canStep = false;
            leftStep.canStep = true;
            right_frontStep.canStep = true;
        }

        if(Vector3.Distance(transform.position, closestFoot.position) > maxDistanceBetweenBodyAndFoot)
        {
            needCrunch = true;
            needStandUp = false;
        }
        else if (Vector3.Distance(transform.position, closestFoot.position) > minDistanceBetweenBodyAndFoot)
        {
            needStandUp = true;
        }
        else
        {
            needCrunch = false;
            needStandUp = false;
        }

        if (needCrunch)
        {
            float f = Vector3.Distance(transform.position, closestFoot.position);
            Vector3 v = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            v.y -= f / 4 * Time.deltaTime;
            transform.position = v;
        }
        if (needStandUp)
        {
            float f = Vector3.Distance(transform.position, closestFoot.position);
            Vector3 v = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            v.y += f / 4 * Time.deltaTime;
            transform.position = v;
        }
    }

    void OnFinishStep(string legName)
    {
        if (legName == "leg_left")
            rightWasLast = false;

        if (legName == "leg_right")
            rightWasLast = true;
    }

}
