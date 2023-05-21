using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScan : MonoBehaviour
{
    public Color from, to;
    public float transitionTime;

    public void Send(LED_Controller target){
        target.Scan(from, to, transitionTime);
    }
}
