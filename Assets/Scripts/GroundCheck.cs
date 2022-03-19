using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Transform body;
    public float DistanceToGround;

    void FixedUpdate()
    {
        
        Ray ray1 = new Ray(transform.position, Vector3.down); //Raycast 1 - "down"
        //Ray ray2 = new Ray(transform.position, Vector3.up); //Raycast 1 - "up"
        RaycastHit hit1;
       // RaycastHit hit2;
      // if(Physics.SphereCast(transform.position, castRadius, Vector3.down, out hit,  DistanceToGround))
        if (Physics.Raycast(ray1, out hit1, DistanceToGround + 1f))
        {
            Vector3 footPosition = hit1.point;
            footPosition.y += DistanceToGround;
            transform.position = footPosition;
        }
        //if (Physics.Raycast(ray2, out hit2, DistanceToGround + 1f))
        //{
        //    Vector3 footPosition = hit2.point;
        //    footPosition.y += DistanceToGround;
        //    transform.position = footPosition;
        //}
        Debug.DrawRay(transform.position, hit1.point, Color.red);
       // Debug.DrawRay(transform.position, hit2.point, Color.red);
    }

    private void Update()
    {
        transform.position = new Vector3(body.transform.position.x, transform.position.y, body.transform.position.z);
    }

}
