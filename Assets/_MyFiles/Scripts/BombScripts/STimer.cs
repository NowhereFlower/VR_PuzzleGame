using UnityEngine;
using TMPro;
using System.Collections;
using Unity.Collections;
using UnityEngine.SceneManagement;
public class STimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timer;
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;
    public bool timerEnd = false;
    [SerializeField] private ParticleSystem smokeParticle;
    private void Update()
    {
        if (!timerEnd)
        {
            timer -= Time.deltaTime;
            minutes = Mathf.FloorToInt(timer / 60);
            seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);



            if (timer <= 0)
            {
                timerEnd = true;

                smokeParticle.Play();
                StartCoroutine(IDefeat());
            }
        }
    }

    IEnumerator IDefeat()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(0);

    }
}
