using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour {

    //Variables privadas---------------------------------

    //Variables publicas----------------------------------
    public bool[] isFull;
    public GameObject[] slots;
    public string[] strSlots;

    public GameObject slotSelector;

    public GameObject fire;
    public GameObject ice;
    public GameObject metal;
    public GameObject crate;


    //Funciones-------------------------------------------
    public void AddItem(GameObject _item, int slot)
    { 
        strSlots[slot] = _item.GetComponent<ItemController>().itemType;
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
        if (CheckItems(strSlots[slot])!=null)
        {
            Instantiate(CheckItems(strSlots[slot]), transform.position + (transform.forward * 2), transform.rotation);
            RemoveItem(slot);
        }
        //ADDFORCE PENDIENTE PARA TIRAR OBJETOS
    }

    public GameObject CheckItems(string slot)
    {
        switch (slot)
        {
            case "Fire":
                return fire;

            case "Ice":
                return ice;

            case "Metal":
                return metal;

            case "Crate":
                return crate;

            default:
                return null;
            
        }
    }

    public void HighlightSlot(int slot)
    {
        slotSelector.transform.position = slots[slot].transform.position;
    }
}
