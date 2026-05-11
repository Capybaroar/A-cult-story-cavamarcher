using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject MenuObject;
    private bool isActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            MenuObject.SetActive(true);
            //Cursor.visible = true; // Show the cursor
            //Cursor.lockState = CursorLockMode.Confined; // Unlock the cursor
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            MenuObject.SetActive(false);
            //Cursor.visible = false; // Hide the cursor  
            //Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
            Time.timeScale = 1f; // Resume the game
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame(); // Toggle the menu state when Escape is pressed
        }
    }

    public void ResumeGame()
    {
        isActive = !isActive; // Toggle the menu state
    }
}
