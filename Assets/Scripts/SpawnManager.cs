using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //  [SerializeField] private GameObject coinPrefab;   // GameObject componentini inspector kýsmýnda gösterip eklenmesini istediðimiz oyun objesini sürüklüyoruz.
    //  [SerializeField] private GameObject enemyPrefab;  // GameObject componentini inspector kýsmýnda gösterip eklenmesini istediðimiz oyun objesini sürüklüyoruz.
    [SerializeField] private GameObject[] objects; 
    [SerializeField] private float spawnAraligi = 5f;  // ne kadar sürede spawn olacak.
    [SerializeField] private Transform[] spawnPositions;
    private float nextSpawnTime = 0f;  // bir sonraki spawn süresini veren deðiþken.
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
                SpawnObject(objects[GameObjectsNumber()], spawnPositions[RandomSpawnNumber()]);   // spawnPositions[] transformundan seçilen 3 tane konumdan rastgele birini seçme iþlemi.
            }
        }
        
       
    }
    // Instantiate() komutu , oyunun çalýþma esnasýnda sahneye obje eklememize olanak saðlar . 
    //  kullaným þekli ==> Instantiate(oyun objesi , lokasyon , rotasyon);

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
