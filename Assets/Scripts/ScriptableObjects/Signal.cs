using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

// Sits in memory to tell the signallistner what to do
public class Signal : ScriptableObject
{
    // List of what is listening to this class
    public List<SignalListener> Listeners = new List<SignalListener>();

    public void Raise()
    {
        // Loops through listners and raises a method
        // Loops backwards incase something is removed, it will not cause an error
        for (int i = Listeners.Count -1; i >= 0; i--)
        {
            Listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listner)
    {
        // Registers what is listening to the list
        Listeners.Add(listner);
    }

    public void DeRegisterListener(SignalListener listener)
    {
        // Deregisters listeners from the list
        Listeners.Remove(listener);
    }
}
