using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restore : MonoBehaviour {

    void OnMouseUp()
    {
        if (InitPuchases.initStore)
        {
            UM_InAppPurchaseManager.Client.OnPurchaseFinished += OnPurchaseFlowFinishedAction;
            UM_InAppPurchaseManager.Client.RestorePurchases();
        }
        else
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
            if (UM_InAppPurchaseManager.instance.IsProductPurchased("no_ads"))
                PlayerPrefs.SetString("NoAds", "yes");
        }
        new MobileNativeMessage("Hooray!", "All purchases are restored");
    }
}
