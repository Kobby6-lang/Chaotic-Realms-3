using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfBones {  get; private set; }

    public UnityEvent<PlayerInventory> OnBonesCollected;

    public void BonesCollected() 
    {
        NumberOfBones++;
        OnBonesCollected.Invoke(this);
    }
}
