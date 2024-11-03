using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Time;
using static RocketGameManager;

public class RocketPhysics : MonoBehaviour
{


    public BasicRocketComponent rocketObject;


    public static void begin(){
        hasStarted = true;
    }
    public static bool hasStarted;

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

        //Manages user input
        RocketGameManager.checkKeys();
        

        //runs the game if it has started
        if(hasStarted){

            rocketObject.yVelocity += rocketObject.getAcceleration(timeElapsed);
            rocketObject.burnFuel(timeElapsed);
            

            if((transform.position + new Vector3(0, rocketObject.yVelocity, 0)).y > 0){
                transform.position += new Vector3(0, rocketObject.yVelocity, 0);
            }
            else{
                transform.position = new Vector3(0, 0, 0);
                if(rocketObject.yVelocity < 20){
                    rocketObject.yVelocity = 0;
                }
                else{
                    rocketObject.explode();
                }
            }
        }

        this.oldTime = Time.time;
    }
}