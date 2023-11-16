using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCoins : MonoBehaviour {

    public string coins_amount;
    public Text coins;

    private int addCoins;

    void OnMouseUp()
    {
        if (InitPuchases.initStore)
        {
            UM_InAppPurchaseManager.Client.OnPurchaseFinished += OnPurchaseFlowFinishedAction;
            UM_InAppPurchaseManager.Client.Purchase(coins_amount);
        } else
        {
            new MobileNativeMessage("Oops!", "Something went wrong!");
        }
    }
    private void OnPurchaseFlowFinishedAction(UM_PurchaseResult result)
    {
        UM_InAppPurchaseManager.Client.OnPurchaseFinished -= OnPurchaseFlowFinishedAction;
        if (result.isSuccess)
        {
            UM_ExampleStatusBar.text = "Product " + result.product.id + " purchase Success";
            switch (coins_amount)
            {
                case "100_coins":
                    addCoins = 100;
                    break;
                case "300_coins":
                    addCoins = 300;
                    break;
                case "500_coins":
                    addCoins = 500;
                    break;
                case "1000_coins":
                    addCoins = 1000;
                    break;
            }
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + addCoins);
            coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
        }
        else
        {
            UM_ExampleStatusBar.text = "Product " + result.product.id + " purchase Failed";
            new MobileNativeMessage("Oops!", "Something went wrong! Purchase has failed");
        }
    }
}

