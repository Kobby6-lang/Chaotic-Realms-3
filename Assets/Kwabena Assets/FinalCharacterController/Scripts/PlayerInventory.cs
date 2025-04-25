using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfBones {  get; private set; }

    public void BonesCollected() 
    {
        NumberOfBones++;
    }
}
