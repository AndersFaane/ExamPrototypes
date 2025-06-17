using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldGenerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;

    private int currentGold = 0;
    private int goldFromClick = 10;
    public float autoClickSpeed = 1f;
    private bool autoClickerBought = false;

    public AudioSource clickAudio;

    public void CookieClicked()
    {
        currentGold += goldFromClick;
        goldText.text = currentGold.ToString();
    }

    public void MoreGoldPerClick(int cost)
    {
        if(currentGold >= cost)
        {
            currentGold -= cost;
            goldFromClick += 10;

        }
    }

    public void BuyAnAutoClicker(int cost)
    {
        
        if (autoClickerBought == false && currentGold >= cost)
        {
            currentGold -= cost;
            StartCoroutine(AutoClicker());
            goldText.text = currentGold.ToString();
            autoClickerBought = true;
        }
    }

    public void FasterAutoClicker(int cost)
    {
        if(autoClickerBought == true && currentGold >= cost)
        {
            currentGold -= cost;
            if (autoClickSpeed >= 0.1f)
            {
                autoClickSpeed -= 0.1f;
            }
            Debug.Log(autoClickSpeed);
        }
       
        
    }

    private IEnumerator AutoClicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoClickSpeed);
            clickAudio.Play();
            CookieClicked();
        }
    }
}
