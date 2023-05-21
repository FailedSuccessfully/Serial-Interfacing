using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFlicker : MonoBehaviour
{
    public Color colorA, colorB;
    public float duration, interval;

    public void Send(LED_Controller target){
        target.Flicker(colorA, colorB, duration, interval);
    }
}
