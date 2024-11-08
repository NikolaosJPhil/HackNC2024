using UnityEngine;
using System.Collections.Generic;
using static RocketGameManager;

//private List<BasicRocketComponent> children = new List<BasicRocketComponent>();

public class BasicRocketComponent{

    //in kg per liter
    private float fuelDensity = 0.810f;
    //in N per liter: should be around 45
    private float fuelEnergy = 50;
    // as a fraction of velocity
    private float airResistance = 0.05f;

    public float relativeCenterOfMassX;

    public float emptyMass;

    public float xVelocity = 0;
    public float yVelocity = 0;

    public float yOffset = 0;

    public float enginePower = 0;

    // default is 0
    public float fuelLeft = 0;

    public BasicRocketComponent(float massOffsetX, float massKG, float accelerationForce, float fuel){
        this.relativeCenterOfMassX = massOffsetX;
        this.emptyMass = massKG;
        this.fuelLeft = fuel;
        this.enginePower = accelerationForce;
        //RocketGameManager.addComponent(this);
    }

    public float getCurrentMass(){
        return this.emptyMass + (this.fuelLeft * this.fuelDensity);
    }

    public float getFuelBurnRate(){
        return 20;
    }

    private float getFuelBurnt(float time){
        return time*getFuelBurnRate();
    }

    // depracates the fuel by the required amount. 
    public void burnFuel(float burnRate, float time){
        this.fuelLeft -= burnRate;
        float initialFuel = RocketGameManager.totalFuel;
        RocketGameManager.totalFuel -= burnRate;

        if(this.fuelLeft < 0){
            this.fuelLeft = 0;
        }

        if(RocketGameManager.totalFuel < 0){
            RocketGameManager.totalFuel = 0;
        }

        RocketGameManager.totalMass -= (initialFuel-RocketGameManager.totalFuel)*fuelDensity;
    }

    public float getGravityPerSecond(){
        return 9.8f;
    }

    public float getAirResistence(){
        //square the absolute velocity and then multiply by the air resistance factor. 
        //Returns positive for positive velocities and negative for negative ones
        return this.yVelocity* this.yVelocity * airResistance * ((yVelocity > 0)? 1 : -1);
    }

    public float getCurrentEnginePower(){
        float engineForce = RocketGameManager.totalThrust;
        if(RocketGameManager.totalFuel - RocketGameManager.totalFuelBurnt <= 0){
            engineForce = 0;
        }
        return engineForce;
    }

    //returns the acceleration after factoring in gravity and air resistence
    public float getAcceleration(float power, float currentMass, float time){
        return (getCurrentEnginePower()/currentMass - this.getGravityPerSecond() - this.getAirResistence())*time;
    }

    public float explode(){
        return 0;
    }

    public void addChild(){

    }

    public List<BasicRocketComponent> children = new List<BasicRocketComponent>();
    public List<BasicRocketComponent> parent = new List<BasicRocketComponent>();

}