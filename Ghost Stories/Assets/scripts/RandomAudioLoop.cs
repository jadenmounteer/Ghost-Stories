using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script causes a sound to play at random intervals
 *
 *
*/
public class RandomAudioLoop : MonoBehaviour
{
    // Get the audiosource 
    AudioSource myAudio;

    // Grab the random interger ranges from the user
    public int randomRange1;
    public int randomRange2;

    // Default the sound playing to true so it plays from the start
    // Or the user can default to false so waits to play
    public bool soundPlaying;

    // Default the counter to 0
    private int counter = 0;

    // Declare a variable to track the time until the next sound
    private int timeUntilNextSound;

    
    // Start is called before the first frame update
    void Start()
    {
        // Get the audiosource
        myAudio = GetComponent<AudioSource>();

        // Determine the time until the next sound plays
        timeUntilNextSound = Random.Range(randomRange1, randomRange2);

    }
 

    // Update is called once per frame
    void Update()
    {

        // If the sound is playing
        if (soundPlaying == true)
        {
            // Play the sound once and change soundPlaying to true
            myAudio.PlayOneShot(myAudio.clip);
            soundPlaying = false;
        }

        // If soundPlaying is false
        if (soundPlaying == false)
        {
            // Increment the counter
            counter++;
        }

        // If the counter is greater than or equal to the time until the next sound
        if (counter >= timeUntilNextSound)
        {
            // change soundPlaying
            soundPlaying = true;

            // Change the counter back to 0
            counter = 0;

            // Determine the time until the next sound plays
            timeUntilNextSound = Random.Range(randomRange1, randomRange2);
        }    

    }
}
