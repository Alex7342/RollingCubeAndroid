using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image blackImage;
    public AnimationCurve curve;

    public float fadeInTime = 1f;
    public float fadeOutTime = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut());
        SceneManager.LoadScene(scene);
    }

    IEnumerator FadeIn()
    {
        float t = fadeInTime;

        while (t > 0f)
        {
            float a = curve.Evaluate(t);
            blackImage.color = new Color(0f, 0f, 0f, a);
            t -= Time.deltaTime;
            yield return 0;
        }
    }

    IEnumerator FadeOut()
    {
        float t = 0f;

        while (t < fadeOutTime)
        {
            float a = curve.Evaluate(t);
            blackImage.color = new Color(0f, 0f, 0f, a);
            t += Time.deltaTime;
            yield return 0;
        }
    }
}
