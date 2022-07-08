using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InventoryManager inventoryManager;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            inventoryManager.adjustInventoryIndex(1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            inventoryManager.adjustInventoryIndex(-1);
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            if (inventoryManager.handOne.transform.childCount != 0)
            {
                switch (inventoryManager.handOne.transform.GetChild(0).gameObject.name.Replace("(Clone)", ""))
                {
                    case "Flashlight":
                        inventoryManager.handOne.transform.GetChild(0).gameObject.GetComponent<Flashlight>().useObject();
                        break;

                    case "Rock":
                        inventoryManager.DeleteItemFromInventory("Rock");
                        inventoryManager.handOne.transform.GetChild(0).gameObject.GetComponent<Rock>().Throw();
                        break;

                    case "Hat":
                        inventoryManager.handOne.transform.GetChild(0).gameObject.transform.parent = inventoryManager.head.gameObject.transform;
                        inventoryManager.head.transform.GetChild(0).gameObject.transform.localPosition = new Vector3();
                        break;

                    case "Gun":
                        inventoryManager.handOne.transform.GetChild(0).gameObject.GetComponent<Gun>().Shoot();
                        break;

                    case "Ammo Clip":
                        if (inventoryManager.handTwo.transform.GetChild(0).gameObject.name.Replace("(Clone)", "") == "Gun" && inventoryManager.handTwo.transform.GetChild(0).gameObject.GetComponent<Gun>().bulletsInGun == 0) 
                        {
                            inventoryManager.DeleteItemFromInventory("AmmoClip");
                            Destroy(inventoryManager.handOne.transform.GetChild(0).gameObject);
                            inventoryManager.handTwo.transform.GetChild(0).gameObject.GetComponent<Gun>().AddAmmoClip();
                        }
                        break;
                }
            }
            else if (inventoryManager.handOne.transform.childCount == 0 && inventoryManager.head.transform.childCount != 0) 
            {
                inventoryManager.head.transform.GetChild(0).gameObject.transform.parent = inventoryManager.handOne.gameObject.transform;
                inventoryManager.handOne.transform.GetChild(0).gameObject.transform.localPosition = new Vector3();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (inventoryManager.handTwo.transform.childCount != 0)
            {
                switch (inventoryManager.handTwo.transform.GetChild(0).gameObject.name.Replace("(Clone)", ""))
                {
                    case "Flashlight":
                        inventoryManager.handTwo.transform.GetChild(0).gameObject.GetComponent<Flashlight>().useObject();
                        break;

                    case "Rock":
                        inventoryManager.DeleteItemFromInventory("Rock");
                        inventoryManager.handTwo.transform.GetChild(0).gameObject.GetComponent<Rock>().Throw();
                        break;

                    case "Hat":
                        inventoryManager.handTwo.transform.GetChild(0).gameObject.transform.parent = inventoryManager.head.gameObject.transform;
                        inventoryManager.head.transform.GetChild(0).gameObject.transform.localPosition = new Vector3();
                        break;

                    case "Gun":
                        inventoryManager.handTwo.transform.GetChild(0).gameObject.GetComponent<Gun>().Shoot();
                        break;

                    case "Ammo Clip":
                        if (inventoryManager.handOne.transform.GetChild(0).gameObject.name.Replace("(Clone)", "") == "Gun" && inventoryManager.handOne.transform.GetChild(0).gameObject.GetComponent<Gun>().bulletsInGun == 0)
                        {
                            inventoryManager.DeleteItemFromInventory("AmmoClip");
                            Destroy(inventoryManager.handTwo.transform.GetChild(0).gameObject);
                            inventoryManager.handOne.transform.GetChild(0).gameObject.GetComponent<Gun>().AddAmmoClip();
                        }
                        break;
                }
            }
            else if (inventoryManager.handTwo.transform.childCount == 0 && inventoryManager.head.transform.childCount != 0)
            {
                inventoryManager.head.transform.GetChild(0).gameObject.transform.parent = inventoryManager.handTwo.gameObject.transform;
                inventoryManager.handTwo.transform.GetChild(0).gameObject.transform.localPosition = new Vector3();
            }
        }
    }
}
