using UnityEngine;

public class LockYPosition : MonoBehaviour
{

    public float yPosition = 1.3614f;   
 // Update is called once per frame
    void Update()
    {
        LockY();
    }


       void LockY()
    {
        // Lock the Y position of the object
        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }   
}
