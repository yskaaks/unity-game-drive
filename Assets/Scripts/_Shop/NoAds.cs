using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoAds : MonoBehaviour {

    public Sprite inactive;

    void Start()
    {
        if (PlayerPrefs.GetString ("NoAds") == "yes")
        {
            inactiveButton();
        } else
        {
            if (InitPuchases.initStore)
            {
                if (UM_InAppPurchaseManager.instance.IsProductPurchased("no_ads"))
                {
                    PlayerPrefs.SetString("NoAds", "yes");
                    inactiveButton();

                }
            }
        }
    } 

    void OnMouseUp()
    {
        if (PlayerPrefs.GetString("NoAds") != "yes")
        {
            if (InitPuchases.initStore)
            {
                UM_InAppPurchaseManager.Client.OnPurchaseFinished += OnPurchaseFlowFinishedAction;
                UM_InAppPurchaseManager.Client.Purchase("no_ads");
            }
            else
            {
                new MobileNativeMessage("Oops!", "Something went wrong!");
            }
        }
    }
    private void OnPurchaseFlowFinishedAction(UM_PurchaseResult result)
    {
        UM_InAppPurchaseManager.Client.OnPurchaseFinished -= OnPurchaseFlowFinishedAction;
        if (result.isSuccess)
        {
            UM_ExampleStatusBar.text = "Product " + result.product.id + " purchase Success";
            PlayerPrefs.SetString("NoAds", "yes");

            inactiveButton();
        }
        else
        {
            UM_ExampleStatusBar.text = "Product " + result.product.id + " purchase Failed";
            new MobileNativeMessage("Oops!", "Something went wrong!");
        }
    }
    void inactiveButton ()
    {
        GetComponent<Image>().sprite = inactive;
        transform.GetChild(0).gameObject.transform.localPosition = new Vector3(transform.GetChild(0).gameObject.transform.localPosition.x, 0, transform.GetChild(0).gameObject.transform.localPosition.z);
    }
}
