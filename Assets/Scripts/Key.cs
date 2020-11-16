using System;
using System.Collections;
using System.Collections.Generic;
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

    private void OnTriggerStay2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character)
        {
            if (!character.beingDragged && !character.keyToMoveTo)
            {
                character.MoveTowardsPlaceableArea(placeableArea, this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
