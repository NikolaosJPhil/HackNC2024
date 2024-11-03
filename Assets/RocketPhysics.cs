using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Time;
using static RocketGameManager;
using static GetDefaultComponentConfigs;

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
        rocketObject = GetDefaultComponentConfigs.getDefaultCockpit();
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

            rocketObject.yVelocity += rocketObject.getAcceleration(RocketGameManager.totalThrust,  RocketGameManager.totalMass, timeElapsed);
            rocketObject.burnFuel(timeElapsed);
            

            if((transform.position + new Vector3(0, rocketObject.yVelocity * timeElapsed, 0)).y > rocketObject.yOffset){
                transform.position += new Vector3(0, rocketObject.yVelocity * timeElapsed, 0);
            }
            else{
                transform.position = new Vector3(0, rocketObject.yOffset, 0);
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