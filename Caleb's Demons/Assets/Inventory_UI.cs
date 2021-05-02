using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    private Inventory inventory;
    private Slot[] slots;
    private int current_index;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        slots = new Slot[inventory.GetNumberSlots()];
        GameObject[] slots_objects = GameObject.FindGameObjectsWithTag("inventory-slot");
        for (int i = 0; i < slots.Length; i++) {
            slots[i] = slots_objects[i].GetComponent<Slot>();
        }
        current_index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI() {
        for (int i = 0; i < slots.Length; i++) {
            if (i < inventory.GetNumberCollected()) {
                //slots[i].AddObject(inventory.GetElementObject(i));
            }
        }
    }

    public void AddObject(GameObject game_object) {
        UnityEngine.Debug.Log("ADD OBJECT "+ game_object);
        slots[current_index].AddObject(game_object);
        slots[current_index].SetUIIndex(current_index);
        current_index++;
        UpdateUI();
    }

    public void RemoveObject(GameObject game_object) {
        current_index--;
        inventory.Remove(game_object);
        UpdateUI();
    }
}
