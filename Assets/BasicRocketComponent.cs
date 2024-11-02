import ArrayList;

public class BasicRocketComponent{

    public float relativeCenterOfMassX;
    public float relativeCenterOfMassY;
    public float mass;

    public float xVelocity = 0;
    public float yVelocity = 0;

    private string parent = "";

    //private ArrayList children = new ArrayList();

// default is 0
    public float fuel = 0;

    public BasicRocketComponent(float massOffsetX, float massOffsetY, float massKG, float accelerationForce, float fuel){
        this.relativeCenterOfMassX = massOffsetX;
        this.relativeCenterOfMassY = massOffsetY;
        this.mass = massKG;
        this.fuel = fuel;
    }

    public void addParent(string newParentName, float positionOffsetX, float positionOffsetY){
        //Unity uses strings to identify objects in a scene, like names. 
        parent = newParent;

        //To access the parent's object:
        GameObject parentObject = new GameObject(newParentName);

        if(parentObject != null){
            
        }

        //refreshes the center of mass
        this.relativeCenterOfMassX = -1* positionOffsetX;
        this.relativeCenterOfMassY = -1* positionOffsetY;
    }

}