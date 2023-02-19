using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopControlScript : MonoBehaviour
{
    int moneyAmount; //сумма денег
    public static int isHealthSold; // Здоровье продано
    int isHealthSold2;
    int isLevelUpSold;
    int isLevelUpSold2;

    public Text moneyAmountText;
    public Text healthPrice;
    public Text levelUpPrice;

    public Button buyButton;
    public Button buyButtonLevelUp;

    private void Start()
    {
        buyButton.interactable = false;
        buyButton.interactable = false;
        moneyAmount = PlayerPrefs.GetInt("Coin");
    }

    private void Update()
    {







        moneyAmountText.text = "Money: " + moneyAmount.ToString() + "$";

        isLevelUpSold = PlayerPrefs.GetInt("isLevelUpSold");
        isLevelUpSold = PlayerPrefs.GetInt("isLevelUpSold2");

        isHealthSold2 = PlayerPrefs.GetInt("isHealthSold2");
        isHealthSold = PlayerPrefs.GetInt("isHealthSold");

        if(moneyAmount >= 200 && isLevelUpSold == 0)
            buyButtonLevelUp.interactable = true;

        if (moneyAmount < 200 && isLevelUpSold == 0)
            buyButtonLevelUp.interactable = false;

        if (moneyAmount >= 250 && isLevelUpSold == 1)
            buyButtonLevelUp.interactable = true;

        if (moneyAmount < 250 && isLevelUpSold == 1)
            buyButtonLevelUp.interactable = false;

        if (isLevelUpSold == 1 && isLevelUpSold2 == 0)
            levelUpPrice.text = "Price: 250 $";

        if (isLevelUpSold == 1 && isLevelUpSold2 == 1)
        {
            levelUpPrice.text = "Max Level Up";
            buyButtonLevelUp.interactable = false;
        }





        if (moneyAmount >= 75 && isHealthSold == 0)
            buyButton.interactable = true;

        if(moneyAmount < 75 && isHealthSold == 0)
            buyButton.interactable = false;

        if (moneyAmount >= 100 && isHealthSold == 1)
            buyButton.interactable = true;

        if (moneyAmount < 100 && isHealthSold == 1)
            buyButton.interactable = false;

        if(isHealthSold == 1 && isHealthSold2 == 0)
            healthPrice.text = "Price: 100 $";

        if(isHealthSold == 1 && isHealthSold2 == 1)
        {
            healthPrice.text = "Max Health";
            buyButton.interactable = false;
        }


    }

    public void BuyLevelUp()
    {
        if (isLevelUpSold == 0)
        {
            moneyAmount -= 200;
            PlayerPrefs.SetInt("isLevelUpSold", 1);
            PlayerPrefs.SetInt("LevelPassed", PlayerPrefs.GetInt("LevelPassed") + 1);
            levelUpPrice.text = "Price: 250 $";
        }

        if (isLevelUpSold == 1 && isLevelUpSold2 == 0)
        {
            moneyAmount -= 250;
            PlayerPrefs.SetInt("isLevelUpSold2", 1);
            PlayerPrefs.SetInt("LevelPassed", PlayerPrefs.GetInt("LevelPassed") + 1);
            healthPrice.text = "Max Level Up";
            buyButtonLevelUp.gameObject.SetActive(false);
        }

        PlayerPrefs.SetInt("Coin", moneyAmount);
        PlayerPrefs.Save();

    }

    public void BuyHealth()
    {
        if(isHealthSold == 0)
        {
            moneyAmount -= 75;
            PlayerPrefs.SetInt("isHealthSold", 1);
            healthPrice.text = "Price: 100 $";
        }

        if (isHealthSold == 1 && isHealthSold2 == 0)
        {
            moneyAmount -= 100;
            PlayerPrefs.SetInt("isHealthSold2", 1);
            healthPrice.text = "Max Health";
            buyButton.gameObject.SetActive(false);
        }

        PlayerPrefs.SetInt("Coin",moneyAmount);
        PlayerPrefs.Save();

    }



    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
