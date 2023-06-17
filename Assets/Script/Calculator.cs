using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Calculator : MonoBehaviour
{
    public List<int> counts = new List<int>();
    public int InputCount;
    public TMP_InputField InputField;
    public List<TextMeshPro> christmasTreeCounts = new List<TextMeshPro>();
    public TextMeshPro InputText;
    public int randomInt;
    public int countss;
    public int randomListCount;
    public Button CalculatorButton;
    public GameObject christmasTree;
    public GameObject Input;
    public GameObject InputButton;
    public GameObject checkPanel;
    public TMP_InputField trueInput;
    public TextMeshPro result;
    public Button AgainGame;

    public void CalculatorList()
    {
       
        //CalculatorButton.interactable = false;
        InputCount = int.Parse(InputField.text);
        InputText.text = InputField.text;

        for (int i = 1; i <= InputCount; i++)
        {
            if (InputCount < 3)
            {
                result.text = "Asal Sayý Giriþi Yaptýnýz!";
                InputText.text = string.Empty;
                InputCount = 0;
            }
            else
            {
                if (InputCount % i == 0)
                {
                    counts.Add(i);
                }
            }

           
        }

        counts.Sort();
        counts.Reverse();

        
        randomInt = counts[Random.Range(0, counts.Count)];
        randomListCount = counts.IndexOf(randomInt);
        counts.RemoveAt(randomListCount);

        for (int i = 0; i < counts.Count; i++)
        {
           
            christmasTreeCounts[i].text = counts[i].ToString();
        }
        GameAnim();
    }

    public void GameAnim()
    {
        christmasTree.transform.DOMove(new Vector2(0f, -1.25f), .50f);
        Input.transform.DOMove(new Vector2(-2000f, 0f), .50f);
        InputButton.transform.DOMove(new Vector2(2000, 0f), .50f);
        checkPanel.SetActive(true);
    }

    public void TrueCheck()
    {
        if (trueInput.text == randomInt.ToString())
        {
           result.text = "Tebrikler";
            result.color = Color.yellow;
            AgainGame.interactable = true;
        }
        else
        {
            result.text = "Tekrar Dene";
            result.color = Color.red;
            trueInput.text = string.Empty;
        }
    }

    public void AgainGameButton()
    {
        SceneManager.LoadScene(0);
    }

}
