using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Object;

public class Inventory:MonoBehaviour
{
    private List<GameObject> in_store = new List<GameObject>();
    private Inventory_UI inventory_ui;
    //private int current_num_stored = 0;
    //private int previous_num_stored = 0;
    private int num_slots = 8;

    // Start is called before the first frame update
    void Start()
    {
        inventory_ui = GameObject.FindGameObjectWithTag("inventory-ui").GetComponent<Inventory_UI>();
    }

    void Update()
    {
    }

    public void Insert(GameObject gameObject) {
        UnityEngine.Debug.Log("ENTROU OBJECTO");
        if (in_store.Count >= num_slots) { 
            //something went wrong
        }
        else
        {
            in_store.Add(gameObject);
            inventory_ui.AddObject(gameObject);
            /*if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }*/
        }
    }

    public int GetNumberSlots() {
        return num_slots;
    }

    public void Remove(GameObject gameObject)
    {
        in_store.Remove(gameObject);
       
    }

    public int GetNumberCollected() {
        return in_store.Count;
    }

    public Object.Object GetElementObject(int index) {
        return in_store[index].GetComponent<Object.Object>();
    }
}
