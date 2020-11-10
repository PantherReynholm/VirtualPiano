using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChord : MonoBehaviour
{
    Key[] keys;

    private void Start()
    {
        keys = FindObjectsOfType<Key>();
    }

    public void Play()
    {
        List<Key> playedKeys = new List<Key>();

        foreach (Key key in keys)
        {
            if (key.shallPlayKey)
            {
                playedKeys.Add(key);
            }
        }

        foreach (Key key in playedKeys)
        {
            print(key.name);
            key.PlayKey();
        }
    }
}
