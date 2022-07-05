using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();

    [SerializeField]
    private GameObject handOne;
    [SerializeField]
    private GameObject handTwo;

    private int handOneCurrentObj = 0;
    private int handTwoCurrentObj = 0;

    public int inventoryIndex = 0;

    public int targetFrameRate = 30;

    private void Start()
    {
        // sets the framerate to 30 and turns vSync off to prevent extreme GPU usage
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && handOne.transform.childCount == 0 && inventory[inventoryIndex].gameObject.activeSelf == false)
        {
            inventory[inventoryIndex].gameObject.SetActive(true);
            handOneCurrentObj = inventoryIndex;
            Instantiate(inventory[inventoryIndex], handOne.transform.position, Quaternion.identity, handOne.transform);
        }
        else if (Input.GetKeyDown(KeyCode.E) && handOne.transform.childCount == 1) 
        {
            inventory[handOneCurrentObj].SetActive(false);
            Object.Destroy(handOne.transform.GetChild(0).gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Q) && handTwo.transform.childCount == 0 && inventory[inventoryIndex].gameObject.activeSelf == false)
        {
            inventory[inventoryIndex].gameObject.SetActive(true);
            handTwoCurrentObj = inventoryIndex;
            Instantiate(inventory[inventoryIndex], handTwo.transform.position, Quaternion.identity, handTwo.transform);
        }
        else if (Input.GetKeyDown(KeyCode.Q) && handTwo.transform.childCount == 1) 
        {
            inventory[handTwoCurrentObj].gameObject.SetActive(false);
            Object.Destroy(handTwo.transform.GetChild(0).gameObject);
        }
    }

    public void adjustInventoryIndex(int adjusment) 
    {
        if (inventoryIndex + adjusment <= inventory.Count -1 && adjusment > 0) // If the new amount will be lower then the amount of items in the inventory and higher then the index we let the index go higher.
        {
            inventoryIndex += adjusment;
        }
        else if (inventoryIndex + adjusment >= 0 && adjusment < 0 )
        {
            inventoryIndex += adjusment;
        }
    }
}
