using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject sign;
    public Text signText;
    public string text;
    public bool active;
    
   
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement movement = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement movement = gameObject.GetComponent<PlayerMovement>();

        if (Input.GetButtonDown("Fire1") && active) {


            if (sign.activeInHierarchy)
            {
                sign.SetActive(false);
                
            }
            else {
                sign.SetActive(true);
                signText.text = text;

            }

        }
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            active = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            active = false;
            sign.SetActive(false);
        }
    }
}
