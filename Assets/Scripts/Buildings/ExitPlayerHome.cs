using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPlayerHome : MonoBehaviour
{
    GameObject player;
    public bool active;

    // Start is called before the first frame update
    void Start()
    {

        //DontDestroyOnLoad(theManager);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {


        if (active && Input.GetButtonDown("Fire1"))
        {

            load("OverWorld");

            player.transform.position = new Vector3(-1, 7, 0);
            //  DontDestroyOnLoad(player);
        }

    }

    public void load(string PlayerHome)
    {

        //SceneManager.LoadSceneAsync("OverWorld");
        SceneManager.UnloadSceneAsync("Home");


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
