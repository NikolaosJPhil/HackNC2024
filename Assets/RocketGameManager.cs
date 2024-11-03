using static BasicRocketComponent;
using UnityEngine.InputSystem;
using static RocketPhysics;
using UnityEngine;
using System.Collections.Generic;
using static GetDefaultComponentConfigs;

public class RocketGameManager
{

    public static List<BasicRocketComponent> totalComponents = new List<BasicRocketComponent>();
    public static List<BasicRocketComponent> activeComponents = new List<BasicRocketComponent>();
    public static int discardedComponentCount = 0;

    public static float totalFuel = 200f;
    public static float totalFuelBurnt = 0f;
    public static float fuelBurnRate = 1f;
    public static float totalMass = 1f;
    public static float totalThrust = 1500f;
    public static bool hasStarted = false;


    //private static bool 
    public static void checkKeys(){
        //starts the game when you press spacebar
        if(Input.GetKeyDown("space")){
            hasStarted = true;
        }
        //Resets the game
        if(Input.GetKeyDown("backspace")){
            hasStarted = false;
            totalComponents.Clear();
            activeComponents.Clear();
            discardedComponentCount = 0;
            totalFuel = 0f;
            totalMass = 0f;
        }
            
        //adds fuel tank
        if(Input.GetKeyDown("w")){
            GameObject newObj = new GameObject("" + totalComponents.Count);
            RocketPhysics phys = newObj.AddComponent<RocketPhysics>();
            phys.rocketObject = GetDefaultComponentConfigs.getDefaultFuelTank();

            SpriteRenderer rocketTexture = newObj.AddComponent<SpriteRenderer>();
        }
        if(Input.GetKeyDown("s")){
            GameObject newObj = new GameObject("" + totalComponents.Count);
            RocketPhysics phys = newObj.AddComponent<RocketPhysics>();
            phys.rocketObject = GetDefaultComponentConfigs.getDefaultBoosters();

            SpriteRenderer rocketTexture = newObj.AddComponent<SpriteRenderer>();
        }
    }

    public static void addComponent(BasicRocketComponent newComponent){
        totalFuel += newComponent.fuelLeft;
        totalMass += newComponent.getCurrentMass();
        fuelBurnRate += newComponent.getFuelBurnRate();

        foreach (BasicRocketComponent component in totalComponents){
            component.yOffset += 30;
        }
        totalComponents.Add(newComponent);
    }

    public static void removeComponent(BasicRocketComponent component){
        totalComponents.Remove(component);
        totalFuel -= component.fuelLeft;
        totalMass -= component.getCurrentMass();
        fuelBurnRate -= component.getFuelBurnRate();
    }
}