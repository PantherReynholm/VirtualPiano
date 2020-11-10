using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Key : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip pianoSound;
    [Range(0, 1)] public float volume = 0.5f;
    PlaceableArea placeableArea;

    public bool shallPlayKey = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        placeableArea = GetComponentInChildren<PlaceableArea>();

        audioSource.clip = pianoSound;
        audioSource.volume = volume;
    }

    private void Update()
    {
        DoesKeyContainCharacter();
    }

    private void DoesKeyContainCharacter()
    {
        if (placeableArea.containsCharacter)
        {
            shallPlayKey = true;
        }
        else
        {
            shallPlayKey = false;
        }
    }

    public void PlayKey()
    {
        AudioSource.PlayClipAtPoint(pianoSound, Camera.main.transform.position);
    }
}
