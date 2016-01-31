using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    private float bpm = 103;

    [SerializeField]
    private AudioSource firstLayer;
    [SerializeField]
    private AudioSource secondLayer;
    [SerializeField]
    private AudioSource franticLayer;

    [SerializeField]
    private Transform p1Trans;
    [SerializeField]
    private Transform p2Trans;
    [SerializeField]
    private float proximetryThreshold = 25f;
    [SerializeField]
    private float ProximetryMax = 5f;

    public bool Frantic {get; set;}

    private bool fadingOut;
    private bool fadingIn;

    void Update()
    {
        float distance = Vector3.Distance(p1Trans.position, p2Trans.position);
        float volume = (ProximetryMax - distance) / (ProximetryMax - proximetryThreshold);
        secondLayer.volume = volume;
        secondLayer.volume = 1 - secondLayer.volume;

        if (Frantic && firstLayer.volume != 0 && !fadingOut)
        {
            StartCoroutine(FadeOut(firstLayer));
            StartCoroutine(FadeOut(secondLayer));
            franticLayer.volume = 1;
        }
        else if (!Frantic && firstLayer.volume != 1 && !fadingIn)
        {
            StartCoroutine(FadeIn(firstLayer));
            StartCoroutine(FadeIn(secondLayer));
            franticLayer.volume = 0;
        }
    }

    IEnumerator FadeIn (AudioSource source)
    {
        fadingIn = true;
        fadingOut = false;
        while (source.volume < 1 && !fadingOut)
        {
            source.volume += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        fadingIn = false;
    }
    IEnumerator FadeOut (AudioSource source)
    {
        fadingIn = false;
        fadingOut = true;
        while (source.volume > 0 && !fadingIn)
        {
            source.volume -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        fadingOut = false;
    }

}
