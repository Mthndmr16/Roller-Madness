using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    int scoreAmount = 5;   // coin aldýðýmýzda kaç skor geleceðini yazýyoruz.
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
    private void OnDisable() // objemiz oyun sahnesinden silindiði an
    {
        Instantiate(deadEffectCoin, transform.position, transform.rotation);  // oluþturduðumuz deafhEffectCoin adlý particle , paranýn yok olduðu yerde Instantiate ediliyor.
    }
}
