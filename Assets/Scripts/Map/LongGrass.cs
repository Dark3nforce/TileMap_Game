using UnityEngine;
using System.Collections;

public class LongGrass : MonoBehaviour {

    public BiomeList grassType;

    private GameManager gm;
    private BattleManager bm;
    private float vc = 10 / 187.5f;
    private float c = 8.5f / 187.5f;
    private float sr = 6.75f / 187.5f;
    private float r = 3.33f / 187.5f;
    private float vr = 1.25f / 187.5f;
    public Rarity raritySet;
    public bool triggered = false;

	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        bm = GetComponent<BattleManager>();
	}
	
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("entering: " + triggered + " gm: " + gm);
        // if(col.tag == "Long_Grass") {
            Debug.Log("entering: " + triggered + " gm: " + gm);
            // if(col.GetComponent<PlayerMovement>())
            // {
                //P = x / 187.5
                //VC = 10, C = 8.5, Semi-Are = 6.75, Rare = 3.33, VR = 1.25
                // float vc = 10 / 187.5f;
                // float c = 8.5f / 187.5f;
                // float sr = 6.75f / 187.5f;
                // float r = 3.33f / 187.5f;
                // float vr = 1.25f / 187.5f;

                float p = Random.Range(0.0f, 100.0f);
                if (triggered == false)
                {
                        if(p < vr*100)
                    {
                        if (gm != null) {
                            raritySet = Rarity.VeryRare;
                            gm.EnterBattle();
                            triggered = true;
                        }
                    }
                    else if(p < r*100)
                    {
                        if (gm != null) {
                            raritySet = Rarity.Rare;
                            gm.EnterBattle();
                            triggered = true;
                        }
                    }
                    else if(p < sr*100)
                    {
                        if (gm != null) {
                            raritySet = Rarity.SemiRare;
                            gm.EnterBattle();
                            triggered = true;
                        }
                    }
                    else if(p < c*100)
                    {
                        if (gm != null) {
                            raritySet  = Rarity.Common;
                            gm.EnterBattle();
                            triggered = true;
                        }
                            
                    }
                    else if(p < vc*100)
                    {
                        if (gm != null) {
                            Debug.Log("very common");
                            raritySet = Rarity.VeryCommon;
                            gm.EnterBattle();
                            triggered = true;
                        }
                    }   
                }
            // }
        // }
    }

        //Might be forcing battle every grass step and not random
        // private void OnTriggerStay2D(Collider2D collision)
        // {
        //     float p = Random.Range(0.0f, 100.0f);

        //         if (triggered == false)
        //         {
        //                 if(p < vr*100)
        //             {
        //                 if (gm != null) {
        //                     raritySet = Rarity.VeryRare;
        //                     gm.EnterBattle();
        //                     triggered = true;
        //                 }
        //             }
        //             else if(p < r*100)
        //             {
        //                 if (gm != null) {
        //                     raritySet = Rarity.Rare;
        //                     gm.EnterBattle();
        //                     triggered = true;
        //                 }
        //             }
        //             else if(p < sr*100)
        //             {
        //                 if (gm != null) {
        //                     raritySet = Rarity.SemiRare;
        //                     gm.EnterBattle();
        //                     triggered = true;
        //                 }
        //             }
        //             else if(p < c*100)
        //             {
        //                 if (gm != null) {
        //                     raritySet  = Rarity.Common;
        //                     gm.EnterBattle();
        //                     triggered = true;
        //                 }
                            
        //             }
        //             else if(p < vc*100)
        //             {
        //                 if (gm != null) {
        //                     raritySet = Rarity.VeryCommon;
        //                     gm.EnterBattle();
        //                     triggered = true;
        //                 }
        //             }   
        //         }
        // }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class box : MonoBehaviour
// {
//     float encouterTime = float.MaxValue;

//     // Update is called once per frame
//     void Update()
//     {
//         float h = Input.GetAxisRaw("Horizontal");
//         float v = Input.GetAxisRaw("Vertical");
//         GetComponent<Rigidbody2D>().velocity = 10 *(Vector2.right*h + Vector2.up*v);
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.tag == "Water")
//         {
//             float r = Random.Range(2, 6);
//             encouterTime = r + Time.time;
//             print("Encounter in " + r + " seconds");
//         }
//     }

//     private void OnTriggerStay2D(Collider2D collision)
//     {
//         //called when you move inside the trigger (not called if you are not moving).
//         if (collision.tag == "Water")
//         {
//             if (Time.time > encouterTime)
//             {
//                 encouterTime = float.MaxValue;
//                 print("Encounter Starts!");
//             }
//         }
//     }

//     private void OnTriggerExit2D(Collider2D collision)
//     {
//         if (collision.tag == "Water")
//         {
//             encouterTime = float.MaxValue;
//         }
//     }

// }