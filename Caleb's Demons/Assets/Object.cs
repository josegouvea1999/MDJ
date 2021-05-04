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
        public bool in_inventory = false;
        public Inventory inventory;
        public Sprite sprite;
        public Vector3 initial_position;
        public Vector3 final_position;
        public float initial_z;
        public bool dragging;
        public bool puzzle_object = false;
        public bool draggable = true; 

        // Start is called before the first frame update
        void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
            initial_z = gameObject.transform.position.z;
            dragging = false;

            if (gameObject.tag == "tree") {
                draggable = false;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Stage() {
            UnityEngine.Debug.Log("stage!!!");
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, initial_z);
            gameObject.SetActive(true);
        }

        private void OnMouseDrag()
        {
            if (draggable) { 
                UnityEngine.Debug.Log("DRAGGING OBJECT");
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, initial_z);
            }
        }

        private void OnMouseUp() {
            UnityEngine.Debug.Log("Just dropped!");
            if (puzzle_object)
            {

                UnityEngine.Debug.Log("puzzle dragged!");
                gameObject.GetComponent<PuzzleObject>().CheckFunctionality();
            }
        }
        

        private bool WasDragged() {
            return final_position.x != initial_position.x || final_position.y != initial_position.y;
        }

        void OnMouseUpAsButton()
        {
            final_position = gameObject.transform.position;
            bool was_dragged = WasDragged();
            UnityEngine.Debug.Log("UP BUTTON  OBJECT");

            if (collectable && !was_dragged && gameObject.GetComponent<PuzzleObject>()==null)
            {
                UnityEngine.Debug.Log("UP BUTTON " + gameObject);
                UnityEngine.Debug.Log("INVENTORY " + inventory);
                inventory.Insert(gameObject);
                in_inventory = true;
                gameObject.SetActive(false);
            }

            if (puzzle_object) {
                UnityEngine.Debug.Log("puzzle clicked!");
                gameObject.GetComponent<PuzzleObject>().CheckFunctionality();
            }
        }

        void OnMouseDown()
        {
            initial_position = gameObject.transform.position;
        }

        public bool CheckDraggedThreslhold(Vector2 thresholds)
        {
            return Mathf.Abs(final_position.x - initial_position.x) >= thresholds[0] || Mathf.Abs(final_position.y - initial_position.y) >= thresholds[1];
        }
    }
}
