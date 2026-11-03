using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SSimonSays : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject[] colors;

    public SGame game;

    private List<int> sequence = new List<int>();
    private int total = 0;
    private bool playerTurn = false;
    private int count = 0;
    private int round = 0;
    private Color ogColor;

    private void Awake()
    {
        ogColor = colors[0].GetComponent<Renderer>().material.color;
        StartCoroutine(Simon());
    }
    

    IEnumerator Simon()
    {
        while (round < 5)
        {
            round++;
            int random = Random.Range(0, buttons.Length);
            sequence.Add(random);

            playerTurn = false;


            foreach (int i in sequence)
            {
                Renderer panel = colors[0].GetComponent<Renderer>();
                Renderer button = buttons[i].GetComponent<Renderer>();

                panel.material.color = button.material.color;
                yield return new WaitForSeconds(0.5f);
                panel.material.color = ogColor;
                yield return new WaitForSeconds(0.25f);
            }
            count = 0;
            playerTurn = true;

            while (playerTurn)
            {
                yield return null;
            }
            if (round < 5)
            {
                yield return new WaitForSeconds(1f);
            }
        }

        Debug.Log("Working?");
    }
    IEnumerator FlashPanel(int index)
    {
        Renderer panel = colors[0].GetComponent<Renderer>();
        Renderer button = buttons[index].GetComponent<Renderer>();

        panel.material.color = button.material.color;

        yield return new WaitForSeconds(0.3f);

        panel.material.color = ogColor;
    }
    public void RestartPuzzle()
    {
        StopAllCoroutines();

        sequence.Clear();
        count = 0;
        round = 0;
        playerTurn = false;
        total = 0;
        colors[0].GetComponent<Renderer>().material.color = ogColor;
        StartCoroutine(Simon());
    }
    public void ButtonPressed(int index)
    {

        if (!playerTurn)
        {
            return;
        }

        StartCoroutine(FlashPanel(index));
        if(index == sequence[count])
        {
            count++;
            if(count == sequence.Count)
            {
                playerTurn = false;
                total++;
            }
            if (total == 5)
            {
                game.number += 1;
            }
        }
        else
        {
            playerTurn = false;
            Debug.Log("Hello i sthis working");
            RestartPuzzle();
        }
    }
}
