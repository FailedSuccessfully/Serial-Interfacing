using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFade : MonoBehaviour
{
    public Color color;
    public float fadeInTime, fadeOutTime, restTime;

    public void Send(LED_Controller target){
        target.Fade(color, fadeInTime, fadeOutTime, restTime);
    }
}
