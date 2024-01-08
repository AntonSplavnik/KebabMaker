using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class MakingProgress : MonoBehaviour
{
    public Slider progressSlider;
    public Transform playerTransform;
    public Transform testTransform;
    public string food;
    public GameObject test;
    public Text progressText;
    public Text nameText;
    public GameObject ready;
    public Vector3 offset;
    public float totalTimeToMakeSalad = 3f;
    private bool isCollision = false;
    private float currentProgress = 0f;
    public float fadeDuration = 2.0f;

    IEnumerator FadeOut()
    {
        Color originalColor = progressText.color;

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // Calculate the current alpha value based on the elapsed time and duration
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            // Apply the new color with updated alpha value
            progressText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        // Ensure that the text is completely transparent at the end of the fade-out
        progressText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        // Optionally, you can perform additional actions after the fade-out is complete
        Debug.Log("Fade-out complete!");
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        isCollision = true;
        test.gameObject.SetActive(true);
        nameText.text = food;
        UpdateUI();
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        isCollision = false;
    }
    void Update()
    {
        if (isCollision && currentProgress < totalTimeToMakeSalad)
        {
            currentProgress += Time.deltaTime;
            UpdateUI();
        }
        else if (isCollision)
        {
            currentProgress = totalTimeToMakeSalad;
            progressText.color = Color.yellow;
            isCollision = false;
            progressSlider.gameObject.SetActive(false);
            StartCoroutine(FadeOut());
            ready.gameObject.SetActive(true);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        testTransform.position = playerTransform.position + offset;
        float progressPercentage = currentProgress / totalTimeToMakeSalad;
        progressSlider.value = progressPercentage;
        progressText.text =  Mathf.RoundToInt(progressPercentage * 100) + "%";
    }
}
