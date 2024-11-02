using UnityEngine;

public class RocketPhysics : MonoBehaviour
{
    public GameObject myObject;

    public float xVelocity;
    public float yVelocity;

    //public float xPosition;
    //public float yPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xVelocity = 0;
        yVelocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity += 0.01f;
        transform.position = transform.position + new Vector3(xVelocity,yVelocity,0.0f);
    }
}
