using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEngine;

public class Actions : MonoBehaviour
{

    private InventorySystem _inventory;
    private PlayersManager PM;

    private GameObject _item;
    private GameObject _itemSelected;
    private GameObject _lighter;
    private GameObject _radio;
    private bool lighter;
    private bool blueLight;

    public int _slot;
  
    void Awake()
    {
        _slot = 0;
        _inventory = GetComponent<InventorySystem>();
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();


    }

    private void Start()
    {


        blueLight = true;
        lighter = true;
    }


    void Update()
    {
        
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
                    if(i == 4)
                    {
                        for(int j = 0; j < PM.Enemies.Count; j++)
                        {
                            var dist = (PM.Enemies[j].transform.position - PM.Players[0].transform.position).magnitude;
                            if (dist >= 6 && dist < 10)
                            {
                                PM.Enemies[j].GetComponent<Animator>().SetBool("Attract", true);
                            }

                            if (dist < 6)
                            {
                                PM.Enemies[j].GetComponent<Animator>().SetBool("Distract", true);
                            }
                        }
                    }
                    _inventory.RemoveItem(_slot);
                }
                if(i == 0)
                {
                    _lighter = GameObject.Find("Players").transform.GetChild(0).transform.Find("Linterna(Clone)").gameObject;
                    _lighter.SetActive(lighter);
                    _lighter.transform.GetChild(0).gameObject.SetActive(false);
                    ChangeColor(false);
                    blueLight = true;
                    lighter = !lighter;
                }

                if(i == 1)
                {
                    _radio = GameObject.Find("Players").transform.GetChild(0).transform.Find("Radio(Clone)").gameObject;
                    _radio.GetComponent<Radio>().On = !_radio.GetComponent<Radio>().On;
                }
                
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            _itemSelected = _inventory.CheckItems(_inventory.strSlots[_slot]);
            //USARLO
            if (_itemSelected != null)
            {
                int i = _itemSelected.GetComponent<ItemControler>().Type;
                
                if (i == 0 && lighter == false)
                {
                    ChangeColor(blueLight);
                    _lighter.transform.GetChild(0).gameObject.SetActive(blueLight);                    
                    blueLight = !blueLight;
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
    private void ChangeColor(bool blueLightOn)
    {
        if(blueLightOn)
        {
            _lighter.GetComponent<Renderer>().material.color = Color.blue;
        }

        else
        {
            _lighter.GetComponent<Renderer>().material.color = Color.yellow;
        }
        
    }
}

