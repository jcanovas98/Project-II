using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

    private InventorySystem _inventory;
    PlayersManager PM;

    private GameObject _item;
    private GameObject _itemSelected;
    private GameObject _lighter;
    private bool lighter;

    public int _slot;
  
    void Awake()
    {
        _slot = 0;
        _inventory = GetComponent<InventorySystem>();
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();

    }

    private void Start()
    {
        
        /*_lighter = PM.Players[0].transform.GetChild(0).gameObject;
        _lighter.SetActive(false);*/

        lighter = true;
    }


    void Update()
    {
        _lighter = GameObject.Find("Players").transform.GetChild(0).transform.GetChild(0).gameObject;
        //TIRAR OBJETO 
        if (Input.GetKeyDown("q"))
        {
            _inventory.DropItem(_slot);

        }
        //USAR OBJETO 
        if (Input.GetMouseButtonDown(0))
        {
            _itemSelected = _inventory.CheckItems(_inventory.strSlots[_slot]);
            //USARLO
            if (_itemSelected != null)
            {
                int i = _itemSelected.GetComponent<ItemControler>().Type;
                if (i >= 2)
                {

                    _inventory.RemoveItem(_slot);
                }
                if(i == 0)
                {
                    _lighter.SetActive(lighter);
                    lighter = !lighter;
                }
            }
        }

        //MOVER SLOT 
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_slot > 0)
            {
                _slot--;
                _inventory.HighlightSlot(_slot);
            }
        }
        

        //MOVER SLOT 
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (_slot < _inventory.slots.Length - 1)
            {
                _slot++;
                _inventory.HighlightSlot(_slot);
            }
        }
        



    }

}

