using UnityEngine;

public class RBController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(rb.velocity.magnitude < speed)
        {
            float value = Input.GetAxis("Vertical");
            if (value != 0)
                rb.AddForce(0, 0, value * Time.deltaTime * 1000f);
        }
    }
}
