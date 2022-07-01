using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] Vector3 movement;  // movemenet adlý vektörel bir deðiþken oluþturuyoruz
    [SerializeField] private float x = 5f; // saða sola gitmesini saðlar
    [SerializeField] private float z = 5f; // öne arkaya gitmesini saðlar
    [SerializeField] private float speed = 5f;  // gitme hýzý
    private Rigidbody mRigidBody;  // objemizi yerçekimi eþliðinde yuvarlayacaðýmýz için rigidbody lazým.
    private TimeManager timeManager;  // süre deðiþkenini buraya çektik çünkü oyun bittiðinde objemizin hareketini durdurmamýz gerek.
    [SerializeField] private GameObject deadEffectPlayer;

    // Start is called before the first frame update
    void Start()
    {
        /*  movement = new Vector3(x, 0f, z);        
          transform.position = movement;*/
        mRigidBody = GetComponent<Rigidbody>();    // burada Rigidbody componentini referans aldýk. bu sayede rigidbodyi elimizle atamaktansa tek satýrda referans alýp hareket iþlemlerini  yapabiliyoruz.
        timeManager = FindObjectOfType<TimeManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (timeManager.gameOver == false && timeManager.gameFinished == false)  // oyun bitmemiþse
        {
            MoveThePlayer(); 
        }
        if (timeManager.gameOver == true || timeManager.gameFinished == true)
        {
            mRigidBody.isKinematic = true;  // oyun durduðunda objemizin hareketini kýsýtlamak amacýyla kullandýldý.
        }
        
    }

    private void MoveThePlayer()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;  // a ve d tuþlarýný kullanarak sola ve saða gitmemizi saðlar.
        z = Input.GetAxis("Vertical") * Time.deltaTime * speed;  // w ve s tuþlarýný kullanarak öne ve arkaya gitmemizi saðlar
        movement = new Vector3(x, 0f, z); // 
        // transform.position += movement;
        mRigidBody.AddForce(movement);
    }
    private void OnDisable()
    {
        Instantiate(deadEffectPlayer, transform.position, transform.rotation);
    }
}
