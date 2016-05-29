using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CardSettings : MonoBehaviour
{

    //hatch, fill, empty
    //rhombus, square, ellipse, curve
    //red, green, blue
    public bool isChoose = false;
    public string color = "red";
    public string shape = "rhombus";
    public string image = "empty";
    public int number = 1;

    // Use this for initialization
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => ChooseCard(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChooseCard(GameObject prefab)
    {
        Debug.Log(prefab.name);
        prefab.GetComponent<CardSettings>().isChoose = !prefab.GetComponent<CardSettings>().isChoose;

    }

    void OnMouseDown()
    {
        Debug.Log("lol");
    }
}
