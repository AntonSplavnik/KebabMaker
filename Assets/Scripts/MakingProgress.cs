using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class MakingProgress : MonoBehaviour
{
    public Slider progressSlider;
    public Transform playerTransform;
    public string food;
    public GameObject test;
    public Text nameText;
    public GameObject ready;
    public AudioSource doneSound;
    public Vector2 offset;
    public float totalTimeToMakeSalad = 3f;
    private bool isCollision = false;
    private float currentProgress = 0f;

    // IEnumerator FadeOut()
    // {
    //     Color originalColor = progressText.color;

    //     float elapsedTime = 0f;
    //     while (elapsedTime < fadeDuration)
    //     {
    //         // Calculate the current alpha value based on the elapsed time and duration
    //         float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

    //         // Apply the new color with updated alpha value
    //         progressText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

    //         // Increment the elapsed time
    //         elapsedTime += Time.deltaTime;

    //         // Wait for the next frame
    //         yield return null;
    //     }

    //     // Ensure that the text is completely transparent at the end of the fade-out
    //     progressText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

    //     // Optionally, you can perform additional actions after the fade-out is complete
    //     Debug.Log("Fade-out complete!");
    // }
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
            currentProgress = Mathf.Clamp(currentProgress + Time.deltaTime, 0, totalTimeToMakeSalad); 
            UpdateUI();
            progressSlider.transform.position = new Vector2(playerTransform.position.x, playerTransform.position.y) + offset;
        }
        else if (isCollision)
        {
            doneSound.Play();
            currentProgress = totalTimeToMakeSalad;
            isCollision = false;
            test.gameObject.SetActive(false);
            //StartCoroutine(FadeOut());
            ready.gameObject.SetActive(true);
            currentProgress = 0f;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        float progressPercentage = currentProgress / totalTimeToMakeSalad;
        progressSlider.value = progressPercentage;
        Debug.Log(progressPercentage);
    }
}
