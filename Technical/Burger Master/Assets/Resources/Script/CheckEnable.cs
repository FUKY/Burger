﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class CheckEnable : MonoBehaviour {

    public bool isEnable = false;
    public TypeFood foodType;
    public GameObject itemEnable;
    public GameObject itemDisable;
    public GameObject transParentFood;
    public GameObject transParentDrink;

    int numCheck = 0;
    // Use this for initialization
    void Start()
    {
        Check();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnable(bool _isEnable) 
    {
        isEnable = _isEnable;
        Check();
    }

    void Check()
    {
        if (!isEnable)
        {
            itemEnable.SetActive(false);
            itemDisable.SetActive(true);
        }
        else if (isEnable)
        {
            itemEnable.SetActive(true);
            itemDisable.SetActive(false);
        }
    }

    public void ButtonFoodClick()
    {
    }

    public void DrinkClick()
    {

    }
}
