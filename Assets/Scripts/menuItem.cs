using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuItem : MonoBehaviour
{
  [HideInInspector] public Image img;
    [HideInInspector] public Transform trans;

    menu menuCS;
    Button button;
    int index;

   

    void Awake()
    {
        

        img = GetComponent<Image>();
        trans = transform;

        menuCS = trans.parent.GetComponent<menu>();
        index = trans.GetSiblingIndex() - 1;

        button = GetComponent<Button>();
        button.onClick.AddListener(OnItemClick);
    }

    void OnItemClick()
    {
        menuCS.OnItemClick(index);
    }

    void OnDestroy()
    {
        button.onClick.RemoveListener(OnItemClick);
    }

}
