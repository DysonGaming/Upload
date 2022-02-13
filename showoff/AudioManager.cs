using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioSource[] MusicSongs;

    public int songNumber = 0;
    public int check = 0;

    public void playEnemy () 
    {
        MusicSongs[0].Play();
    }

    public void playPirate () 
    {
        MusicSongs[1].Play();
    }

    public void playStarWars () 
    {
        MusicSongs[2].Play();
    }

    public void playMeme () 
    {
        MusicSongs[3].Play();
    }

    public void playEpic () 
    {
        MusicSongs[4].Play();
    }

    public void StartSongs() 
    {     
        songNumber = Random.Range(0,MusicSongs.Length);

        switch (songNumber) 
        {
            case 0:
                playEnemy(); 
                break;

            case 1:
                playPirate();
                break;

            case 2:
                playStarWars();
                break;

            case 3:
                playMeme();
                break;

            case 4:
                playEpic();
                break;

        }  

        check = 1;
    }

    void Update() 
    {
        if (check == 1) 
        {
            if (!MusicSongs[songNumber].isPlaying) 
            {
                StartSongs();
            }
        }
    }

}
// Start script. Find en random sang, når sangen IKKE spiller længere så genstart scriptet.