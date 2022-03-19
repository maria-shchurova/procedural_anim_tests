using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsController : MonoBehaviour
{
    public Transform left, right;
    public Step leftStep, rightStep;

    public bool rightWasLast; //true if last step was made with right leg
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
            Debug.Log("left foot is grounded");
            rightStep.canStep = true;
        }
        if (Physics.Raycast(rayRight, out hitRight, rayLength))
        {
            Debug.Log("right foot is grounded");
            leftStep.canStep = true;
        }

        if(rightWasLast == false)
        {
            rightStep.canStep = true;
            leftStep.canStep = false;
        }
        else
        {
            rightStep.canStep = false;
            leftStep.canStep = true;
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
