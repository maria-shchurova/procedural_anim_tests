using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Transform body;
    public float Z_offsetFromBody;
    public float X_offsetFromBody;
    public float DistanceToGround;

    void FixedUpdate()
    {
        
        Ray ray1 = new Ray(transform.position, Vector3.down); 
        RaycastHit hit1;

        if (Physics.Raycast(ray1, out hit1, DistanceToGround + 1f))
        {
            Vector3 footPosition = hit1.point;
            footPosition.y += DistanceToGround;
            transform.position = footPosition;
        }

        Debug.DrawRay(transform.position, hit1.point, Color.red);
    }

    private void Update()
    {
        transform.position = new Vector3(body.transform.position.x + X_offsetFromBody, transform.position.y, body.transform.position.z + Z_offsetFromBody);
    }

}
