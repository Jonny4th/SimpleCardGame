using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOnOff : MonoBehaviour
{
    [SerializeField]
    GameObject ui;
 
    [SerializeField]
    List<Button> OnSwitch;

    [SerializeField]
    List<Button> OffSwitch;

    void OnEnable()
    {
        if(OnSwitch.Count != 0)
        {
            OnSwitch.ForEach(button => button.onClick.AddListener(Show));
        }
        if(OffSwitch.Count != 0)
        {
            OffSwitch.ForEach(button => button.onClick.AddListener(Hide));
        }
    }

    void OnDisable()
    {
        if(OnSwitch.Count != 0)
        {
            OnSwitch.ForEach(button => button.onClick.RemoveListener(Show));
        }
        if(OffSwitch.Count != 0)
        {
            OffSwitch.ForEach(button => button.onClick.RemoveListener(Hide));
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
