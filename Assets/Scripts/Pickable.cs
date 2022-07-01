using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    int scoreAmount = 5;   // coin ald���m�zda ka� skor gelece�ini yaz�yoruz.
    [SerializeField] private GameObject deadEffectCoin;
    
    void Start()
    {

    }

    
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmount;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmount;
            Destroy(gameObject);
        }
    }
    private void OnDisable() // objemiz oyun sahnesinden silindi�i an
    {
        Instantiate(deadEffectCoin, transform.position, transform.rotation);  // olu�turdu�umuz deafhEffectCoin adl� particle , paran�n yok oldu�u yerde Instantiate ediliyor.
    }
}
