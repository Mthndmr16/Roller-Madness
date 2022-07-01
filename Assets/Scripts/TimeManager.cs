using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool gameFinished = false;
    public bool gameOver = false;
    [SerializeField] private float levelFinishTime = 5f;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private List<GameObject> destroyAfterGame = new List<GameObject>();

    void Start()
    {

       
    }

    void Update()
    {
        if (gameFinished == false && gameOver == false)
        {
            UpdateTheTimer();
        }
      
        if (Time.timeSinceLevelLoad >= levelFinishTime && gameOver == false)   // Oyun s�resi bitti�inde   ve   d��man bizi yakalayamad���nda bu alttaki if komutu �al���r.
        {
            gameFinished = true;
            winPanel.gameObject.SetActive(true);
            losePanel.gameObject.SetActive(false);
            updateObjectList("Objects");
            updateObjectList("Enemy");
            foreach (GameObject allObjects in destroyAfterGame)
            {
                Destroy(allObjects);
            }
        }
        
        if (gameOver == true)
        {
            winPanel.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);  // SetActive() metodu oyun objesini aktive etmek (ekranda g�stermek i�in) kullan�l�r. 
            updateObjectList("Objects");
            updateObjectList("Enemy");
            foreach (GameObject allObjects in destroyAfterGame)
            {
                Destroy(allObjects);
            }
        }
    }
    private void UpdateTheTimer()
    {
        timeText.text = "Time : " + (int) Time.timeSinceLevelLoad;  // casting i�lemi. Time.time normalde float de�er d�ner. bu �ekilde de integer bir say�ya �evrilir.
    }
 
    private void updateObjectList(string tag)
    {
        destroyAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    }
}
