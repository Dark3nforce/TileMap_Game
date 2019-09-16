using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagInventory : MonoBehaviour
{
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
    

    void OnTriggerEnter2D(Collider2D collide)
    {

        if (collide.gameObject.tag == "Player")
        { if (gameObject.tag == "Potion") {
                Destroy(gameObject);
                potion++;
                print("You now have " + potion + " * potion");
              //  print(inventory);
            }
            else if (gameObject.tag == "pokeball") {
                Destroy(gameObject);
                pokeball++;
                print("You now have " + pokeball +" * pokeball");
               // print(inventory);
            }
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
