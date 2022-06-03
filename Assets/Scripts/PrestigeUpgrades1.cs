using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeUpgrades1 : MonoBehaviour
{
    public Button button;
    public Color32 maxUpgradeColor;
    public double Overseers, OP, OPOnPrestige1;
    public float AutoBuyersTickspeed;
    public int i, BPC1, AutoBuyerBuyMult, AutoClicks;
    public bool QueenAutoBuyer, HiveAutoBuyer, BuyMax, BuyMaxAutoBuyer;
    public GameObject[] upgrades;
    public GameObject Merge;
    public double[] upgradesPrices;
    public double OPMultUpgradePrice, BuyMaxUpgradePrice, BPCUpgradePrice, AutoClickUpgradePrice, QueenAutoBuyerUpgradePrice, HiveAutoUpgradePrice, AutoBuyerTickspeedUpgradePrice, AutoBuyerBuyMaxUpgradePrice, ProductionCost_X10MultUpgradePrice, ByTenMultUpgradePrice;
    public double OPMult;
    private void Start()
    {
        maxUpgradeColor = new Color32(255, 155, 0, 255);
        button = GetComponent<Button>();
        {
            OPMult = 1;
            OPMultUpgradePrice = 1;
            BPCUpgradePrice = 1;
            BuyMaxUpgradePrice = 1;
            AutoClickUpgradePrice = 1;
            QueenAutoBuyerUpgradePrice = 2;
            HiveAutoUpgradePrice = 2;
            AutoBuyerTickspeedUpgradePrice = 1;
            AutoBuyerBuyMaxUpgradePrice = 10;
            ProductionCost_X10MultUpgradePrice = 15;
            ByTenMultUpgradePrice = 15;
        }// БАЗА

        AutoBuyersTickspeed = 6;
        AutoBuyerBuyMult = 1;
        //Invoke("TestOPGain", 2);
    }
    public void FixedUpdate()
    {
        upgradesPrices = new double[] { OPMultUpgradePrice, BuyMaxUpgradePrice, BPCUpgradePrice, AutoClickUpgradePrice, QueenAutoBuyerUpgradePrice, HiveAutoUpgradePrice, AutoBuyerTickspeedUpgradePrice, AutoBuyerBuyMaxUpgradePrice,  ProductionCost_X10MultUpgradePrice, ByTenMultUpgradePrice };
        //Debug.Log(upgradesPrices);

        {
            if (GetComponent<BiomassManager>().biomass / 1e30 > 1)
            {
                OPOnPrestige1 = 1 * OPMult;
            }
            if (GetComponent<BiomassManager>().biomass / 1e50 > 1)
            {
                OPOnPrestige1 = 2 * OPMult;
            }
            if (GetComponent<BiomassManager>().biomass / 1e75 > 1e50)
            {
                OPOnPrestige1 = 3 * OPMult;
            }
            if (GetComponent<BiomassManager>().biomass / 1e75 > 1e125)
            {
                OPOnPrestige1 = 5 * OPMult;
            }
            if (GetComponent<BiomassManager>().biomass / 1e75 > 1e200)
            {
                OPOnPrestige1 = 7 * OPMult;
            }
            //if (GetComponent<BiomassManager>().biomass / 1e50 > 1e150)
            //{
            //    OPOnPrestige1 = 4 * OPMult;
            //}
            //if (GetComponent<BiomassManager>().biomass / 1e50 > 1e200)
            //{
            //    OPOnPrestige1 = 5 * OPMult;
            //}
            //if (GetComponent<BiomassManager>().biomass / 1e50 > 1e250)
            //{
            //    OPOnPrestige1 = 6 * OPMult;
        }// OPOnPrestige

        foreach (double UpgradePrice in upgradesPrices)
        {
            if (upgrades[i].GetComponent<Button>().enabled)
            {
                if (UpgradePrice <= OP)
                {
                    upgrades[i].GetComponent<Button>().interactable = true;
                }
                else
                {
                    upgrades[i].GetComponent<Button>().interactable = false;
                }
            }
            i++;
        }
        if (OPOnPrestige1 > 0 )
        {
            Merge.GetComponent<Button>().interactable = true;
        }
        else
        {
            Merge.GetComponent<Button>().interactable = false;
        }
        i = 0;
    }
    public void Prestige1()
    {
        Overseers += OPOnPrestige1;
        OP += OPOnPrestige1;
        OPOnPrestige1 = 0;
        AutoBuyersRefresh();
        GetComponent<ProductionPurchase>().BaseValues();
        GetComponent<ProductionPurchase>().ZeroValues();
        GetComponent<BiomassManager>().biomass = GetComponent<ProductionPurchase>().baseBiomass;
    }
    public void OPMultUpgrade(GameObject Upgrade)
    {
        if (OP >= OPMultUpgradePrice)
        {
            OP -= OPMultUpgradePrice;
            OPMultUpgradePrice *= 5;
            OPMult *= 2;
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Your OP will increase by x2\nCurrently: x{OPMult}\n\nCost: {OPMultUpgradePrice} OP";
        }
    }
    public void BuyMaxUpgrade(GameObject Upgrade)
    {
        if (OP >= BuyMaxUpgradePrice)
        {
            BuyMax = true;
            OP -= 1;
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"UNLOCKED";
            Upgrade.transform.GetChild(1).GetComponent<Text>().fontSize = 32;
            MaxUpgradePurchased(Upgrade);
        }
    }
    public void BPCUpgrade(GameObject Upgrade)
    {
        if (OP >= BPCUpgradePrice && BPC1 == 0)
        {
            BPC1 = 1;
            OP -= BPCUpgradePrice;
            BPCUpgradePrice += 4;
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"BPC will increase by\n10% of BPS\nCurrently: 10%\nCost: {BPCUpgradePrice} OP";
        }
        else if (OP >= BPCUpgradePrice && BPC1 == 1)
        {
            BPC1 = 2;
            OP -= BPCUpgradePrice;
            BPCUpgradePrice += 10;
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"BPC will increase by\n10% of BPS\nCurrently: 20%\nCost: {BPCUpgradePrice} OP";
        }
        else if (OP >= BPCUpgradePrice && BPC1 == 2)
        {
            BPC1 = 3;
            OP -= BPCUpgradePrice;
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"BPC will increase by\n10% of BPS\nCurrently: 30%";
            //Upgrade.transform.GetChild(1).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            MaxUpgradePurchased(Upgrade);
        }
    }
    public void AutoClickerUpgrade(GameObject Upgrade)
    {
        if (OP >= AutoClickUpgradePrice)
        {
            OP -= AutoClickUpgradePrice;
            if (AutoClicks > 0)
            {
                AutoClicks++;
            }
            AutoClicks++;
            if (AutoClickUpgradePrice == 1)
            {
                AutoClickUpgradePrice += 4;
            }
            else
            {
                AutoClickUpgradePrice += 5;
            }
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Makes some clicks every second\nCurrently: {AutoClicks}\nCost: {AutoClickUpgradePrice} OP";
        }
        if (AutoClicks == 5)
        {
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Makes some clicks every second\nCurrently: {AutoClicks}";
            //Upgrade.transform.GetChild(1).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            MaxUpgradePurchased(Upgrade);
        }
    }
    public void AutoBuyersTickspeedUpgrade(GameObject Upgrade)
    {
        if (OP >= AutoBuyerTickspeedUpgradePrice && AutoBuyersTickspeed == 6)
        {
            AutoBuyersTickspeed = 4;
            OP -= AutoBuyerTickspeedUpgradePrice;
            AutoBuyerTickspeedUpgradePrice += 4;
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Increase autobuyers tickspeed\nCurrently: {(60/AutoBuyersTickspeed/60).ToString("0.00")}/sec\nCost: {AutoBuyerTickspeedUpgradePrice}";
            AutoBuyersRefresh();
        }
        else if (OP >= AutoBuyerTickspeedUpgradePrice && AutoBuyersTickspeed == 4)
        {
            AutoBuyersTickspeed = 3;
            OP -= AutoBuyerTickspeedUpgradePrice;
            AutoBuyerTickspeedUpgradePrice += 5;
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Increase autobuyers tickspeed\nCurrently: {(60 / AutoBuyersTickspeed / 60).ToString("0.00")}/sec\nCost: {AutoBuyerTickspeedUpgradePrice}";
            AutoBuyersRefresh();
        }
        else if (OP >= AutoBuyerTickspeedUpgradePrice && AutoBuyersTickspeed == 3)
        {
            AutoBuyersTickspeed = 1;
            OP -= AutoBuyerTickspeedUpgradePrice;
            AutoBuyerTickspeedUpgradePrice += 10;
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Increase autobuyers tickspeed\nCurrently: {(60 / AutoBuyersTickspeed / 60).ToString("0.00")}/sec\nCost: {AutoBuyerTickspeedUpgradePrice}";
            AutoBuyersRefresh();
        }
        else if (OP >= AutoBuyerTickspeedUpgradePrice && AutoBuyersTickspeed == 1)
        {
            AutoBuyersTickspeed = 0.5f;
            OP -= AutoBuyerTickspeedUpgradePrice;
            AutoBuyerTickspeedUpgradePrice += 15;
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Increase autobuyers tickspeed\nCurrently: {60 / AutoBuyersTickspeed / 60}/sec\nCost: {AutoBuyerTickspeedUpgradePrice}";
            AutoBuyersRefresh();
        }
        else if (OP >= AutoBuyerTickspeedUpgradePrice && AutoBuyersTickspeed == 0.5f)
        {
            AutoBuyersTickspeed = 0.1f;
            OP -= AutoBuyerTickspeedUpgradePrice;
            AutoBuyersRefresh();
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Increase autobuyers tickspeed\nCurrently: {60 / AutoBuyersTickspeed / 60}/sec\n";
            //Upgrade.transform.GetChild(1).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
            MaxUpgradePurchased(Upgrade);
        }
    }
    public void QueenAutoBuyerUpgrade(GameObject Upgrade)
    {
        if (OP >= QueenAutoBuyerUpgradePrice && QueenAutoBuyer == false)
        {
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = "";
            QueenAutoBuyer = true;
            OP -= QueenAutoBuyerUpgradePrice;
            MaxUpgradePurchased(Upgrade);
        }
    }
    public void HiveAutoBuyerUpgrade(GameObject Upgrade)
    {
        if (OP >= HiveAutoUpgradePrice && HiveAutoBuyer == false)
        {
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = "";
            HiveAutoBuyer = true;
            OP -= HiveAutoUpgradePrice;
            MaxUpgradePurchased(Upgrade);
        }
    }
    public void BuyMaxAutoBuyersUpgrade(GameObject Upgrade)
    {
        if (OP >= AutoBuyerBuyMaxUpgradePrice)
        {
            Upgrade.transform.GetChild(1).GetComponent<Text>().text = "";
            OP -= AutoBuyerBuyMaxUpgradePrice;
            MaxUpgradePurchased(Upgrade);
        }
        
    }
    public void ProductionCost_X10MultUpgrade(GameObject Upgrade)
    {
        if (OP >= ProductionCost_X10MultUpgradePrice)
        {
            if (GetComponent<ProductionPurchase>().ProductionCostX10_Mult >1.1)
            {
                GetComponent<ProductionPurchase>().ProductionCostX10_Mult -= 0.02;
                OP -= ProductionCost_X10MultUpgradePrice;
                ProductionCost_X10MultUpgradePrice += 25;
                Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Procduction cost multiplier growth will be reduced\nCurrently: x{GetComponent<ProductionPurchase>().ProductionCostX10_Mult}\nCost: {ProductionCost_X10MultUpgradePrice} OP";
            }
            else
            {
                OP -= ProductionCost_X10MultUpgradePrice;
                GetComponent<ProductionPurchase>().ProductionCostX10_Mult -= 0.02;
                Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Procduction cost multiplier growth will be reduced\nCurrently: x{GetComponent<ProductionPurchase>().ProductionCostX10_Mult}\n";
                //Upgrade.transform.GetChild(1).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                MaxUpgradePurchased(Upgrade);
            }
        }
    }
    public void BuyTenMultiplierUpgrade(GameObject Upgrade)
    {
        if (OP >= ByTenMultUpgradePrice)
        {
            if (GetComponent<ProductionPurchase>().BuyTenMult<3.4)
            {
                GetComponent<ProductionPurchase>().BuyTenMult += 0.1;
                OP -= ByTenMultUpgradePrice;
                ByTenMultUpgradePrice += 25;
                Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Buy ten multiplier\nincrease\nCurrently: +{GetComponent<ProductionPurchase>().BuyTenMult-1.5}\nCost: {ByTenMultUpgradePrice} OP";
            }
            else
            {
                OP -= ByTenMultUpgradePrice;
                GetComponent<ProductionPurchase>().BuyTenMult += 0.1;
                Upgrade.transform.GetChild(1).GetComponent<Text>().text = $"Buy ten multiplier\nincrease\nCurrently: +{GetComponent<ProductionPurchase>().BuyTenMult - 1.5}";
                //Upgrade.transform.GetChild(1).GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                MaxUpgradePurchased(Upgrade);
            }
        }
    }
    public void AutoBuyersAmountChange()
    {
        if (AutoBuyerBuyMult == 500)
        {
            AutoBuyerBuyMult = 1;
        }
        else
        {
            AutoBuyerBuyMult = 500;
        }
    }
    public void MaxUpgradePurchased(GameObject Button)
    {
        Button.GetComponent<Image>().color = maxUpgradeColor;
        Button.GetComponent<Button>().interactable = false;
        Button.GetComponent<Button>().enabled = false;
    }
    public void AutoBuyersRefresh()
    {
        GetComponent<ProductionPurchase>().QueenAutoBuyerActivator();
        GetComponent<ProductionPurchase>().QueenAutoBuyerActivator();
        GetComponent<ProductionPurchase>().HiveAutoBuyerActivator();
        GetComponent<ProductionPurchase>().HiveAutoBuyerActivator();
    }
    public void AutoBuyersTurn()
    {
        GetComponent<ProductionPurchase>().QueenAutoBuyerActivator();
        GetComponent<ProductionPurchase>().HiveAutoBuyerActivator();
    }
    public void TestOPGain()
    {
        Overseers += 500;
        OP += 500;
    }
    // доделать хуйню) | done
    // отображение цифр продакшена  | done))))))))))
    // обновление текста зафиксировать чтобы не мерцало | done
    // примал квина
    // подсказки | done
    // балансед
    // хайв | done
    // балаааансед
    // озер графика | nedone
}
