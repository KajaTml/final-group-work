﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static bool CANT_FLIP = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    private void Start()
    {
        _state = 1;
        _manager = GameObject.Find("GameManager");
    }
    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);

        flipCard();
    }
    public void flipCard()
    {
        if (_state == 1)
            _state = 0;
        else if (_state == 0)
            _state = 1;

        if (_state == 0 && !CANT_FLIP)
        {
            GetComponent<Image>().sprite = _cardBack;
        }
        else if (_state == 1 && !CANT_FLIP)
        {
            GetComponent<Image>().sprite = _cardFace;
        }
    }

    public int cardValue
    {
        get{ return _cardValue; }
        set { _cardValue = value; }
    }
    public int state
    {
        get { return _state; }
        set { _state = value; }
    }
    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }
    public void falseCheck()
    {
        StartCoroutine(pause());
    }
    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0)
        {
            GetComponent<Image>().sprite = _cardBack;
        }
        else if (_state == 1)
        {
            GetComponent<Image>().sprite = _cardFace;
        }
        CANT_FLIP = false;
    }

}