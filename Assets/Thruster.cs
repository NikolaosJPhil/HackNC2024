public class Thruster: BasicRocketComponent {

    private string thruster;

    private float ThrusterMass;

    private float ThrusterAcceleration;

    //Used if thruster has a built in fuel tank.
    private float maxFuel;

    //How much fuel the thruster burns per second.
    private float burnRate;

    public Thruster(string name, float mass, float acceleration){
        thruster == name;
        ThrusterMass = mass;
        ThrusterAcceleration = acceleration;
    }

}