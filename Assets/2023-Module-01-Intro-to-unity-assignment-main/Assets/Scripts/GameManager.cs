using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    //[SerializeField] CoinManager cM;
    [SerializeField] private float timer = 0.01f;
    [SerializeField] private TMP_Text timerText;

    //private void Start()
    //{
    //    if(cM.coinCount == 10)
    //        Destroy(gameObject);
    //}

    private void OnGUI()
    {
        timer += Time.deltaTime;

        timerText.text = timer.ToString("F2");
    }
}
