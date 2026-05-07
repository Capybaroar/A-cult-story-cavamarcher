using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{


    public int sceneToLoad; // id de la scène à charger

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad); // Charge la scène spécifiée
    }

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
