using UnityEngine;
using System.Collections.Generic;

//private List<BasicRocketComponent> children = new List<BasicRocketComponent>();

public class BasicRocketComponent{

    //in kg per liter
    private float fuelDensity = 0.810f;
    //in N per liter: should be around 45
    private float fuelEnergy = 50;
    // as a fraction of velocity
    private float airResistance = 0.5f;

    public float relativeCenterOfMassX;

    public float emptyMass;

    public float xVelocity = 0;
    public float yVelocity = 0;

    public float enginePower = 0;

    // default is 0
    public float fuelLeft = 0;

    public BasicRocketComponent(float massOffsetX, float massKG, float accelerationForce, float fuel){
        this.relativeCenterOfMassX = massOffsetX;
        this.emptyMass = massKG;
        this.fuelLeft = fuel;
        this.enginePower = accelerationForce;
    }

    public float getCurrentMass(){
        return this.emptyMass + (this.fuelLeft * this.fuelDensity);
    }

    private float getFuelBurnRate(){
        return enginePower/fuelEnergy;
    }

    private float getFuelBurnt(float time){
        return time*getFuelBurnRate();
    }

    // depracates the fuel by the required amount. 
    public void burnFuel(float time){
        this.fuelLeft -= getFuelBurnt(time);
        if(this.fuelLeft < 0){
            this.fuelLeft = 0;
        }
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
        float engineForce = enginePower;
        if(this.fuelLeft <= 0){
            engineForce = 0;
        }
        return engineForce;
    }

    //returns the acceleration after factoring in gravity and air resistence
    public float getAcceleration(float time){
        return (this.getCurrentEnginePower()/this.getCurrentMass() - this.getGravityPerSecond() - this.getAirResistence())*time;
    }

    public float explode(){
        return 0;
    }

    public void addChild(){

    }

    public List<BasicRocketComponent> children = new List<BasicRocketComponent>();
    public List<BasicRocketComponent> parent = new List<BasicRocketComponent>();

}