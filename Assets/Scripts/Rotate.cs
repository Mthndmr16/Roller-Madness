using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour  // coin için yazýldý
{

    [SerializeField] private Vector3 angle;  // ýnspector kýsmýnda belirttik

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(angle, Space.World);  // Globala göre x,y,z açýlarýnda hangi hýzda döneceðini belirten kod
    }
}
