using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class Steering : MonoBehaviour
{

    public GameObject wheel;
    public GameObject player;
    public GameObject sphere;

    public Vector3 wheelOffset;  

    public float yRotation;


    // Wheel position changed
    public void Update()
    {

        yRotation = wheel.GetComponent<UnityEngine.XR.Content.Interaction.XRKnob>().value * 360;  
        Debug.Log(yRotation);
        ///Change only the y rotation, keep the x and z rotation the same
        player.transform.rotation = Quaternion.Euler(player.transform.rotation.eulerAngles.x, yRotation, player.transform.rotation.eulerAngles.z);
        sphere.transform.rotation = Quaternion.Euler(sphere.transform.rotation.eulerAngles.x, yRotation, sphere.transform.rotation.eulerAngles.z);

        // Set the XR Rig position to be the same as the wheel, -1 on the z axis
        Vector3 newPosition = wheel.transform.position;
        newPosition += wheelOffset;
        player.transform.position = newPosition;
        
    }

    
}
