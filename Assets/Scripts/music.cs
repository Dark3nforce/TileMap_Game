using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start(){
       
    }
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1) {
            Destroy(this.gameObject);

            DontDestroyOnLoad(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
