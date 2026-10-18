using UnityEngine;
using Unity.Collections;
using TMPro;
public class SBomb : MonoBehaviour
{
    [SerializeField] private GameObject[] wires;
    [SerializeField] private GameObject[] color;
    [SerializeField] private TextMeshProUGUI wireText;
    private bool[] correctWire;
    //public enum WireType { correctWire, wire1, wire2, wire3 };

    //private WireType wireType;

    private void Awake()
    {
        WireSet();
    }

    private void WireSet()
    {
        correctWire = new bool[wires.Length];
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
            Debug.Log("Wire " + (i + 1) + ": " + (correctWire[i] ? "CORRECT" : "WRONG"));
        }

    }

    public bool IsCorrectWire(int indexWire)
    {
        if(correctWire == null || indexWire < 0 || indexWire >= correctWire.Length)
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
        }
    }
}


