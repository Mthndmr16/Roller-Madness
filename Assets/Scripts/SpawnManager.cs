using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //  [SerializeField] private GameObject coinPrefab;   // GameObject componentini inspector k�sm�nda g�sterip eklenmesini istedi�imiz oyun objesini s�r�kl�yoruz.
    //  [SerializeField] private GameObject enemyPrefab;  // GameObject componentini inspector k�sm�nda g�sterip eklenmesini istedi�imiz oyun objesini s�r�kl�yoruz.
    [SerializeField] private GameObject[] objects; 
    [SerializeField] private float spawnAraligi = 5f;  // ne kadar s�rede spawn olacak.
    [SerializeField] private Transform[] spawnPositions;
    private float nextSpawnTime = 0f;  // bir sonraki spawn s�resini veren de�i�ken.
    private TimeManager timeManager;
    
    
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>(); 
    }

    void Update()
    {
        if (timeManager.gameFinished == false && timeManager.gameOver == false )
        {
            if (Time.timeSinceLevelLoad > nextSpawnTime)
            {
                nextSpawnTime += spawnAraligi;
                //  Debug.Log("Spawn");
                SpawnObject(objects[GameObjectsNumber()], spawnPositions[RandomSpawnNumber()]);   // spawnPositions[] transformundan se�ilen 3 tane konumdan rastgele birini se�me i�lemi.
            }
        }
        
       
    }
    // Instantiate() komutu , oyunun �al��ma esnas�nda sahneye obje eklememize olanak sa�lar . 
    //  kullan�m �ekli ==> Instantiate(oyun objesi , lokasyon , rotasyon);

    private void SpawnObject(GameObject spawnlanacakObje , Transform spawnlanacakObjeninKonumu)
    {
        Instantiate(spawnlanacakObje, spawnlanacakObjeninKonumu.position, spawnlanacakObjeninKonumu.rotation);       
    }

    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);
    }
    private int GameObjectsNumber()
    {
        return Random.Range(0, objects.Length);
    }
}
