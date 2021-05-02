using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Object
{
    public class Object : MonoBehaviour
    {
        public bool collectable;
        private bool in_inventory = false;
        private Inventory inventory;
        public Sprite sprite;

        // Start is called before the first frame update
        void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnMouseDown()
        {
            UnityEngine.Debug.Log("CLIQUEIII");
            if (collectable) {
                inventory.Insert(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
