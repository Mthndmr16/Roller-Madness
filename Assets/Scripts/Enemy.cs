using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed = 125f;
    float distance;
    [SerializeField] float carpmaMesafesi = 1.01f;
    [SerializeField] private GameObject deadEffectEnemy;

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            distance = Vector3.Distance(transform.position, target.position);
            if (distance > carpmaMesafesi)
            {
                transform.position += transform.forward / 100 * followSpeed * Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.gameOver = true;
        }
    }
    private void OnDisable()
    {
        Instantiate(deadEffectEnemy, transform.position, transform.rotation);
    }
}
   
