using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SerialController))]
public class SerialEventDispatcher : MonoBehaviour
{
    string cfg = Application.streamingAssetsPath + "/cfg.ini";
    [Tooltip("Use one event for each trigger")]
    public UnityEvent<string>[] eventDispatch;

    SerialController sc;
    // Start is called before the first frame update
    void Awake()
    {
        sc = GetComponent<SerialController>();

        if (File.Exists(cfg)){
            string[] data = File.ReadAllLines(cfg);
            string port = data[0];
            Debug.Log(port);
            if (port != "")
                sc.portName = port;
            if (data.Length > 1 && int.TryParse(data[1], out int maxMsg)){
                sc.maxUnreadMessages = maxMsg;
            } else {
                Debug.Log(data[1]);
            }
        }
        else{
            Debug.LogWarning($"config file {cfg} not found");
        }

    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        if (msg != null){

            string[] split = msg.Split(':');

            if (split.Length > 0){
                if (int.TryParse(split[0], out int triggerIndex) && triggerIndex < eventDispatch.Length){ // try to get index from first part and check if it is within range
                    string message = split.Length > 1 ? split[1] : ""; // check if parameters exist to be sent

                    eventDispatch[triggerIndex].Invoke(message);
                }
            }
        }
    }
    
    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success) {
        string status = success ? "success" : "fail";
        Debug.Log($"Connection {status}");
    }
}
