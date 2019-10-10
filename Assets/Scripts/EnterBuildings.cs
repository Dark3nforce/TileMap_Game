using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBuildings : MonoBehaviour
{
    string Home;

    public bool active;
    // Start is called before the first frame update
    void Start()
    {
       
        }

    // Update is called once per frame
    void Update()
    {
        if (active && Input.GetButtonDown("Fire1"))
        {
            load("Home");

        }

    }

    public void load(string PlayerHome){
        SceneManager.LoadScene("Home");

}


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            active = true;
            Debug.Log("active");
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            active = false;
        }
    }

}
