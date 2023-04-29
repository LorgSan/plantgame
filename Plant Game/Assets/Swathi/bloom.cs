using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class bloom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ public GameObject[] Setoff;
    public GameObject[] SetOn;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("cursor over");
        foreach (GameObject obj in SetOn)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in Setoff)
        {
            obj.SetActive(false);
        }

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("cursor exit");
        foreach (GameObject obj in SetOn)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in Setoff)
        {
            obj.SetActive(true);
        }
    }


}

