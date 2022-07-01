using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isCollided = false;
    private int bump = 1;   // �aprmada kaybedilecek skor.
    // Start is called before the first frame update
    void Start()
    {
        //  GetComponent<Renderer>().material.color = Color.black;
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)  // her temasta bir kez �al���r
    {
        if (isCollided == false)  
        {
            if (collision.gameObject.tag == "Player")  // Bu blo�a �arpan objenin tag'� player ise
            {
                GetComponent<MeshRenderer>().material.color = Random.ColorHSV();  // bu scripte sahip objenin mesh renderer componentine gir, oradan material color'u �ek ve random bir de�er ver.
                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();  // ScoreManager scriptini burada ayr� olarak scoreManager de�i�kenine referans olarak al.
                scoreManager.score -= bump;// skoru bir azalt
            }          
            // isCollided = true;
        }

    }

}
