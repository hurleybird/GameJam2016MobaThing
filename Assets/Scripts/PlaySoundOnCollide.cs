using UnityEngine;
using System.Collections;

public class PlaySoundOnCollide : MonoBehaviour
{
    [SerializeField]
    private AudioClip soundToPlay;

    private void OnCollisonEnter(Collision other)
    {

    }
}
