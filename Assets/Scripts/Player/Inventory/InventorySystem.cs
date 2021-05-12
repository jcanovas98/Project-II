using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    PlayersManager PM;

    public bool[] isFull;
    public GameObject[] slots;
    public string[] strSlots;

    public GameObject slotSelector;
    private GameObject ObjectsHierarchy;
    private Transform Player;

    public GameObject Lighter;
    public GameObject Radio;
    public GameObject OIL;
    public GameObject Sagrado;
    public GameObject Cristal;


    public void Start()
    {
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        ObjectsHierarchy = GameObject.Find("Objetos");
    }

    

    public void AddItem(GameObject _item, int slot)
    {
        strSlots[slot] = _item.GetComponent<ItemControler>().itemType;
        isFull[slot] = true;
        Destroy(_item);
    }

    public void RemoveItem(int slot)
    {
        Destroy(slots[slot].transform.GetChild(0).gameObject);
        strSlots[slot] = null;
        isFull[slot] = false;
    }

    public void DropItem(int slot)
    {
        Player = PM.Players[0].gameObject.transform;
        if (CheckItems(strSlots[slot]) != null && CheckItems(strSlots[slot]) != Lighter && CheckItems(strSlots[slot]) != Radio)
        {
            Instantiate(CheckItems(strSlots[slot]), Player.position - new Vector3(0, 0.5f, 0), Player.rotation, ObjectsHierarchy.transform);
            RemoveItem(slot);
        }
        
    }

    public GameObject CheckItems(string slot)
    {
        switch (slot)
        {
            case "Lighter":
                return Lighter;

            case "Radio":
                return Radio;

            case "Oil":
                return OIL;

            case "Sagrado":
                return Sagrado;

            case "Cristal":
                return Cristal;           

            default:
                return null;

        }
    }

    public void HighlightSlot(int slot)
    {
        slotSelector.transform.position = slots[slot].transform.position;
    }
}
