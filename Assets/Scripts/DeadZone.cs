using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour  // scene'deki altta kalan kýrmýzý alan
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)  // çarpýþma olduðunda
    {
        Destroy(collision.gameObject);  // çarpan objeyi yok et
        if (collision.gameObject.tag == "Player") // eðer carpan objenin tag'ý Player ise
        {
            FindObjectOfType<TimeManager>().gameOver = true; //  oyunu bitir.
        }
    }
}
