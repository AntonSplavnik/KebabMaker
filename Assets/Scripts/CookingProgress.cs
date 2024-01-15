using UnityEngine.UI;
using UnityEngine;

public class MakingProgress : MonoBehaviour
{
    [SerializeField] Slider progressSlider;
    [SerializeField] Transform playerTransform;
    [SerializeField] string food;
    [SerializeField] GameObject test;
    [SerializeField] Text nameText;
    [SerializeField] GameObject ready;
    [SerializeField] AudioSource doneSound;
    [SerializeField] Vector2 offset;
    [SerializeField] float totalTimeToMakeSalad = 3f;
    private bool _isCollision = false;
    private float _currentProgress = 0f;

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
    void Update()
    {
        switch (_isCollision)
        {
            case true when _currentProgress < totalTimeToMakeSalad:
                _currentProgress = Mathf.Clamp(_currentProgress + Time.deltaTime, 0, totalTimeToMakeSalad); 
                UpdateUI();
                progressSlider.transform.position = new Vector2(playerTransform.position.x, playerTransform.position.y) + offset;
                break;
            case true:
                doneSound.Play();
                _currentProgress = totalTimeToMakeSalad;
                _isCollision = false;
                test.gameObject.SetActive(false);
                //StartCoroutine(FadeOut());
                ready.gameObject.SetActive(true);
                _currentProgress = 0f;
                UpdateUI();
                break;
        }
    }
    void UpdateUI()
    {
        float progressPercentage = _currentProgress / totalTimeToMakeSalad;
        progressSlider.value = progressPercentage;
        Debug.Log(progressPercentage);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        _isCollision = true;
        test.gameObject.SetActive(true);
        nameText.text = food;
        UpdateUI();
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        _isCollision = false;
    }
}

