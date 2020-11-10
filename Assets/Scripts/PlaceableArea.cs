using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableArea : MonoBehaviour
{
    [HideInInspector] public bool containsCharacter = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        invertPlayState(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        invertPlayState(other);
    }

    void invertPlayState(Collider2D other)
    {
        if (other.transform.GetComponent<Character>())
        {
            containsCharacter = !containsCharacter;
        }
    } 
}
