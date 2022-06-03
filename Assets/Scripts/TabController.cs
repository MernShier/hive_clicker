using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    public bool Checker;
    [SerializeField]
    public void SetTrue(GameObject ObjectSetTrue)
    {
        ObjectSetTrue.SetActive(true);
    }
    public void SetFalse(GameObject ObjectSetTrue)
    {
        ObjectSetTrue.SetActive(false);
    }
}
