using static BasicRocketComponent;


public class GetDefaultComponentConfigs{

    public static BasicRocketComponent getDefaultCockpit(){
        
        return new BasicRocketComponent(0,30,1090,80);
    }

    public static BasicRocketComponent getDefaultFuelTank(){
        return new BasicRocketComponent(0,30,0,350);
    }

    public static BasicRocketComponent getDefaultBoosters(){
        return new BasicRocketComponent(0,30,0,350);
    }

}