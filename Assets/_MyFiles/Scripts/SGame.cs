using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SGame : MonoBehaviour
{
    public int number = 0;
    [SerializeField] private GameObject winPanel;

    private void Update()
    {
        if(number == 6)
        {
            winPanel.SetActive(true);
            StartCoroutine(PlayAgain());
        }
    }

    IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
        yield return null;
    }
}
