using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Time;

public class RocketPhysics : MonoBehaviour
{

    BasicRocketComponent rocketObject;

    public bool hasStarted;

    private float oldTime = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasStarted = false;
        rocketObject = new BasicRocketComponent(0,30,1090,80);
    }
 
    // Update is called once per frame
    void Update()
    {
        //gets the time since last frame for acceleration and fuel burning calculations
        float timeElapsed = Time.time-this.oldTime;
        
        //starts the game when you press spacebar
        if(Input.GetKeyDown("space")){
            hasStarted = true;
        }

        //runs the game if it has started
        if(hasStarted){

            rocketObject.yVelocity += rocketObject.getAcceleration(timeElapsed);
            rocketObject.burnFuel(timeElapsed);
            

            if((transform.position + new Vector3(0, rocketObject.yVelocity, 0)).y > 0){
                transform.position += new Vector3(0, rocketObject.yVelocity, 0);
            }
            else{
                transform.position = new Vector3(0, 0, 0);
            }
        }

        this.oldTime = Time.time;
    }
}