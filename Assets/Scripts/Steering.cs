using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.Video;

public class Steering : MonoBehaviour
{

    public XRKnob wheel;


    // Wheel position changed
    public void Update()
    {

        float yRotation = wheel.value * 360f;
        Debug.Log("yRotation: " + yRotation);
        Debug.Log("wheel.value: " + wheel.value);

        //Change only the y rotation, keep the x and z rotation the same
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);  
        
        Debug.Log("transform.rotation: " + transform.rotation);
        
         }

    
}
