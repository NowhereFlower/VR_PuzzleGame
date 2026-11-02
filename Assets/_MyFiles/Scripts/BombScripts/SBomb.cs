using UnityEngine;
using System.Collections;
using Unity.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class SBomb : MonoBehaviour
{
    [SerializeField] private GameObject[] wires;
    [SerializeField] private GameObject[] color;
    [SerializeField] private TextMeshProUGUI wireText;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private ParticleSystem smokeParticle;
    private bool[] correctWire;

    private void Awake()
    {
        WireSet();
    }

    private void WireSet()
    {
        losePanel.SetActive(false);
        correctWire = new bool[wires.Length];
        //Seting the wires color and if it's correct or not at random
        int random = Random.Range(0, wires.Length);
        int second;
        do
        {
            second = Random.Range(0, wires.Length);
        }
        while (second == random);

        correctWire[random] = true;
        correctWire[second] = true;

        Renderer wireR = wires[random].GetComponent<Renderer>();
        Renderer wiresR = wires[second].GetComponent<Renderer>();
        Renderer sphereR = color[0].GetComponent<Renderer>();
        Renderer spheresR = color[1].GetComponent<Renderer>();

        sphereR.material.color = wireR.material.color;
        spheresR.material.color = wiresR.material.color;



        for (int i = 0; i < wires.Length; i++)
        {
            //Tells which wire is correct or wrong
            Debug.Log("Wire " + (i + 1) + ": " + (correctWire[i] ? "CORRECT" : "WRONG"));
        }

    }

    public bool IsCorrectWire(int indexWire)
    {
        if (correctWire == null || indexWire < 0 || indexWire >= correctWire.Length)
        {
            return false;
        }

        return correctWire[indexWire];

    }

    public void CutWire(int indexWire)
    {

        if (correctWire[indexWire])
        {
            wireText.text = "Correct Wire!";
        }
        else
        {
            wireText.text = "Wrong Wire!";
            smokeParticle.Play();
            losePanel.SetActive(true);
            StartCoroutine(IDefeat());
        }
    }

    //Goes back and restarts level\
    //May add a fade in effect
    IEnumerator IDefeat()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(0);

    }
}


