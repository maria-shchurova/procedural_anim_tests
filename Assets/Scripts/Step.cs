using UnityEngine;

public class Step : MonoBehaviour
{
    public Transform foot;
    public Transform body;
    public Transform stepTarget;
    public float MaxDistance_targetToFoot;
    public float MinDistance_targetToFoot;    
    
   // public float MaxDistance_targetToBody;
    //public float MinDistance_targetToBody;
    public float stepHeight;
    public float speed = 10;

    bool needStep = false;
   // bool needCrunch = false;
    void MoveFoot(Vector3 target)
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        if(Vector3.Distance(foot.position, stepTarget.position) >= MaxDistance_targetToFoot / 2) //FIRST HALF OF STEP, add vector3.up
            foot.position = Vector3.MoveTowards(foot.position, stepTarget.position + Vector3.up * stepHeight, step);
        else 
            foot.position = Vector3.MoveTowards(foot.position, stepTarget.position, step);

        if(Vector3.Distance(foot.position, stepTarget.position) < MinDistance_targetToFoot)
            needStep = false;
    }

    //void CrunchBody()
    //{
    //    float step = speed * Time.deltaTime; 
    //    body.position = Vector3.MoveTowards(body.position, stepTarget.position, step);

        //if (Vector3.Distance(body.position, stepTarget.position) < MinDistance_targetToBody)
        //    needCrunch = false;
    //}

    void FixedUpdate()
    {
        if (Vector3.Distance(foot.position, stepTarget.position) > MaxDistance_targetToFoot) //if target is out of foot's reach
        {
            needStep = true;
        }

        //if (Vector3.Distance(stepTarget.position, body.position) > MaxDistance_targetToBody)//if target is too far from body
        //{
        //    needCrunch = true; //crunch
        //}
    }

    private void Update()
    {
        if (needStep)
            MoveFoot(stepTarget.position);

        //if (needCrunch)
        //    CrunchBody();
    }
}
