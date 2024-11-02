using UnityEngine;
using UnityEngine.InputSystem;

public class RocketPhysics : MonoBehaviour
{

    BasicRocketComponent rocketObject;

    public bool hasStarted;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasStarted = false;
        rocketObject = new BasicRocketComponent(0,0,300,3300,150);
    }
 
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown("space")){
            hasStarted = true;
        }

        if(hasStarted){
            rocketObject.yVelocity += rocketObject.y
            transform.position += new Vector3(0, 0.001f, 0);
        }
    }
}
