using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] Vector3 movement;  // movemenet adl� vekt�rel bir de�i�ken olu�turuyoruz
    [SerializeField] private float x = 5f; // sa�a sola gitmesini sa�lar
    [SerializeField] private float z = 5f; // �ne arkaya gitmesini sa�lar
    [SerializeField] private float speed = 5f;  // gitme h�z�
    private Rigidbody mRigidBody;  // objemizi yer�ekimi e�li�inde yuvarlayaca��m�z i�in rigidbody laz�m.
    private TimeManager timeManager;  // s�re de�i�kenini buraya �ektik ��nk� oyun bitti�inde objemizin hareketini durdurmam�z gerek.
    [SerializeField] private GameObject deadEffectPlayer;

    // Start is called before the first frame update
    void Start()
    {
        /*  movement = new Vector3(x, 0f, z);        
          transform.position = movement;*/
        mRigidBody = GetComponent<Rigidbody>();    // burada Rigidbody componentini referans ald�k. bu sayede rigidbodyi elimizle atamaktansa tek sat�rda referans al�p hareket i�lemlerini  yapabiliyoruz.
        timeManager = FindObjectOfType<TimeManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (timeManager.gameOver == false && timeManager.gameFinished == false)  // oyun bitmemi�se
        {
            MoveThePlayer(); 
        }
        if (timeManager.gameOver == true || timeManager.gameFinished == true)
        {
            mRigidBody.isKinematic = true;  // oyun durdu�unda objemizin hareketini k�s�tlamak amac�yla kulland�ld�.
        }
        
    }

    private void MoveThePlayer()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;  // a ve d tu�lar�n� kullanarak sola ve sa�a gitmemizi sa�lar.
        z = Input.GetAxis("Vertical") * Time.deltaTime * speed;  // w ve s tu�lar�n� kullanarak �ne ve arkaya gitmemizi sa�lar
        movement = new Vector3(x, 0f, z); // 
        // transform.position += movement;
        mRigidBody.AddForce(movement);
    }
    private void OnDisable()
    {
        Instantiate(deadEffectPlayer, transform.position, transform.rotation);
    }
}
