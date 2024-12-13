using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class Steering : MonoBehaviour
{

    public GameObject player;
    public GameObject car;

    public Vector3 wheelOffset;  

    public float yRotation;

    public InputActionReference accelerate;
    public InputActionReference brake;
    public InputActionReference steering;


    // Wheel position changed
    public void Update()
    {

            if(accelerate.action.ReadValue<float>() > 0)
            {
                car.GetComponent<Rigidbody>().AddForce(car.transform.forward * 100 * accelerate.action.ReadValue<float>());
            }
            
            if(brake.action.ReadValue<float>() > 0)
            {
                car.GetComponent<Rigidbody>().AddForce(-car.transform.forward * 100 * brake.action.ReadValue<float>());
                
            }

        //set the player position to the cars position + the wheel offset
        player.transform.position = car.transform.position + wheelOffset;

        //Set rotation of the car to the steering value
        yRotation = steering.action.ReadValue<Vector2>().x;
        car.transform.Rotate(0, yRotation, 0);
        //player.transform.Rotate(0, yRotation, 0);



        
    }


    
}
