using System;
using System.Collections.Generic;
using UnityEngine;

public class CenterTableLogic : MonoBehaviour
{
    [SerializeField]
    private Rotate tableRotate;

    [SerializeField]
    private Capturable cap1;
    [SerializeField]
    private Capturable cap2;

    [SerializeField]
    private GameObject redParticles1;
    [SerializeField]
    private GameObject redParticles2;
    [SerializeField]
    private GameObject blueParticles1;
    [SerializeField]
    private GameObject blueParticles2;


    public void Update()
    {

        if (cap1.Team == null)
        {
            redParticles1.SetActive(false);
            blueParticles1.SetActive(false);
        }
        else if (cap1.Team.Side == Allignment.Red)
        {
            redParticles1.SetActive(true);
            blueParticles1.SetActive(false);
        }
        else // Blue
        {
            redParticles1.SetActive(false);
            blueParticles1.SetActive(true);
        }


        if (cap2.Team == null)
        {
            redParticles2.SetActive(false);
            blueParticles2.SetActive(false);
        }
        else if (cap2.Team.Side == Allignment.Red)
        {
            redParticles2.SetActive(true);
            blueParticles2.SetActive(false);
        }
        else // Blue
        {
            redParticles2.SetActive(false);
            blueParticles2.SetActive(true);
        }


        if (cap1.Team != null && cap2.Team != null &&
            cap1.Team.Side == Allignment.Red && cap2.Team.Side == Allignment.Red)
        {
            // SPin
            tableRotate.enabled = true;
        }
        else
        {
            // Don't spin
            tableRotate.enabled = false;
        }

    }
}

