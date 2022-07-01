using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;  // Target (Player) 
    private Vector3 offset;   // top ile kamera aras�ndaki mesafeyi belirten de�i�ken  
    [SerializeField] private float kameraFollowSpeed = 5f;


   
    void Start()
    {
        offset = DistanceOffset(target);
    }

   
    void FixedUpdate()    // FixedUpdate : update metodundan sonra  , fizik hesaplamalar� yap�ld�ktan hemen sonra �a��r�l�r. Genelde hareket inputlar� i�in kullan�l�r.
    {
        if (target != null)
        {
            MoveTheCamera();    // Metodlar�n ilk harfi b�y�k yaz�l�r, de�i�kenlerin ilk harfi de k�c�k yaz�l�r.
        }
    }

    private void MoveTheCamera()  
    {
        Vector3 targetToMove = offset + target.position;  // hedefin o andaki pozisyonu ile kamerayla hedef pozisyonaras�ndaki mesafeyi toplarsak bize net mesafeyi verir
        transform.position = Vector3.Lerp(transform.position, targetToMove, kameraFollowSpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);    // kameran�n z pozisyonunu playerdan  hi�bir zaman ay�rmaz , topu hi� ka��rmadan takip eder.

        // ya da bu �ekilde de yap�l�r.
        //  transform.position = offset + target.position;
        //  Vector3 hedefPozisyon = transform.position;
        //  transform.position = Vector3.Lerp(transform.position, hedefPozisyon, 5f);
    }

    private Vector3 DistanceOffset(Transform newTarget)    
    {
        return transform.position - newTarget.position;
    }

}
