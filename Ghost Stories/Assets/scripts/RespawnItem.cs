using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script causes an item to respawn at its original x, y, and z coordinates
 * after having been a certain distance after a certain amount of time.
 * :PARAMS: original x, y, and z coordinates. Distance from one of these coordinates before the respawn is queued. Time until item respawns, number of times the item can respawn before
 * it stops respawning.
*/
public class RespawnItem : MonoBehaviour
{

    /*** Get the input from the user ***/

    // Original object coordinates
    public Vector3 originalCoordinates;

    // Distance from the coordinates before the respawn is queued.
    // The object will have to meet each of these distances before it will respawn.
    // This must be a positive number
    public Vector3 distanceFromCoordinatesToTriggerRespawn;

    // Frames until object respawns
    public float framesToRespawn;

    // If the item can respawn an infinite amount of times
    public bool infiniteRespawns;

    // If not, the number of times the item can respawn
    public int numberOfRespawns;


    /*** Global variables ***/

    // We cannot keep the object's current position in a global variable.
    // Instead, we can change the object's current position by using this line of code:
    // transform.position = new Vector3(0, 0, 0);
    // We can replace the zeros with the originalCoordinates.x

    private float distanceFromX;
    private float distanceFromY;
    private float distanceFromZ;

    private int counter = 0;
    private int numberOfRespawnsUsed = 0;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        // Find the distance from the original x coordinate
        distanceFromX = transform.position.x - originalCoordinates.x;
        // Make it a positive number
        if (distanceFromX < 0)
        {
            distanceFromX *= -1;
        }

        // Find the distance from the original y coordinate
        distanceFromY = transform.position.y - originalCoordinates.y;
        // Make it a positive number
        if (distanceFromY < 0)
        {
            distanceFromY *= -1;
        }


        // Find the distance from the original z coordinate
        distanceFromZ = transform.position.z - originalCoordinates.z;
        // Make it a positive number
        if (distanceFromZ < 0)
        {
            distanceFromZ *= -1;
        }

        // Check if the distance of the coordinates is enough to trigger the respawn
        if (distanceFromX >= distanceFromCoordinatesToTriggerRespawn.x && distanceFromY >= distanceFromCoordinatesToTriggerRespawn.y
            && distanceFromZ >= distanceFromCoordinatesToTriggerRespawn.z)
        {
            // Check if the counter is high enough
            if (counter >= framesToRespawn)
            {
                // If it is...
                // Check if there are infinite respawns
                if (infiniteRespawns)
                {
                    // If there are infinite respawns, respawn the object
                    transform.position = new Vector3(originalCoordinates.x, originalCoordinates.y, originalCoordinates.z);
                }
                // Else, if there are no infinite respawns
                else
                {
                    // Check to see if you still have respawns left
                    if (numberOfRespawnsUsed < numberOfRespawns)
                    {
                        // If you do, respawn the object
                        transform.position = new Vector3(originalCoordinates.x, originalCoordinates.y, originalCoordinates.z);

                        // Incremenet the number of respawns used
                        numberOfRespawnsUsed++;
                    }
                    else
                    {
                        // If you have no respawns left...
                        // Do nothing.
                    }

                }

            }
            // If the counter is not high enough yet...
            else
            {
                // Incremenet the counter
                counter++;
            }


        }

        else
        {
            // If the object is not far enough to respawn, change the counter back to 0
            counter = 0;
        }

        

        

    }
}
