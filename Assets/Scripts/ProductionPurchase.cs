using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProductionPurchase : MonoBehaviour
{
    public GameObject[] productions, Hints, WinTexts;
    public GameObject StartScreen, MergeButton, MergeUnlockButton, QQUnlockButton, SpireUnlockButton, Prestige1UpgradeTab, SpireButton, WinScreen;
    public PrestigeUpgrades1 prestigeUpgrades1;
    [SerializeField] public GameObject[,] Texts;
    public double[] ProductionPrices;
    public int i, wt;
    public double baseBiomass, biomassCopy, OPCopy;
    public double TotalProduction, BuyTenMult, ProductionCostMult, OverseersMult, ProductionCostX10_Mult;
    public float AutoBuyersTickspeed;

    // ”ÏÓÏ?
    public double FirstQueenPrice, FirstQueenCount, FirstQueenProduction, FirstQueenBuyTen, FirstQueenTotalProduction, FirstQueenAddedCount;
    public double SecondQueenPrice, SecondQueenCount, SecondQueenProduction, SecondQueenBuyTen, SecondQueenTotalProduction, SecondQueenAddedCount;
    public double ThirdQueenPrice, ThirdQueenCount, ThirdQueenProduction, ThirdQueenBuyTen, ThirdQueenTotalProduction, ThirdQueenAddedCount;
    public double FourthQueenPrice, FourthQueenCount, FourthQueenProduction, FourthQueenBuyTen, FourthQueenTotalProduction, FourthQueenAddedCount;
    public double FirstPrimalQueenPrice, FirstPrimalQueenCount, FirstPrimalQueenProduction, FirstPrimalQueenBuyTen, FirstPrimalQueenTotalProduction, FirstPrimalQueenAddedCount;

    public double FirstHivePrice, FirstHiveCount, FirstHiveProduction, FirstHiveBuyTen, FirstHiveTotalProduction, FirstHiveAddedCount;
    public double SecondHivePrice, SecondHiveCount, SecondHiveProduction, SecondHiveBuyTen, SecondHiveTotalProduction, SecondHiveAddedCount;
    public double ThirdHivePrice, ThirdHiveCount, ThirdHiveProduction, ThirdHiveBuyTen, ThirdHiveTotalProduction, ThirdHiveAddedCount;
    public double FourthHivePrice, FourthHiveCount, FourthHiveProduction, FourthHiveBuyTen, FourthHiveTotalProduction, FourthHiveAddedCount;

    public double FirstQueenMult, SecondQueenMult, ThirdQueenMult, FourthQueenMult, FirstPrimalQueenMult, FirstHiveMult, SecondHiveMult, ThirdHiveMult, FourthHiveMult;

    // ”ÃŒÃ
    public double FirstQueenPriceCopy, FirstQueenCountCopy, FirstQueenBuyTenCopy, FirstQueenBuyBulkPrice, FirstQueenBuyBulkCount;
    public double SecondQueenPriceCopy, SecondQueenCountCopy, SecondQueenBuyTenCopy, SecondQueenBuyBulkPrice, SecondQueenBuyBulkCount;
    public double ThirdQueenPriceCopy, ThirdQueenCountCopy, ThirdQueenBuyTenCopy, ThirdQueenBuyBulkPrice, ThirdQueenBuyBulkCount;
    public double FourthQueenPriceCopy, FourthQueenCountCopy, FourthQueenBuyTenCopy, FourthQueenBuyBulkPrice, FourthQueenBuyBulkCount;
    public double FirstPrimalQueenPriceCopy, FirstPrimalQueenCountCopy, FirstPrimalQueenBuyTenCopy, FirstPrimalQueenBuyBulkPrice, FirstPrimalQueenBuyBulkCount;

    public double FirstHivePriceCopy, FirstHiveCountCopy, FirstHiveBuyTenCopy, FirstHiveBuyBulkPrice, FirstHiveBuyBulkCount;
    public double SecondHivePriceCopy, SecondHiveCountCopy, SecondHiveBuyTenCopy, SecondHiveBuyBulkPrice, SecondHiveBuyBulkCount;
    public double ThirdHivePriceCopy, ThirdHiveCountCopy, ThirdHiveBuyTenCopy, ThirdHiveBuyBulkPrice, ThirdHiveBuyBulkCount;
    public double FourthHivePriceCopy, FourthHiveCountCopy, FourthHiveBuyTenCopy, FourthHiveBuyBulkPrice, FourthHiveBuyBulkCount;

    public bool QueenAutoBuyerChecker, HiveAutoBuyerChecker, Hint2Checker, Hint3Checker, Hint4Checker, WinChecker;
    public int BuyMult, AutoBuyerBuyMult;
    private void Start()
    {
        ProductionCostX10_Mult = 1.258;
        prestigeUpgrades1 = gameObject.GetComponent<PrestigeUpgrades1>();
        BuyMult = 1;
        BuyTenMult = 2.5;
        baseBiomass = GetComponent<BiomassManager>().biomass;
        BaseValues();
        InvokeRepeating("ProductionTextUpdater", 0.05f, 0.05f);

        FirstPrimalQueenPrice = 100;
        FirstPrimalQueenProduction = 1;
    }
    private void FixedUpdate()
    {
        ProductionPrices = new double[] { FirstQueenPrice, FirstHivePrice, SecondQueenPrice, SecondHivePrice, ThirdQueenPrice, ThirdHivePrice, FourthQueenPrice, FourthHivePrice, FirstPrimalQueenPrice };

        foreach (GameObject production in productions)
        {
            if (i<8)
            {
                if (ProductionPrices[i] <= GetComponent<BiomassManager>().biomass)
                {
                    production.GetComponent<Button>().interactable = true;
                }
                else
                {
                    production.GetComponent<Button>().interactable = false;
                }
            }
            else if (i>=8)
            {
                if (ProductionPrices[i] <= GetComponent<PrestigeUpgrades1>().OP)
                {
                    production.GetComponent<Button>().interactable = true;
                }
                else
                {
                    production.GetComponent<Button>().interactable = false;
                }
            }
            i++;
        }
        i = 0;
        AutoBuyerBuyMult = GetComponent<PrestigeUpgrades1>().AutoBuyerBuyMult;

        {
            if (GetComponent<BiomassManager>().biomass < 1e40)
            {
                MergeUnlockButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                MergeUnlockButton.GetComponent<Button>().interactable = true;
            }
            if (GetComponent<BiomassManager>().biomass < 1e200)
            {
                QQUnlockButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                QQUnlockButton.GetComponent<Button>().interactable = true;
            }
            if (GetComponent<BiomassManager>().biomass < 1e300)
            {
                SpireButton.GetComponent<Button>().interactable = false;
                SpireUnlockButton.GetComponent<Button>().interactable = false;
            }
            else
            {
                SpireButton.GetComponent<Button>().interactable = true;
                SpireUnlockButton.GetComponent<Button>().interactable = true;
            }

            if (Input.anyKey && StartScreen.activeSelf == true)
            {
                StartScreen.SetActive(!StartScreen.activeSelf);
                Invoke("GameStart", 3);
            }
            if (MergeUnlockButton.activeSelf == false && Hint2Checker == false)
            {
                Hint2Checker = true;
                Hints[1].SetActive(true);
                MergeButton.SetActive(true);
                Prestige1UpgradeTab.SetActive(true);
            }
            if (GetComponent<PrestigeUpgrades1>().Overseers >= 10 && Hint3Checker == false)
            {
                Hint3Checker = true;
                Hints[2].SetActive(true);
                QQUnlockButton.SetActive(true);
            }
            if (FirstPrimalQueenCount >= 1 && Hint4Checker == false)
            {
                Hint4Checker = true;
                Hints[3].SetActive(true);
                SpireUnlockButton.SetActive(true);
            }

            if (WinScreen.activeSelf == true && WinChecker == false)
            {
                WinChecker = true;
                Invoke("WinText1", 2f);
            }
        }// Hints and other

        {
            OPCopy = GetComponent<PrestigeUpgrades1>().OP;
            biomassCopy = GetComponent<BiomassManager>().biomass;

            FirstQueenPriceCopy = FirstQueenPrice;
            FirstQueenCountCopy = FirstQueenCount;
            FirstQueenBuyTenCopy = FirstQueenBuyTen;
            SecondQueenPriceCopy = SecondQueenPrice;
            SecondQueenCountCopy = SecondQueenCount;
            SecondQueenBuyTenCopy = SecondQueenBuyTen;
            ThirdQueenPriceCopy = ThirdQueenPrice;
            ThirdQueenCountCopy = ThirdQueenCount;
            ThirdQueenBuyTenCopy = ThirdQueenBuyTen;
            FourthQueenPriceCopy = FourthQueenPrice;
            FourthQueenCountCopy = FourthQueenCount;
            FourthQueenBuyTenCopy = FourthQueenBuyTen;
            FirstPrimalQueenPriceCopy = FirstPrimalQueenPrice;
            FirstPrimalQueenCountCopy = FirstPrimalQueenCount;
            FirstPrimalQueenBuyTenCopy = FirstPrimalQueenBuyTen;

            FirstHivePriceCopy = FirstHivePrice;
            FirstHiveCountCopy = FirstHiveCount;
            FirstHiveBuyTenCopy = FirstHiveBuyTen;
            SecondHivePriceCopy = SecondHivePrice;
            SecondHiveCountCopy = SecondHiveCount;
            SecondHiveBuyTenCopy = SecondHiveBuyTen;
            ThirdHivePriceCopy = ThirdHivePrice;
            ThirdHiveCountCopy = ThirdHiveCount;
            ThirdHiveBuyTenCopy = ThirdHiveBuyTen;
            FourthHivePriceCopy = FourthHivePrice;
            FourthHiveCountCopy = FourthHiveCount;
            FourthHiveBuyTenCopy = FourthHiveBuyTen;
        }// Copy

        OverseersMult = (GetComponent<PrestigeUpgrades1>().Overseers / 10) + 1;

        FirstQueenMult = FirstQueenProduction * Math.Pow(BuyTenMult, FirstQueenBuyTen) * OverseersMult;
        SecondQueenMult = SecondQueenProduction * Math.Pow(BuyTenMult, SecondQueenBuyTen) * OverseersMult;
        ThirdQueenMult = ThirdQueenProduction * Math.Pow(BuyTenMult, ThirdQueenBuyTen) * OverseersMult;
        FourthQueenMult = FourthQueenProduction * Math.Pow(BuyTenMult, FourthQueenBuyTen) * OverseersMult;
        FirstPrimalQueenMult = FirstPrimalQueenProduction * Math.Pow(BuyTenMult, FirstPrimalQueenBuyTen) * (OverseersMult * 100);

        FirstHiveMult = FirstHiveProduction * Math.Pow(BuyTenMult, FirstHiveBuyTen) * OverseersMult;
        SecondHiveMult = SecondHiveProduction * Math.Pow(BuyTenMult, SecondHiveBuyTen) * OverseersMult;
        ThirdHiveMult = ThirdHiveProduction * Math.Pow(BuyTenMult, ThirdHiveBuyTen) * OverseersMult;
        FourthHiveMult = FourthHiveProduction * Math.Pow(BuyTenMult, FourthHiveBuyTen) * OverseersMult;

        
        TotalProduction = (FirstQueenCount + FirstQueenAddedCount) * FirstQueenMult;
        SecondQueenTotalProduction = (SecondQueenCount + SecondQueenAddedCount) * SecondQueenMult;
        ThirdQueenTotalProduction = (ThirdQueenCount + ThirdQueenAddedCount) * ThirdQueenMult;
        FourthQueenTotalProduction = (FourthQueenCount + FourthQueenAddedCount) * FourthQueenMult;
        FirstPrimalQueenTotalProduction = (FirstPrimalQueenCount + FirstPrimalQueenAddedCount) * FirstPrimalQueenMult;

        FirstHiveTotalProduction = (FirstHiveCount + FirstHiveAddedCount) * FirstHiveMult;
        SecondHiveTotalProduction = (SecondHiveCount + SecondHiveAddedCount) * SecondHiveMult;
        ThirdHiveTotalProduction = (ThirdHiveCount + ThirdHiveAddedCount) * ThirdHiveMult;
        FourthHiveTotalProduction = (FourthHiveCount + FourthHiveAddedCount) * FourthHiveMult;

    }
    /// -------------------------------------------------------------------------------
    public void BaseValues()
    {
        GetComponent<BiomassManager>().biomass = baseBiomass;
        ProductionCostMult = 1.15;
        FirstQueenPrice = 10;
        FirstQueenProduction = 1;
        SecondQueenPrice = 5000;
        SecondQueenProduction = 1;
        ThirdQueenPrice = 1000000;
        ThirdQueenProduction = 1;
        FourthQueenPrice = 1000000000000;
        FourthQueenProduction = 1;
        //FirstPrimalQueenPrice = 100;
        //FirstPrimalQueenProduction = 1;

        FirstHivePrice = 100;
        FirstHiveProduction = 1;
        SecondHivePrice = 10000;
        SecondHiveProduction = 1;
        ThirdHivePrice = 1000000000;
        ThirdHiveProduction = 1;
        FourthHivePrice = 1000000000000000;
        FourthHiveProduction = 1;
    }
    public void ZeroValues()
    {
        TotalProduction = 0;
        SecondQueenTotalProduction = 0;
        ThirdQueenTotalProduction = 0;
        FourthQueenTotalProduction = 0;
        FirstHiveTotalProduction = 0;
        SecondHiveTotalProduction = 0;
        ThirdHiveTotalProduction = 0;
        FourthHiveTotalProduction = 0;
        GetComponent<BiomassManager>().BPCfromUpgrades1 = 0;

        FirstQueenCount = 0;
        FirstQueenBuyTen = 0;
        FirstQueenAddedCount = 0;
        SecondQueenCount = 0;
        SecondQueenBuyTen = 0;
        SecondQueenAddedCount = 0;
        ThirdQueenCount = 0;
        ThirdQueenBuyTen = 0;
        ThirdQueenAddedCount = 0;
        FourthQueenCount = 0;
        FourthQueenBuyTen = 0;
        FourthQueenAddedCount = 0;

        FirstHiveCount = 0;
        FirstHiveBuyTen = 0;
        FirstHiveAddedCount = 0;
        SecondHiveCount = 0;
        SecondHiveBuyTen = 0;
        SecondHiveAddedCount = 0;
        ThirdHiveCount = 0;
        ThirdHiveBuyTen = 0;
        ThirdHiveAddedCount = 0;
        FourthHiveCount = 0;
        FourthHiveBuyTen = 0;
        FourthHiveAddedCount = 0;
        GetComponent<BiomassManager>().biomass = baseBiomass;
    }
    public void QueenAutoBuyerActivator()
    {
        if (prestigeUpgrades1.QueenAutoBuyer == true && QueenAutoBuyerChecker == false)
        {
            AutoBuyersTickspeed = GetComponent<PrestigeUpgrades1>().AutoBuyersTickspeed;
            InvokeRepeating("FirstQueenAutoBuy", AutoBuyersTickspeed, AutoBuyersTickspeed);
            InvokeRepeating("SecondQueenAutoBuy", AutoBuyersTickspeed, AutoBuyersTickspeed + 0.01f);
            InvokeRepeating("ThirdQueenAutoBuy", AutoBuyersTickspeed, AutoBuyersTickspeed + 0.02f);
            InvokeRepeating("FourthQueenAutoBuy", AutoBuyersTickspeed, AutoBuyersTickspeed + 0.03f);
            QueenAutoBuyerChecker = true;
            Debug.Log("Queen Start Invokes");
            return;
        }
        if (prestigeUpgrades1.QueenAutoBuyer == true && QueenAutoBuyerChecker == true)
        {
            CancelInvoke("FirstQueenAutoBuy");
            CancelInvoke("SecondQueenAutoBuy");
            CancelInvoke("ThirdQueenAutoBuy");
            CancelInvoke("FourthQueenAutoBuy");
            QueenAutoBuyerChecker = false;
            Debug.Log("Queen Cancel Invokes");
            return;
        }
    }
    public void HiveAutoBuyerActivator()
    {
        if (prestigeUpgrades1.HiveAutoBuyer == true && HiveAutoBuyerChecker == false)
        {
            AutoBuyersTickspeed = GetComponent<PrestigeUpgrades1>().AutoBuyersTickspeed;
            InvokeRepeating("FirstHiveAutoBuy", AutoBuyersTickspeed, AutoBuyersTickspeed);
            InvokeRepeating("SecondHiveAutoBuy", AutoBuyersTickspeed, AutoBuyersTickspeed + 0.01f);
            InvokeRepeating("ThirdHiveAutoBuy", AutoBuyersTickspeed, AutoBuyersTickspeed + 0.02f);
            InvokeRepeating("FourthHiveAutoBuy", AutoBuyersTickspeed, AutoBuyersTickspeed + 0.03f);
            HiveAutoBuyerChecker = true;
            Debug.Log("Hive Start Invokes");
            return;
        }
        if (prestigeUpgrades1.HiveAutoBuyer == true && HiveAutoBuyerChecker == true)
        {
            CancelInvoke("FirstHiveAutoBuy");
            CancelInvoke("SecondHiveAutoBuy");
            CancelInvoke("ThirdHiveAutoBuy");
            CancelInvoke("FourthHiveAutoBuy");
            HiveAutoBuyerChecker = false;
            Debug.Log("Hive Cancel Invokes");
            return;
        }
    }
    public void BuyMultChange()
    {
        if (BuyMult == 1 && GetComponent<PrestigeUpgrades1>().BuyMax == true)
        {
            BuyMult = 800;
            return;
        }
        //if (BuyMult == 10)
        //{
        //    BuyMult = 100;
        //    return;
        //}
        //if (BuyMult == 100)
        //{
        //    BuyMult = 10000;
        //    return;
        //}
        if (BuyMult == 800)
        {
            BuyMult = 1;
            return;
        }
    }
    /// -------------------------------------------------------------------------------
    public void FirstQueenBuy()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= FirstQueenPrice)
            {
                GetComponent<BiomassManager>().biomass -= FirstQueenPrice;
                FirstQueenCount += 1;
                if (FirstQueenCount % 10 == 0 && FirstQueenCount != 0)
                {
                    FirstQueenBuyTen += 1;
                    FirstQueenPrice *= 10 * Math.Pow(ProductionCostX10_Mult, FirstQueenBuyTen);
                    Debug.Log(10 * Math.Pow(ProductionCostX10_Mult, FirstQueenBuyTen));
                }
                else
                {
                    FirstQueenPrice *= ProductionCostMult;
                }
            }
        }
    }
    public void SecondQueenBuy()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= SecondQueenPrice)
            {
                GetComponent<BiomassManager>().biomass -= SecondQueenPrice;
                SecondQueenCount += 1;
                if (SecondQueenCount % 10 == 0 && SecondQueenCount != 0)
                {
                    SecondQueenBuyTen += 1;
                    SecondQueenPrice *= 10 * Math.Pow(ProductionCostX10_Mult, SecondQueenBuyTen);
                }
                else
                {
                    SecondQueenPrice *= ProductionCostMult;
                }
            }
        }
    }
    public void ThirdQueenBuy()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= ThirdQueenPrice)
            {
                GetComponent<BiomassManager>().biomass -= ThirdQueenPrice;
                ThirdQueenCount += 1;
                if (ThirdQueenCount % 10 == 0 && ThirdQueenCount != 0)
                {
                    ThirdQueenBuyTen += 1;
                    ThirdQueenPrice *= 10 * Math.Pow(ProductionCostX10_Mult, ThirdQueenBuyTen);
                }
                else
                {
                    ThirdQueenPrice *= ProductionCostMult;
                }
            }
        }
    }
    public void FourthQueenBuy()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= FourthQueenPrice)
            {
                GetComponent<BiomassManager>().biomass -= FourthQueenPrice;
                FourthQueenCount += 1;
                if (FourthQueenCount % 10 == 0 && FourthQueenCount != 0)
                {
                    FourthQueenBuyTen += 1;
                    FourthQueenPrice *= 10 * Math.Pow(ProductionCostX10_Mult, FourthQueenBuyTen);
                }
                else
                {
                    FourthQueenPrice *= ProductionCostMult;
                }
            }
        }
    }
    public void FirstPrimalQueenBuy()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (GetComponent<PrestigeUpgrades1>().OP >= FirstPrimalQueenPrice)
            {
                GetComponent<PrestigeUpgrades1>().OP -= FirstPrimalQueenPrice;
                FirstPrimalQueenCount += 1;
                if (FirstPrimalQueenCount % 10 == 0 && FirstPrimalQueenCount != 0)
                {
                    FirstPrimalQueenBuyTen += 1;
                    FirstPrimalQueenPrice *= 10 * Math.Pow(ProductionCostX10_Mult, FirstPrimalQueenBuyTen);
                    Debug.Log(10 * Math.Pow(ProductionCostX10_Mult, FirstPrimalQueenBuyTen));
                }
                else
                {
                    FirstPrimalQueenPrice *= ProductionCostMult;
                }
            }
        }
    }
    public void FirstHiveBuy()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= FirstHivePrice)
            {
                GetComponent<BiomassManager>().biomass -= FirstHivePrice;
                FirstHiveCount += 1;
                if (FirstHiveCount % 10 == 0 && FirstHiveCount != 0)
                {
                    FirstHiveBuyTen += 1;
                    FirstHivePrice *= 10 * Math.Pow(ProductionCostX10_Mult, FirstHiveBuyTen);
                }
                else
                {
                    FirstHivePrice *= ProductionCostMult;
                }
            }
        }
    }
    public void SecondHiveBuy()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= SecondHivePrice)
            {
                GetComponent<BiomassManager>().biomass -= SecondHivePrice;
                SecondHiveCount += 1;
                if (SecondHiveCount % 10 == 0 && SecondHiveCount != 0)
                {
                    SecondHiveBuyTen += 1;
                    SecondHivePrice *= 10 * Math.Pow(ProductionCostX10_Mult, SecondHiveBuyTen);
                }
                else
                {
                    SecondHivePrice *= ProductionCostMult;
                }
            }
        }
    }
    public void ThirdHiveBuy()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= ThirdHivePrice)
            {
                GetComponent<BiomassManager>().biomass -= ThirdHivePrice;
                ThirdHiveCount += 1;
                if (ThirdHiveCount % 10 == 0 && ThirdHiveCount != 0)
                {
                    ThirdHiveBuyTen += 1;
                    ThirdHivePrice *= 10 * Math.Pow(ProductionCostX10_Mult, ThirdHiveBuyTen);
                }
                else
                {
                    ThirdHivePrice *= ProductionCostMult;
                }
            }
        }
    }
    public void FourthHiveBuy()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= FourthHivePrice)
            {
                GetComponent<BiomassManager>().biomass -= FourthHivePrice;
                FourthHiveCount += 1;
                if (FourthHiveCount % 10 == 0 && FourthHiveCount != 0)
                {
                    FourthHiveBuyTen += 1;
                    FourthHivePrice *= 10 * Math.Pow(ProductionCostX10_Mult, FourthHiveBuyTen);
                }
                else
                {
                    FourthHivePrice *= ProductionCostMult;
                }
            }
        }
    }
    /// -------------------------------------------------------------------------------
    public void FirstQueenAutoBuy()
    {
        for (int i = AutoBuyerBuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= FirstQueenPrice)
            {
                GetComponent<BiomassManager>().biomass -= FirstQueenPrice;
                FirstQueenCount += 1;
                if (FirstQueenCount % 10 == 0 && FirstQueenCount != 0)
                {
                    FirstQueenPrice *= 10 * Math.Pow(ProductionCostX10_Mult, FirstQueenBuyTen);
                    FirstQueenBuyTen += 1;
                    //Debug.Log(10 * Math.Pow(ProductionCostX10_Mult, FirstQueenBuyTen));
                }
                else
                {
                    FirstQueenPrice *= ProductionCostMult;
                }
            }
        }
        //Debug.Log(AutoBuyerBuyMult + " OnQueen");
    }
    public void SecondQueenAutoBuy()
    {
        for (int i = AutoBuyerBuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= SecondQueenPrice)
            {
                GetComponent<BiomassManager>().biomass -= SecondQueenPrice;
                SecondQueenCount += 1;
                if (SecondQueenCount % 10 == 0 && SecondQueenCount != 0)
                {
                    SecondQueenBuyTen += 1;
                    SecondQueenPrice *= 10 * Math.Pow(ProductionCostX10_Mult, SecondQueenBuyTen);
                }
                else
                {
                    SecondQueenPrice *= ProductionCostMult;
                }
            }
        }
    }
    public void ThirdQueenAutoBuy()
    {
        for (int i = AutoBuyerBuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= ThirdQueenPrice)
            {
                GetComponent<BiomassManager>().biomass -= ThirdQueenPrice;
                ThirdQueenCount += 1;
                if (ThirdQueenCount % 10 == 0 && ThirdQueenCount != 0)
                {
                    ThirdQueenBuyTen += 1;
                    ThirdQueenPrice *= 10 * Math.Pow(ProductionCostX10_Mult, ThirdQueenBuyTen);
                }
                else
                {
                    ThirdQueenPrice *= ProductionCostMult;
                }
            }
        }
    }
    public void FourthQueenAutoBuy()
    {
        for (int i = AutoBuyerBuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= FourthQueenPrice)
            {
                GetComponent<BiomassManager>().biomass -= FourthQueenPrice;
                FourthQueenCount += 1;
                if (FourthQueenCount % 10 == 0 && FourthQueenCount != 0)
                {
                    FourthQueenBuyTen += 1;
                    FourthQueenPrice *= 10 * Math.Pow(ProductionCostX10_Mult, FourthQueenBuyTen);
                }
                else
                {
                    FourthQueenPrice *= ProductionCostMult;
                }
            }
        }
    }
    public void FirstHiveAutoBuy()
    {
        for (int i = AutoBuyerBuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= FirstHivePrice)
            {
                GetComponent<BiomassManager>().biomass -= FirstHivePrice;
                FirstHiveCount += 1;
                if (FirstHiveCount % 10 == 0 && FirstHiveCount != 0)
                {
                    FirstHiveBuyTen += 1;
                    FirstHivePrice *= 10 * Math.Pow(ProductionCostX10_Mult, FirstHiveBuyTen);
                }
                else
                {
                    FirstHivePrice *= ProductionCostMult;
                }
            }
        }
        //Debug.Log(AutoBuyerBuyMult + " OnHive");
    }
    public void SecondHiveAutoBuy()
    {
        for (int i = AutoBuyerBuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= SecondHivePrice)
            {
                GetComponent<BiomassManager>().biomass -= SecondHivePrice;
                SecondHiveCount += 1;
                if (SecondHiveCount % 10 == 0 && SecondHiveCount != 0)
                {
                    SecondHiveBuyTen += 1;
                    SecondHivePrice *= 10 * Math.Pow(ProductionCostX10_Mult, SecondHiveBuyTen);
                }
                else
                {
                    SecondHivePrice *= ProductionCostMult;
                }
            }
        }
    }
    public void ThirdHiveAutoBuy()
    {
        for (int i = AutoBuyerBuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= ThirdHivePrice)
            {
                GetComponent<BiomassManager>().biomass -= ThirdHivePrice;
                ThirdHiveCount += 1;
                if (ThirdHiveCount % 10 == 0 && ThirdHiveCount != 0)
                {
                    ThirdHiveBuyTen += 1;
                    ThirdHivePrice *= 10 * Math.Pow(ProductionCostX10_Mult, ThirdHiveBuyTen);
                }
                else
                {
                    ThirdHivePrice *= ProductionCostMult;
                }
            }
        }
    }
    public void FourthHiveAutoBuy()
    {
        for (int i = AutoBuyerBuyMult; i > 0; i--)
        {
            if (GetComponent<BiomassManager>().biomass >= FourthHivePrice)
            {
                GetComponent<BiomassManager>().biomass -= FourthHivePrice;
                FourthHiveCount += 1;
                if (FourthHiveCount % 10 == 0 && FourthHiveCount != 0)
                {
                    FourthHiveBuyTen += 1;
                    FourthHivePrice *= 10 * Math.Pow(ProductionCostX10_Mult, FourthHiveBuyTen);
                }
                else
                {
                    FourthHivePrice *= ProductionCostMult;
                }
            }
        }
    }
    /// -------------------------------------------------------------------------------
    public void FirstQueenBuyCounter()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (biomassCopy >= FirstQueenPriceCopy)
            {
                biomassCopy -= FirstQueenPriceCopy;
                FirstQueenBuyBulkPrice += FirstQueenPriceCopy;
                FirstQueenBuyBulkCount += 1;
                FirstQueenCountCopy += 1;
                if (FirstQueenCountCopy % 10 == 0 && FirstQueenCountCopy != 0)
                {
                    FirstQueenBuyTenCopy += 1;
                    FirstQueenPriceCopy *= 10 * Math.Pow(ProductionCostX10_Mult, FirstQueenBuyTenCopy);
                }
                else
                {
                    FirstQueenPriceCopy *= ProductionCostMult;
                }
            }
        }
        biomassCopy = GetComponent<BiomassManager>().biomass;
        //Debug.Log($"X{FirstQueenBuyBulkCount} {FirstQueenBuyBulkPrice}");
    }
    public void SecondQueenBuyCounter()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (biomassCopy >= SecondQueenPriceCopy)
            {
                biomassCopy -= SecondQueenPriceCopy;
                SecondQueenBuyBulkPrice += SecondQueenPriceCopy;
                SecondQueenBuyBulkCount += 1;
                SecondQueenCountCopy += 1;
                if (SecondQueenCountCopy % 10 == 0 && SecondQueenCountCopy != 0)
                {
                    SecondQueenBuyTenCopy += 1;
                    SecondQueenPriceCopy *= 10 * Math.Pow(ProductionCostX10_Mult, SecondQueenBuyTenCopy);
                }
                else
                {
                    SecondQueenPriceCopy *= ProductionCostMult;
                }
            }
        }
        biomassCopy = GetComponent<BiomassManager>().biomass;
        //Debug.Log($"X{SecondQueenBuyBulkCount} {SecondQueenBuyBulkPrice}");
    }
    public void ThirdQueenBuyCounter()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (biomassCopy >= ThirdQueenPriceCopy)
            {
                biomassCopy -= ThirdQueenPriceCopy;
                ThirdQueenBuyBulkPrice += ThirdQueenPriceCopy;
                ThirdQueenBuyBulkCount += 1;
                ThirdQueenCountCopy += 1;
                if (ThirdQueenCountCopy % 10 == 0 && ThirdQueenCountCopy != 0)
                {
                    ThirdQueenBuyTenCopy += 1;
                    ThirdQueenPriceCopy *= 10 * Math.Pow(ProductionCostX10_Mult, ThirdQueenBuyTenCopy);
                }
                else
                {
                    ThirdQueenPriceCopy *= ProductionCostMult;
                }
            }
        }
        biomassCopy = GetComponent<BiomassManager>().biomass;
        //Debug.Log($"X{ThirdQueenBuyBulkCount} {ThirdQueenBuyBulkPrice}");
    }
    public void FourthQueenBuyCounter()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (biomassCopy >= FourthQueenPriceCopy)
            {
                biomassCopy -= FourthQueenPriceCopy;
                FourthQueenBuyBulkPrice += FourthQueenPriceCopy;
                FourthQueenBuyBulkCount += 1;
                FourthQueenCountCopy += 1;
                if (FourthQueenCountCopy % 10 == 0 && FourthQueenCountCopy != 0)
                {
                    FourthQueenBuyTenCopy += 1;
                    FourthQueenPriceCopy *= 10 * Math.Pow(ProductionCostX10_Mult, FourthQueenBuyTenCopy);
                }
                else
                {
                    FourthQueenPriceCopy *= ProductionCostMult;
                }
            }
        }
        biomassCopy = GetComponent<BiomassManager>().biomass;
        //Debug.Log($"X{FourthQueenBuyBulkCount} {FourthQueenBuyBulkPrice}");
    }
    public void FirstPrimalQueenBuyCounter()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (OPCopy >= FirstPrimalQueenPriceCopy)
            {
                OPCopy -= FirstPrimalQueenPriceCopy;
                FirstPrimalQueenBuyBulkPrice += FirstPrimalQueenPriceCopy;
                FirstPrimalQueenBuyBulkCount += 1;
                FirstPrimalQueenCountCopy += 1;
                if (FirstPrimalQueenCountCopy % 10 == 0 && FirstPrimalQueenCountCopy != 0)
                {
                    FirstPrimalQueenBuyTenCopy += 1;
                    FirstPrimalQueenPriceCopy *= 10 * Math.Pow(ProductionCostX10_Mult, FirstPrimalQueenBuyTenCopy);
                }
                else
                {
                    FirstPrimalQueenPriceCopy *= ProductionCostMult;
                }
            }
        }
        OPCopy = GetComponent<PrestigeUpgrades1>().OP;
        //Debug.Log($"X{FirstPrimalQueenBuyBulkCount} {FirstPrimalQueenBuyBulkPrice}");
    }
    public void FirstHiveBuyCounter()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (biomassCopy >= FirstHivePriceCopy)
            {
                biomassCopy -= FirstHivePriceCopy;
                FirstHiveBuyBulkPrice += FirstHivePriceCopy;
                FirstHiveBuyBulkCount += 1;
                FirstHiveCountCopy += 1;
                if (FirstHiveCountCopy % 10 == 0 && FirstHiveCountCopy != 0)
                {
                    FirstHiveBuyTenCopy += 1;
                    FirstHivePriceCopy *= 10 * Math.Pow(ProductionCostX10_Mult, FirstHiveBuyTenCopy);
                }
                else
                {
                    FirstHivePriceCopy *= ProductionCostMult;
                }
            }
        }
        biomassCopy = GetComponent<BiomassManager>().biomass;
        //Debug.Log($"X{FirstHiveBuyBulkCount} {FirstHiveBuyBulkPrice}");
    }
    public void SecondHiveBuyCounter()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (biomassCopy >= SecondHivePriceCopy)
            {
                biomassCopy -= SecondHivePriceCopy;
                SecondHiveBuyBulkPrice += SecondHivePriceCopy;
                SecondHiveBuyBulkCount += 1;
                SecondHiveCountCopy += 1;
                if (SecondHiveCountCopy % 10 == 0 && SecondHiveCountCopy != 0)
                {
                    SecondHiveBuyTenCopy += 1;
                    SecondHivePriceCopy *= 10 * Math.Pow(ProductionCostX10_Mult, SecondHiveBuyTenCopy);
                }
                else
                {
                    SecondHivePriceCopy *= ProductionCostMult;
                }
            }
        }
        biomassCopy = GetComponent<BiomassManager>().biomass;
        //Debug.Log($"X{SecondHiveBuyBulkCount} {SecondHiveBuyBulkPrice}");
    }
    public void ThirdHiveBuyCounter()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (biomassCopy >= ThirdHivePriceCopy)
            {
                biomassCopy -= ThirdHivePriceCopy;
                ThirdHiveBuyBulkPrice += ThirdHivePriceCopy;
                ThirdHiveBuyBulkCount += 1;
                ThirdHiveCountCopy += 1;
                if (ThirdHiveCountCopy % 10 == 0 && ThirdHiveCountCopy != 0)
                {
                    ThirdHiveBuyTenCopy += 1;
                    ThirdHivePriceCopy *= 10 * Math.Pow(ProductionCostX10_Mult, ThirdHiveBuyTenCopy);
                }
                else
                {
                    ThirdHivePriceCopy *= ProductionCostMult;
                }
            }
        }
        biomassCopy = GetComponent<BiomassManager>().biomass;
        //Debug.Log($"X{ThirdHiveBuyBulkCount} {ThirdHiveBuyBulkPrice}");
    }
    public void FourthHiveBuyCounter()
    {
        for (int i = BuyMult; i > 0; i--)
        {
            if (biomassCopy >= FourthHivePriceCopy)
            {
                biomassCopy -= FourthHivePriceCopy;
                FourthHiveBuyBulkPrice += FourthHivePriceCopy;
                FourthHiveBuyBulkCount += 1;
                FourthHiveCountCopy += 1;
                if (FourthHiveCountCopy % 10 == 0 && FourthHiveCountCopy != 0)
                {
                    FourthHiveBuyTenCopy += 1;
                    FourthHivePriceCopy *= 10 * Math.Pow(ProductionCostX10_Mult, FourthHiveBuyTenCopy);
                }
                else
                {
                    FourthHivePriceCopy *= ProductionCostMult;
                }
            }
        }
        biomassCopy = GetComponent<BiomassManager>().biomass;
        //Debug.Log($"X{FourthHiveBuyBulkCount} {FourthHiveBuyBulkPrice}");
    }
    /// -------------------------------------------------------------------------------
    public void ProductionTextUpdater()
    {
        {
            productions[0].transform.GetChild(1).GetComponent<Text>().text = $"{(FirstQueenCount + FirstQueenAddedCount).ToString("0.00e0")}";
            if ((FirstQueenCount + FirstQueenAddedCount) < 1000000)
            {
                productions[0].transform.GetChild(1).GetComponent<Text>().text = $"{(FirstQueenCount + FirstQueenAddedCount).ToString("0")}";
            }
            if (FirstQueenMult < 1000000)
            {
                productions[0].transform.GetChild(2).GetComponent<Text>().text = $"x{FirstQueenMult.ToString("0")}";
            }
            else
            {
                productions[0].transform.GetChild(2).GetComponent<Text>().text = $"x{FirstQueenMult.ToString("0.00e0")}";
            }
            productions[0].transform.GetChild(3).GetComponent<Text>().text = $"{FirstQueenCount % 10}/10";
            if (BuyMult == 1)
            {
                if (FirstQueenPrice < 1000000)
                {
                    productions[0].transform.GetChild(4).GetComponent<Text>().text = $"{FirstQueenPrice.ToString("0.0")}";
                }
                else
                {
                    productions[0].transform.GetChild(4).GetComponent<Text>().text = $"{FirstQueenPrice.ToString("0.00e0")}";
                }
            }
            else
            {
                FirstQueenBuyCounter();
                if (FirstQueenBuyBulkPrice == 0)
                {
                    FirstQueenBuyBulkPrice = FirstQueenPrice;
                }
                if (FirstQueenBuyBulkCount == 0)
                {
                    FirstQueenBuyBulkCount = 1;
                }

                if (FirstQueenBuyBulkPrice < 1000000)
                {
                    productions[0].transform.GetChild(4).GetComponent<Text>().text = $"x{FirstQueenBuyBulkCount} {FirstQueenBuyBulkPrice.ToString("0.0")}";
                    FirstQueenBuyBulkCount = FirstQueenBuyBulkPrice = 0;
                }
                else
                {
                    productions[0].transform.GetChild(4).GetComponent<Text>().text = $"x{FirstQueenBuyBulkCount} {FirstQueenBuyBulkPrice.ToString("0.00e0")}";
                    FirstQueenBuyBulkCount = FirstQueenBuyBulkPrice = 0;
                }
            }
        }//1
        {
            productions[1].transform.GetChild(1).GetComponent<Text>().text = $"{(FirstHiveCount + FirstHiveAddedCount).ToString("0.00e0")}";
            if ((FirstHiveCount + FirstHiveAddedCount) < 1000000)
            {
                productions[1].transform.GetChild(1).GetComponent<Text>().text = $"{(FirstHiveCount + FirstHiveAddedCount).ToString("0")}";
            }
            if (FirstHiveMult < 1000000)
            {
                productions[1].transform.GetChild(2).GetComponent<Text>().text = $"x{FirstHiveMult.ToString("0")}";
            }
            else
            {
                productions[1].transform.GetChild(2).GetComponent<Text>().text = $"x{FirstHiveMult.ToString("0.00e0")}";
            }
            productions[1].transform.GetChild(3).GetComponent<Text>().text = $"{FirstHiveCount % 10}/10";
            if (BuyMult == 1)
            {
                if (FirstHivePrice < 1000000)
                {
                    productions[1].transform.GetChild(4).GetComponent<Text>().text = $"{FirstHivePrice.ToString("0.0")}";
                }
                else
                {
                    productions[1].transform.GetChild(4).GetComponent<Text>().text = $"{FirstHivePrice.ToString("0.00e0")}";
                }
            }
            else
            {
                FirstHiveBuyCounter();
                if (FirstHiveBuyBulkPrice == 0)
                {
                    FirstHiveBuyBulkPrice = FirstHivePrice;
                }
                if (FirstHiveBuyBulkCount == 0)
                {
                    FirstHiveBuyBulkCount = 1;
                }

                if (FirstHiveBuyBulkPrice < 1000000)
                {
                    productions[1].transform.GetChild(4).GetComponent<Text>().text = $"x{FirstHiveBuyBulkCount} {FirstHiveBuyBulkPrice.ToString("0.0")}";
                    FirstHiveBuyBulkCount = FirstHiveBuyBulkPrice = 0;
                }
                else
                {
                    productions[1].transform.GetChild(4).GetComponent<Text>().text = $"x{FirstHiveBuyBulkCount} {FirstHiveBuyBulkPrice.ToString("0.00e0")}";
                    FirstHiveBuyBulkCount = FirstHiveBuyBulkPrice = 0;
                }
            }
        }//2
        {
            productions[2].transform.GetChild(1).GetComponent<Text>().text = $"{(SecondQueenCount + SecondQueenAddedCount).ToString("0.00e0")}";
            if ((SecondQueenCount + SecondQueenAddedCount) < 1000000)
            {
                productions[2].transform.GetChild(1).GetComponent<Text>().text = $"{(SecondQueenCount + SecondQueenAddedCount).ToString("0")}";
            }
            if (SecondQueenMult < 1000000)
            {
                productions[2].transform.GetChild(2).GetComponent<Text>().text = $"x{SecondQueenMult.ToString("0")}";
            }
            else
            {
                productions[2].transform.GetChild(2).GetComponent<Text>().text = $"x{SecondQueenMult.ToString("0.00e0")}";
            }
            productions[2].transform.GetChild(3).GetComponent<Text>().text = $"{SecondQueenCount % 10}/10";
            if (BuyMult == 1)
            {
                if (SecondQueenPrice < 1000000)
                {
                    productions[2].transform.GetChild(4).GetComponent<Text>().text = $"{SecondQueenPrice.ToString("0.0")}";
                }
                else
                {
                    productions[2].transform.GetChild(4).GetComponent<Text>().text = $"{SecondQueenPrice.ToString("0.00e0")}";
                }
            }
            else
            {
                SecondQueenBuyCounter();
                if (SecondQueenBuyBulkPrice == 0)
                {
                    SecondQueenBuyBulkPrice = SecondQueenPrice;
                }
                if (SecondQueenBuyBulkCount == 0)
                {
                    SecondQueenBuyBulkCount = 1;
                }

                if (SecondQueenBuyBulkPrice < 1000000)
                {
                    productions[2].transform.GetChild(4).GetComponent<Text>().text = $"x{SecondQueenBuyBulkCount} {SecondQueenBuyBulkPrice.ToString("0.0")}";
                    SecondQueenBuyBulkCount = SecondQueenBuyBulkPrice = 0;
                }
                else
                {
                    productions[2].transform.GetChild(4).GetComponent<Text>().text = $"x{SecondQueenBuyBulkCount} {SecondQueenBuyBulkPrice.ToString("0.00e0")}";
                    SecondQueenBuyBulkCount = SecondQueenBuyBulkPrice = 0;
                }
            }
        }//3
        {
            productions[3].transform.GetChild(1).GetComponent<Text>().text = $"{(SecondHiveCount + SecondHiveAddedCount).ToString("0.00e0")}";
            if ((SecondHiveCount + SecondHiveAddedCount) < 1000000)
            {
                productions[3].transform.GetChild(1).GetComponent<Text>().text = $"{(SecondHiveCount + SecondHiveAddedCount).ToString("0")}";
            }
            if (SecondHiveMult < 1000000)
            {
                productions[3].transform.GetChild(2).GetComponent<Text>().text = $"x{SecondHiveMult.ToString("0")}";
            }
            else
            {
                productions[3].transform.GetChild(2).GetComponent<Text>().text = $"x{SecondHiveMult.ToString("0.00e0")}";
            }
            productions[3].transform.GetChild(3).GetComponent<Text>().text = $"{SecondHiveCount % 10}/10";
            if (BuyMult == 1)
            {
                if (SecondHivePrice < 1000000)
                {
                    productions[3].transform.GetChild(4).GetComponent<Text>().text = $"{SecondHivePrice.ToString("0.0")}";
                }
                else
                {
                    productions[3].transform.GetChild(4).GetComponent<Text>().text = $"{SecondHivePrice.ToString("0.00e0")}";
                }
            }
            else
            {
                SecondHiveBuyCounter();
                if (SecondHiveBuyBulkPrice == 0)
                {
                    SecondHiveBuyBulkPrice = SecondHivePrice;
                }
                if (SecondHiveBuyBulkCount == 0)
                {
                    SecondHiveBuyBulkCount = 1;
                }

                if (SecondHiveBuyBulkPrice < 1000000)
                {
                    productions[3].transform.GetChild(4).GetComponent<Text>().text = $"x{SecondHiveBuyBulkCount} {SecondHiveBuyBulkPrice.ToString("0.0")}";
                    SecondHiveBuyBulkCount = SecondHiveBuyBulkPrice = 0;
                }
                else
                {
                    productions[3].transform.GetChild(4).GetComponent<Text>().text = $"x{SecondHiveBuyBulkCount} {SecondHiveBuyBulkPrice.ToString("0.00e0")}";
                    SecondHiveBuyBulkCount = SecondHiveBuyBulkPrice = 0;
                }
            }
        }//4
        {
            productions[4].transform.GetChild(1).GetComponent<Text>().text = $"{(ThirdQueenCount + ThirdQueenAddedCount).ToString("0.00e0")}";
            if ((ThirdQueenCount + ThirdQueenAddedCount) < 1000000)
            {
                productions[4].transform.GetChild(1).GetComponent<Text>().text = $"{(ThirdQueenCount + ThirdQueenAddedCount).ToString("0")}";
            }
            if (ThirdQueenMult < 1000000)
            {
                productions[4].transform.GetChild(2).GetComponent<Text>().text = $"x{ThirdQueenMult.ToString("0")}";
            }
            else
            {
                productions[4].transform.GetChild(2).GetComponent<Text>().text = $"x{ThirdQueenMult.ToString("0.00e0")}";
            }
            productions[4].transform.GetChild(3).GetComponent<Text>().text = $"{ThirdQueenCount % 10}/10";
            if (BuyMult == 1)
            {
                if (ThirdQueenPrice < 1000000)
                {
                    productions[4].transform.GetChild(4).GetComponent<Text>().text = $"{ThirdQueenPrice.ToString("0.0")}";
                }
                else
                {
                    productions[4].transform.GetChild(4).GetComponent<Text>().text = $"{ThirdQueenPrice.ToString("0.00e0")}";
                }
            }
            else
            {
                ThirdQueenBuyCounter();
                if (ThirdQueenBuyBulkPrice == 0)
                {
                    ThirdQueenBuyBulkPrice = ThirdQueenPrice;
                }
                if (ThirdQueenBuyBulkCount == 0)
                {
                    ThirdQueenBuyBulkCount = 1;
                }

                if (ThirdQueenBuyBulkPrice < 1000000)
                {
                    productions[4].transform.GetChild(4).GetComponent<Text>().text = $"x{ThirdQueenBuyBulkCount} {ThirdQueenBuyBulkPrice.ToString("0.0")}";
                    ThirdQueenBuyBulkCount = ThirdQueenBuyBulkPrice = 0;
                }
                else
                {
                    productions[4].transform.GetChild(4).GetComponent<Text>().text = $"x{ThirdQueenBuyBulkCount} {ThirdQueenBuyBulkPrice.ToString("0.00e0")}";
                    ThirdQueenBuyBulkCount = ThirdQueenBuyBulkPrice = 0;
                }
            }
        }//5
        {
            productions[5].transform.GetChild(1).GetComponent<Text>().text = $"{(ThirdHiveCount + ThirdHiveAddedCount).ToString("0.00e0")}";
            if ((ThirdHiveCount + ThirdHiveAddedCount) < 1000000)
            {
                productions[5].transform.GetChild(1).GetComponent<Text>().text = $"{(ThirdHiveCount + ThirdHiveAddedCount).ToString("0")}";
            }
            if (ThirdHiveMult < 1000000)
            {
                productions[5].transform.GetChild(2).GetComponent<Text>().text = $"x{ThirdHiveMult.ToString("0")}";
            }
            else
            {
                productions[5].transform.GetChild(2).GetComponent<Text>().text = $"x{ThirdHiveMult.ToString("0.00e0")}";
            }
            productions[5].transform.GetChild(3).GetComponent<Text>().text = $"{ThirdHiveCount % 10}/10";
            if (BuyMult == 1)
            {
                if (ThirdHivePrice < 1000000)
                {
                    productions[5].transform.GetChild(4).GetComponent<Text>().text = $"{ThirdHivePrice.ToString("0.0")}";
                }
                else
                {
                    productions[5].transform.GetChild(4).GetComponent<Text>().text = $"{ThirdHivePrice.ToString("0.00e0")}";
                }
            }
            else
            {
                ThirdHiveBuyCounter();
                if (ThirdHiveBuyBulkPrice == 0)
                {
                    ThirdHiveBuyBulkPrice = ThirdHivePrice;
                }
                if (ThirdHiveBuyBulkCount == 0)
                {
                    ThirdHiveBuyBulkCount = 1;
                }

                if (ThirdHiveBuyBulkPrice < 1000000)
                {
                    productions[5].transform.GetChild(4).GetComponent<Text>().text = $"x{ThirdHiveBuyBulkCount} {ThirdHiveBuyBulkPrice.ToString("0.0")}";
                    ThirdHiveBuyBulkCount = ThirdHiveBuyBulkPrice = 0;
                }
                else
                {
                    productions[5].transform.GetChild(4).GetComponent<Text>().text = $"x{ThirdHiveBuyBulkCount} {ThirdHiveBuyBulkPrice.ToString("0.00e0")}";
                    ThirdHiveBuyBulkCount = ThirdHiveBuyBulkPrice = 0;
                }
            }
        }//6
        {
            productions[6].transform.GetChild(1).GetComponent<Text>().text = $"{(FourthQueenCount + FourthQueenAddedCount).ToString("0.00e0")}";
            if ((FourthQueenCount + FourthQueenAddedCount) < 1000000)
            {
                productions[6].transform.GetChild(1).GetComponent<Text>().text = $"{(FourthQueenCount + FourthQueenAddedCount).ToString("0")}";
            }
            if (FourthQueenMult < 1000000)
            {
                productions[6].transform.GetChild(2).GetComponent<Text>().text = $"x{FourthQueenMult.ToString("0")}";
            }
            else
            {
                productions[6].transform.GetChild(2).GetComponent<Text>().text = $"x{FourthQueenMult.ToString("0.00e0")}";
            }
            productions[6].transform.GetChild(3).GetComponent<Text>().text = $"{FourthQueenCount % 10}/10";
            if (BuyMult == 1)
            {
                if (FourthQueenPrice < 1000000)
                {
                    productions[6].transform.GetChild(4).GetComponent<Text>().text = $"{FourthQueenPrice.ToString("0.0")}";
                }
                else
                {
                    productions[6].transform.GetChild(4).GetComponent<Text>().text = $"{FourthQueenPrice.ToString("0.00e0")}";
                }
            }
            else
            {
                FourthQueenBuyCounter();
                if (FourthQueenBuyBulkPrice == 0)
                {
                    FourthQueenBuyBulkPrice = FourthQueenPrice;
                }
                if (FourthQueenBuyBulkCount == 0)
                {
                    FourthQueenBuyBulkCount = 1;
                }

                if (FourthQueenBuyBulkPrice < 1000000)
                {
                    productions[6].transform.GetChild(4).GetComponent<Text>().text = $"x{FourthQueenBuyBulkCount} {FourthQueenBuyBulkPrice.ToString("0.0")}";
                    FourthQueenBuyBulkCount = FourthQueenBuyBulkPrice = 0;
                }
                else
                {
                    productions[6].transform.GetChild(4).GetComponent<Text>().text = $"x{FourthQueenBuyBulkCount} {FourthQueenBuyBulkPrice.ToString("0.00e0")}";
                    FourthQueenBuyBulkCount = FourthQueenBuyBulkPrice = 0;
                }
            }
        }//7
        {
            productions[7].transform.GetChild(1).GetComponent<Text>().text = $"{(FourthHiveCount + FourthHiveAddedCount).ToString("0.00e0")}";
            if ((FourthHiveCount + FourthHiveAddedCount) < 1000000)
            {
                productions[7].transform.GetChild(1).GetComponent<Text>().text = $"{(FourthHiveCount + FourthHiveAddedCount).ToString("0")}";
            }
            if (FourthHiveMult < 1000000)
            {
                productions[7].transform.GetChild(2).GetComponent<Text>().text = $"x{FourthHiveMult.ToString("0")}";
            }
            else
            {
                productions[7].transform.GetChild(2).GetComponent<Text>().text = $"x{FourthHiveMult.ToString("0.00e0")}";
            }
            productions[7].transform.GetChild(3).GetComponent<Text>().text = $"{FourthHiveCount % 10}/10";
            if (BuyMult == 1)
            {
                if (FourthHivePrice < 1000000)
                {
                    productions[7].transform.GetChild(4).GetComponent<Text>().text = $"{FourthHivePrice.ToString("0.0")}";
                }
                else
                {
                    productions[7].transform.GetChild(4).GetComponent<Text>().text = $"{FourthHivePrice.ToString("0.00e0")}";
                }
            }
            else
            {
                FourthHiveBuyCounter();
                if (FourthHiveBuyBulkPrice == 0)
                {
                    FourthHiveBuyBulkPrice = FourthHivePrice;
                }
                if (FourthHiveBuyBulkCount == 0)
                {
                    FourthHiveBuyBulkCount = 1;
                }

                if (FourthHiveBuyBulkPrice < 1000000)
                {
                    productions[7].transform.GetChild(4).GetComponent<Text>().text = $"x{FourthHiveBuyBulkCount} {FourthHiveBuyBulkPrice.ToString("0.0")}";
                    FourthHiveBuyBulkCount = FourthHiveBuyBulkPrice = 0;
                }
                else
                {
                    productions[7].transform.GetChild(4).GetComponent<Text>().text = $"x{FourthHiveBuyBulkCount} {FourthHiveBuyBulkPrice.ToString("0.00e0")}";
                    FourthHiveBuyBulkCount = FourthHiveBuyBulkPrice = 0;
                }
            }
        }//8
        {
            productions[8].transform.GetChild(1).GetComponent<Text>().text = $"{(FirstPrimalQueenCount + FirstPrimalQueenAddedCount).ToString("0.00e0")}";
            if ((FirstPrimalQueenCount + FirstPrimalQueenAddedCount) < 1000000)
            {
                productions[8].transform.GetChild(1).GetComponent<Text>().text = $"{(FirstPrimalQueenCount + FirstPrimalQueenAddedCount).ToString("0")}";
            }
            if (FirstPrimalQueenMult < 1000000)
            {
                productions[8].transform.GetChild(2).GetComponent<Text>().text = $"x{FirstPrimalQueenMult.ToString("0")}";
            }
            else
            {
                productions[8].transform.GetChild(2).GetComponent<Text>().text = $"x{FirstPrimalQueenMult.ToString("0.00e0")}";
            }
            productions[8].transform.GetChild(3).GetComponent<Text>().text = $"{FirstPrimalQueenCount % 10}/10";
            if (BuyMult == 1)
            {
                if (FirstPrimalQueenPrice < 1000000)
                {
                    productions[8].transform.GetChild(4).GetComponent<Text>().text = $"{FirstPrimalQueenPrice.ToString("0.0 OP")}";
                }
                else
                {
                    productions[8].transform.GetChild(4).GetComponent<Text>().text = $"{FirstPrimalQueenPrice.ToString("0.00e0 OP")}";
                }
            }
            else
            {
                FirstPrimalQueenBuyCounter();
                if (FirstPrimalQueenBuyBulkPrice == 0)
                {
                    FirstPrimalQueenBuyBulkPrice = FirstPrimalQueenPrice;
                }
                if (FirstPrimalQueenBuyBulkCount == 0)
                {
                    FirstPrimalQueenBuyBulkCount = 1;
                }

                if (FirstPrimalQueenBuyBulkPrice < 1000000)
                {
                    productions[8].transform.GetChild(4).GetComponent<Text>().text = $"x{FirstPrimalQueenBuyBulkCount} {FirstPrimalQueenBuyBulkPrice.ToString("0.0 OP")}";
                    FirstPrimalQueenBuyBulkCount = FirstPrimalQueenBuyBulkPrice = 0;
                }
                else
                {
                    productions[8].transform.GetChild(4).GetComponent<Text>().text = $"x{FirstPrimalQueenBuyBulkCount} {FirstPrimalQueenBuyBulkPrice.ToString("0.00e0 OP")}";
                    FirstPrimalQueenBuyBulkCount = FirstPrimalQueenBuyBulkPrice = 0;
                }
            }
        }//9
        //Debug.Log("qwe");
    }
    /// -------------------------------------------------------------------------------
    public void WinText1()
    {
        Invoke("WinText2", 3f);
        WinTexts[wt].SetActive(true);
        wt++;
    }
    public void WinText2()
    {
        Invoke("WinText3", 3f);
        WinTexts[wt].SetActive(true);
        wt++;
    }
    public void WinText3()
    {
        Invoke("WinText4", 3f);
        WinTexts[wt].SetActive(true);
        wt++;
    }
    public void WinText4()
    {
        //Invoke("WinText4", 3f);
        WinTexts[wt].SetActive(true);
        //wt++;
    }
    public void SceneReaload(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }
    /// -------------------------------------------------------------------------------
    public void GameStart()
    {
        Hints[0].SetActive(true);
    }
    public void MergeUnlock()
    {
        if (GetComponent<BiomassManager>().biomass >= 1e40)
        {
            GetComponent<BiomassManager>().biomass -= 1e40;
        }
    }
    public void QQUnlock()
    {
        if (GetComponent<BiomassManager>().biomass >= 1e200)
        {
            GetComponent<BiomassManager>().biomass -= 1e200;
        }
    }
    public void SpireUnlock()
    {
        if (GetComponent<BiomassManager>().biomass >= 1e300)
        {
            GetComponent<BiomassManager>().biomass -= 1e300;
        }
    }
    /// -------------------------------------------------------------------------------
    
}