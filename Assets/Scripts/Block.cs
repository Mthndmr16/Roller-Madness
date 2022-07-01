using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isCollided = false;
    private int bump = 1;   // çaprmada kaybedilecek skor.
    // Start is called before the first frame update
    void Start()
    {
        //  GetComponent<Renderer>().material.color = Color.black;
    }


    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)  // her temasta bir kez çalýþýr
    {
        if (isCollided == false)  
        {
            if (collision.gameObject.tag == "Player")  // Bu bloða çarpan objenin tag'ý player ise
            {
                GetComponent<MeshRenderer>().material.color = Random.ColorHSV();  // bu scripte sahip objenin mesh renderer componentine gir, oradan material color'u çek ve random bir deðer ver.
                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();  // ScoreManager scriptini burada ayrý olarak scoreManager deðiþkenine referans olarak al.
                scoreManager.score -= bump;// skoru bir azalt
            }          
            // isCollided = true;
        }

    }

}
