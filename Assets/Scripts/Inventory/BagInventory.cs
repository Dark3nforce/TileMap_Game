using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagInventory : MonoBehaviour
{
    public GameObject inventory;
    public Text inventoryText;
    public string text;
    // Start is called before the first frame update
    void Start()
    {
        /*inventory = new int [pokeball];
        inventory = new int[potion];
        */
    }

    //  public int[] inventory;
    public static int potion;
    public static int pokeball;
    public bool active;


    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetButtonDown("Fire1"))
        {
            if (gameObject.tag == "Potion")
            {
                Destroy(gameObject);
                potion++;
                CountPotion();

                //  print(inventory);
            }

            else if (gameObject.tag == "pokeball")
            {
                Destroy(gameObject);
                pokeball++;
                CountBall();
                // print(inventory);
            }
        }
        else if (!active){

        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            active = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            active = false;

        }
    }

    void CountPotion() {
        inventoryText.text = potion.ToString("potion x " + potion);
      
    }
    void CountBall() {
        inventoryText.text = pokeball.ToString("pokeball x " + pokeball);
    }
}