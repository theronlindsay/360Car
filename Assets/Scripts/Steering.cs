using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class Steering : MonoBehaviour
{

    public XRKnob wheel;
    public GameObject player;

    public Vector3 wheelOffset;  


    // Wheel position changed
    public void Update()
    {

        float yRotation = wheel.value * 360f;

        //Change only the y rotation, keep the x and z rotation the same
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);

        // Set the XR Rig position to be the same as the wheel, -1 on the z axis
        Vector3 newPosition = wheel.transform.position;
        newPosition += wheelOffset;
        player.transform.position = newPosition;
        
    }

    
}
