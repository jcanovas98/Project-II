using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Objeto : MonoBehaviour
{    
    /*private float maxDistance = 0.5f;
    private GameObject _Player;
    InventorySystem inventory;
    public bool close;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.Find("Player");
        inventory = _Player.GetComponent<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        close = PlayerClose();
        if (PlayerClose())
        {
            if(Input.GetKeyDown("e"))
            {
                inventory.AddItem(gameObject, 0);
                Destroy(gameObject);
            }
            
        }
            
    }

    private bool PlayerClose()
    {
        var dist = Vector3.Distance(gameObject.transform.position, _Player.transform.position);
        return dist < maxDistance;
    }

    void OnTriggerStay2D(Collider2D _itemCollider)
    {
        
        if (gameObject.tag == "Pickable" && Input.GetButtonDown(_inputM.Square))
        {
            //COJER OBJETO (CUADRADO)
            for (int i = 0; i < _inventory.slots.Length; i++)
            {
                if (!_inventory.isFull[i])
                {
                    Instantiate(_itemCollider.gameObject.GetComponent<ItemController>().imageItem, _inventory.slots[i].transform, false);
                    _inventory.AddItem(_itemCollider.gameObject, i);
                    break;
                }
            }

        }

    }*/
}
