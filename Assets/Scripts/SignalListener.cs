using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Attaches to game objects waiting for signal to send commands
public class SignalListener : MonoBehaviour
{
    public Signal Signal;
    public UnityEvent SignalEvent;

    public void OnSignalRaised()
    {
        // Calls wahat ever the event is
        SignalEvent.Invoke();
    }

    private void OnEnable()
    {
        // registers method on signal class
        Signal.RegisterListener(this);        
    }

    private void OnDisable()
    {
        // deregisters method on signal class
        Signal.DeRegisterListener(this);
    }
}
