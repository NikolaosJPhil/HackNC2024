using UnityEngine;

public class RocketPhysics : MonoBehaviour
{

    BasicRocketComponent rocketObject; 

    //public float xPosition;
    //public float yPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rocketObject = new BasicRocketComponent(new Vector2(0f,0f), 300f,  new Vector2(0f,350f*10f), 400.0);
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
}
