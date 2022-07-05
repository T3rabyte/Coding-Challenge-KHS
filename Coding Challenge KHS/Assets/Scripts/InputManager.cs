using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InventoryManager inventoryManager;

    void LateUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            inventoryManager.adjustInventoryIndex(1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            inventoryManager.adjustInventoryIndex(-1);
        }
    }
}
