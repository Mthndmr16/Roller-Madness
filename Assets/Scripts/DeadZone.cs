using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour  // scene'deki altta kalan k�rm�z� alan
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)  // �arp��ma oldu�unda
    {
        Destroy(collision.gameObject);  // �arpan objeyi yok et
        if (collision.gameObject.tag == "Player") // e�er carpan objenin tag'� Player ise
        {
            FindObjectOfType<TimeManager>().gameOver = true; //  oyunu bitir.
        }
    }
}
