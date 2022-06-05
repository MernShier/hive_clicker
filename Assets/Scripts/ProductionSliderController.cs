using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductionSliderController : MonoBehaviour
{
    public GameObject Manager;
    public int Number;
    private void FixedUpdate()
    {
        if (Number == 1)
        {
            gameObject.GetComponent<Slider>().value = (float)Manager.GetComponent<ProductionPurchase>().FirstQueenCount % 10;
        }
        if (Number == 2)
        {
            gameObject.GetComponent<Slider>().value = (float)Manager.GetComponent<ProductionPurchase>().FirstHiveCount % 10;
        }
        if (Number == 3)
        {
            gameObject.GetComponent<Slider>().value = (float)Manager.GetComponent<ProductionPurchase>().SecondQueenCount % 10;
        }
        if (Number == 4)
        {
            gameObject.GetComponent<Slider>().value = (float)Manager.GetComponent<ProductionPurchase>().SecondHiveCount % 10;
        }
        if (Number == 5)
        {
            gameObject.GetComponent<Slider>().value = (float)Manager.GetComponent<ProductionPurchase>().ThirdQueenCount % 10;
        }
        if (Number == 6)
        {
            gameObject.GetComponent<Slider>().value = (float)Manager.GetComponent<ProductionPurchase>().ThirdHiveCount % 10;
        }
        if (Number == 7)
        {
            gameObject.GetComponent<Slider>().value = (float)Manager.GetComponent<ProductionPurchase>().FourthQueenCount % 10;
        }
        if (Number == 8)
        {
            gameObject.GetComponent<Slider>().value = (float)Manager.GetComponent<ProductionPurchase>().FourthHiveCount % 10;
        }
        if (Number == 9)
        {
            gameObject.GetComponent<Slider>().value = (float)Manager.GetComponent<ProductionPurchase>().FirstPrimalQueenCount % 10;
        }
    }
}
