using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public void ShowUI()
    {
        canvasGroup.DOFade(1, 0.5f);
    }

    public void HideUI()
    {
        canvasGroup.DOFade(0, 0.5f).onComplete = ()=>
        {
            gameObject.SetActive(false);
        };
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
