using static BasicRocketComponent;
using UnityEngine.InputSystem;
using static RocketPhysics;
using UnityEngine;


public class RocketGameManager
{

    //private static bool 
    public static void checkKeys(){
        //starts the game when you press spacebar
        if(Input.GetKeyDown("space")){
            RocketPhysics.hasStarted = true;
        }
        if(Input.GetKeyDown("backspace")){
            RocketPhysics.hasStarted = false;
        }
        if(Input.GetKeyDown("w")){
            
        }
        if(Input.GetKeyDown("s")){
            
        }
    }   


}