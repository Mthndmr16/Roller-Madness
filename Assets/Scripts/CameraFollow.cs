using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;  // Target (Player) 
    private Vector3 offset;   // top ile kamera arasýndaki mesafeyi belirten deðiþken  
    [SerializeField] private float kameraFollowSpeed = 5f;


   
    void Start()
    {
        offset = DistanceOffset(target);
    }

   
    void FixedUpdate()    // FixedUpdate : update metodundan sonra  , fizik hesaplamalarý yapýldýktan hemen sonra çaðýrýlýr. Genelde hareket inputlarý için kullanýlýr.
    {
        if (target != null)
        {
            MoveTheCamera();    // Metodlarýn ilk harfi büyük yazýlýr, deðiþkenlerin ilk harfi de kücük yazýlýr.
        }
    }

    private void MoveTheCamera()  
    {
        Vector3 targetToMove = offset + target.position;  // hedefin o andaki pozisyonu ile kamerayla hedef pozisyonarasýndaki mesafeyi toplarsak bize net mesafeyi verir
        transform.position = Vector3.Lerp(transform.position, targetToMove, kameraFollowSpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);    // kameranýn z pozisyonunu playerdan  hiçbir zaman ayýrmaz , topu hiç kaçýrmadan takip eder.

        // ya da bu þekilde de yapýlýr.
        //  transform.position = offset + target.position;
        //  Vector3 hedefPozisyon = transform.position;
        //  transform.position = Vector3.Lerp(transform.position, hedefPozisyon, 5f);
    }

    private Vector3 DistanceOffset(Transform newTarget)    
    {
        return transform.position - newTarget.position;
    }

}
