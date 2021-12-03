using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;

public class ShowPrice : MonoBehaviour,IPointerEnterHandler
{
    public TMP_Text priceShower;
    [HideInInspector]
    public int price;

    public void OnPointerEnter(PointerEventData eventData)
    {
        priceShower.text = price.ToString();
    }    
    



}
