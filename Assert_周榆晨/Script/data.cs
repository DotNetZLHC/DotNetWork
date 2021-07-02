using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class data : MonoBehaviour
{
    public string name;
    public string Name { get => GameObject.Find("Canvas/menu/start/InputField").GetComponent<InputField>().text; }
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        name = Name;
        PlayerPrefs.SetString("name", Name);
    }
    public void Update()
    {
        PlayerPrefs.SetString("name", Name); ;
    }
}
