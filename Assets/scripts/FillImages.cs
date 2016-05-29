using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

public class FillImages : MonoBehaviour {

    private ArrayList prefabs;
    

    // Use this for initialization
    void Start () {
        prefabs = getPrefabs();
        setPositions(prefabs);
    }

    void Update() {

        ArrayList choosedCards = GetChoosedCards(prefabs);

        if (choosedCards.Count == 3)
        {
            if (IsDifferent(choosedCards))
            {
                Debug.Log("Win");
            }
            else
            {
                Debug.Log("Lose");
            }
        }
    }

    ArrayList GetChoosedCards(ArrayList prefabs) {
        ArrayList choosedCards = new ArrayList();
        foreach (GameObject prefab in prefabs)
        {
            CardSettings cardSettings = prefab.GetComponent<CardSettings>();
            Debug.Log("Gets" + choosedCards.Count);
            if (cardSettings.isChoose)
            {
                choosedCards.Add(cardSettings);
            }
        }
        Debug.Log("Get" + choosedCards.Count);
        return choosedCards;
    }

    bool IsDifferent(ArrayList choosedCards)
    {
        CardSettings card1 = (CardSettings)choosedCards[0];
        CardSettings card2 = (CardSettings)choosedCards[1];
        CardSettings card3 = (CardSettings)choosedCards[2];

        Debug.Log(card1.color);

        if ((card1.color != card2.color && card1.color != card3.color) &&
            (card1.number != card2.number && card1.number != card3.number) &&
            (card1.shape != card2.shape && card1.shape != card3.shape) &&
            (card1.image != card2.image && card1.image != card3.image))
        {
            Debug.Log("Dif");
            return true;
        }
        Debug.Log("Same");
        return false;
    }

    void ChooseCard(GameObject prefab)
    {
        prefab.GetComponent<CardSettings>().isChoose = !prefab.GetComponent<CardSettings>().isChoose;
        Debug.Log(prefab.GetComponent<CardSettings>().isChoose);
    }


    ArrayList getPrefabs(){
        ArrayList gameObjects = new ArrayList();
        GameObject panel = GameObject.Find("Panel");
        
        for (int i = 1; i <= 12; ++i)
        {
            Object prefab = AssetDatabase.LoadAssetAtPath("Assets/cards/card" + i + ".prefab", typeof(GameObject));
            gameObjects.Add(Instantiate(prefab) as GameObject);
        }
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.transform.SetParent(panel.transform, false);
            gameObject.transform.position = new Vector2();
        }
        return gameObjects;
    }
	
	// Update is called once per frame

    void setPositions(ArrayList gameObjects) {
        float startX = 500;
        float startY = 200;
        int curX = 0, curY = 0;
        int coefShiftX = 120;
        int coefShiftY = 120;
        foreach (GameObject gameObject in gameObjects) {
            gameObject.transform.position = new Vector2(startX + coefShiftX * curX, startY + coefShiftY * curY);
            ++curX;
            if (curX == 4){
                curX = 0;
                ++curY;
            }
        }
    }



}
