using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceRefresher : MonoBehaviour
{
    public GameObject Manager;
    public ProductionPurchase prodScript; public BiomassManager BiomassManager; public PrestigeUpgrades1 PrestigeUpgrades1;
    public Text text;
    public int Number;
    public double TimeDelta, TestTest;
    //public double FirstQueenPriceCopy, FirstQueenPriceBulk, FirstQueenCountCopy, FirstQueenCountBulk;
    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        prodScript = Manager.GetComponent<ProductionPurchase>();
        BiomassManager = Manager.GetComponent<BiomassManager>();
        PrestigeUpgrades1 = Manager.GetComponent<PrestigeUpgrades1>();

        InvokeRepeating("TextUpdate", 0.1f, 0.1f);
    }
    private void FixedUpdate()
    {
        TimeDelta += Time.deltaTime;
        TestTest += 1;
    }
    private void TextUpdate()
    {
        //Debug.Log(TestTest);
        //Debug.Log(TimeDelta);
        
        //FirstQueenPriceCopy = prodScript.FirstQueenPrice;
        //FirstQueenCountCopy = prodScript.FirstQueenCount;

        //if (Number == 10005)
        //{
        //    while (BiomassManager.biomass > FirstQueenPriceBulk)
        //    {
        //        if (FirstQueenCountBulk < 2)
        //        {
        //            FirstQueenCountBulk++;
        //        }
        //        if (FirstQueenCountCopy % 10 == 0 && FirstQueenCountCopy != 0)
        //        {
        //            FirstQueenPriceCopy *= 10;
        //        }
        //        else
        //        {
        //            FirstQueenPriceCopy *= 1.15;
        //        }
        //        FirstQueenPriceBulk += FirstQueenPriceCopy;
        //        FirstQueenCountCopy++;
        //        FirstQueenCountBulk++;
        //        Debug.Log(FirstQueenPriceBulk);
        //    }
        //    text.text = $"{(FirstQueenCountBulk - 1).ToString()}X {(FirstQueenPriceBulk - FirstQueenPriceCopy).ToString("0")}";
        //    FirstQueenCountBulk = 1;
        //    FirstQueenPriceBulk = FirstQueenPriceCopy;
        //}

        if (Number == 3081)
        {
            text.text = $"Overseers: {(PrestigeUpgrades1.Overseers).ToString("0")}";
        }
        if (Number == 3082)
        {
            text.text = $"OP: {(PrestigeUpgrades1.OP).ToString("0")}";
        }

        if (Number == 0)
        {
            if (prodScript.BuyMult != 800)
            {
                text.text = $"x{prodScript.BuyMult}";
            }
            else
            {
                text.text = $"BUY MAX";
            }
        }
        if (Number == 1111)
        {
            if (prodScript.TotalProduction < 1000000)
            {
                text.text = $"BPS: {prodScript.TotalProduction.ToString("0", System.Globalization.CultureInfo.GetCultureInfo("en-US"))}";
            }
            else if (prodScript.TotalProduction < 1e305)
            {
                text.text = $"BPS: {prodScript.TotalProduction.ToString("0.00e0", System.Globalization.CultureInfo.GetCultureInfo("en-US"))}";
            }
            else
            {
                text.text = $"BPS: enough for Spire";
            }
        }
        if (Number == 11111)
        {
            text.text = $"Buy ten multiplier: x{prodScript.BuyTenMult}";
        }

        //Начало
        //if (Number == 1)
        //{
        //    if (prodScript.FirstQueenPrice > 1000000)
        //    {
        //        text.text = $"{prodScript.FirstQueenPrice.ToString("0.00e0")}";
        //    }
        //    else
        //    {
        //        text.text = $"{prodScript.FirstQueenPrice.ToString("00.00")}";
        //    }
        //    //Debug.Log(TestTest);
        //    //Debug.Log(TimeDelta);
        //}
        //if (Number == 11)
        //{
        //    if ((prodScript.FirstQueenCount + prodScript.FirstQueenAddedCount) > 1000000)
        //    {
        //        text.text = $"{(prodScript.FirstQueenCount + prodScript.FirstQueenAddedCount).ToString("0.00e0")}";
        //    }
        //    else
        //    {
        //        text.text = $"{(prodScript.FirstQueenCount + prodScript.FirstQueenAddedCount).ToString("0")}";
        //    }
        //}
        //if (Number == 111)
        //{
        //    text.text = $"{(prodScript.FirstQueenCount % 10).ToString("0")}/10";
        //}
        //if (Number == 2)
        //{
        //    if (prodScript.FirstHivePrice > 1000000)
        //    {
        //        text.text = $"{prodScript.FirstHivePrice.ToString("0.00e0")}";
        //    }
        //    else
        //    {
        //        text.text = $"{prodScript.FirstHivePrice.ToString("00.00")}";
        //    }
        //}
        //if (Number == 22)
        //{
        //    if ((prodScript.FirstHiveCount + prodScript.FirstHiveAddedCount) > 1000000)
        //    {
        //        text.text = $"{(prodScript.FirstHiveCount + prodScript.FirstHiveAddedCount).ToString("0.00e0")}";
        //    }
        //    else
        //    {
        //        text.text = $"{(prodScript.FirstHiveCount + prodScript.FirstHiveAddedCount).ToString("0")}";
        //    }
        //}
        //if (Number == 222)
        //{
        //    text.text = $"{(prodScript.FirstHiveCount % 10).ToString("0")}/10";
        //}
        //
        //
    }
    public void PriceText(double Price)
    {
        Price = prodScript.FirstQueenPrice;
    }
}
