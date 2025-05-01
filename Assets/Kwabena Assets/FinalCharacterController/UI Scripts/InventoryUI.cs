using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI boneText;

    // Start is called before the first frame update
    void Start()
    {
        boneText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateBoneText(PlayerInventory playerInventory)
    {
        boneText.text = playerInventory.NumberOfBones.ToString();
    }
}
