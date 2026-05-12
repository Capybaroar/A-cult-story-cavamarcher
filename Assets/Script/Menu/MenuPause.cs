using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject MenuObject;
    private bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame(); // Toggle the menu state when Escape is pressed
        }
    }

    public void ResumeGame()
    {
        isActive = !isActive; // Toggle the menu state
        MenuObject.SetActive(isActive);
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;

        }
    }
}
