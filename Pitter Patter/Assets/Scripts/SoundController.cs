using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip[] notes;

    AudioSource audioSource;
    Dictionary<string, string> songDictionary;
    string[] knownSongs;
    string playerNotes;
    int idleTimeSetting = 1;
    float lastTimeIdle;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        songDictionary = new Dictionary<string, string>();
        songDictionary.Add("song1", "0123");

        knownSongs = new string[songDictionary.Count]; //for testing purposes
        knownSongs[0] = songDictionary["song1"];

        playerNotes = "";
        lastTimeIdle = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            playerNotes += "0";
            audioSource.clip = notes[0];
            audioSource.Play();

            lastTimeIdle = Time.time;
        }
        else if (Input.GetKeyDown("k"))
        {
            playerNotes += "1";
            audioSource.clip = notes[1];
            audioSource.Play();

            lastTimeIdle = Time.time;
        }
        else if (Input.GetKeyDown("l"))
        {
            playerNotes += "2";
            audioSource.clip = notes[2];
            audioSource.Play();

            lastTimeIdle = Time.time;
        }
        else if (Input.GetKeyDown(";"))
        {
            playerNotes += "3";
            audioSource.clip = notes[3];
            audioSource.Play();

            lastTimeIdle = Time.time;
        }

        foreach (string s in knownSongs)
        {
            if (playerNotes.Contains(s))
            {
                Debug.Log("played known song");
            }
        }
        
        if (IdleCheck())
        {
            Debug.Log("idle");
            playerNotes = "";
        }
        Debug.Log(playerNotes);

    }
    

    private bool IdleCheck()
    {
        return Time.time - lastTimeIdle > idleTimeSetting;
    }
}
