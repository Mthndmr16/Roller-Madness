using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour  // coin i�in yaz�ld�
{

    [SerializeField] private Vector3 angle;  // �nspector k�sm�nda belirttik

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(angle, Space.World);  // Globala g�re x,y,z a��lar�nda hangi h�zda d�nece�ini belirten kod
    }
}
