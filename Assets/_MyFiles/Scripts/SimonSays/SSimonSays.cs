using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SSimonSays : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private GameObject[] colors;

    [SerializeField] private bool[] correctButton;

    private void Awake()
    {
        StartCoroutine(Simon());
    }

    private void SetRandom()
    {
        correctButton = new bool[buttons.Length];
        int random = Random.Range(0, buttons.Length);


    }

    IEnumerator Simon()
    {
        for (int i = 3; i < 8; i++)
        {
            correctButton = new bool[buttons.Length];
            int random = Random.Range(0, buttons.Length);
            for(int r = 0; r < 8; r++)
            {
                Renderer answer = buttons[random].GetComponent<Renderer>();
                Renderer test = colors[0].GetComponent<Renderer>();
                test.material.color = answer.material.color;
                yield return new WaitForSeconds(0.5f);
            }
        }



        yield return null;
    }
}
