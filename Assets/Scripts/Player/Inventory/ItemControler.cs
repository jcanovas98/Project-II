using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControler : MonoBehaviour
{
    PlayersManager PM;
    public string itemType;
    public GameObject imageItem;
    public int Type;

    private float maxDistance = 0.5f;    
    InventorySystem inventory;    
    public bool close;

    void Start()
    {        
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();
        inventory = GameObject.Find("Players").GetComponent<InventorySystem>();
    }
    
    
    void Update()
    {
        close = PlayerClose();
        if (PlayerClose())
        {
            if (Input.GetKeyDown("e"))
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (!inventory.isFull[i])
                    {
                        Instantiate(imageItem, inventory.slots[i].transform, false);
                        inventory.AddItem(gameObject, i);
                        break;
                    }
                }                
                Destroy(gameObject);
            }

        }

    }

    private bool PlayerClose()
    {
        var dist = Vector3.Distance(gameObject.transform.position, GameObject.Find("Players").transform.GetChild(0).transform.position);
        return dist < maxDistance;
    }

    void SetItemType(string _itemType)
    {
        itemType = _itemType;
    }   

    
}
