using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundPointManager : Singleton<SoundPointManager>
{
    private const float destroyDelay = 6.0F;

    public void PlaySoundAtPoint(Vector3 position, GameObject soundPrefab)
    {
        var soundObject = GameObject.Instantiate<GameObject>(soundPrefab);
        soundPrefab.transform.position = position;
        Destroy(soundObject);
    }
}
