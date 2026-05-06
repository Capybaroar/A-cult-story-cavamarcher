using UnityEngine;
using UnityEngine.SceneManagement;

public class PVManager : MonoBehaviour
{
    public int heart = 3;
    public int maxHeart = 3; // valeur de référence pour réinitialiser les coeurs
    public int life = 3;
    public bool touch = false;
    public int sceneToLoad;
    public int sceneToRecharge;

    public static PVManager Instance; // singleton pour persister les données

    void Awake()
    {
        // singleton + persist across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Endcondition();
        Touch();

    }

    public void Touch()
    {
        if (touch == true)
        {
            heart -= 1;
            touch = false;
        }
    }

    public void Endcondition()
    {
        if (heart <= 0)
        {
            life -= 1;
            if (life <= 0)
            {
                // Game over : charger la scène de fin et détruire l'instance si on veut repartir propre
                SceneManager.LoadScene(sceneToLoad);
                Destroy(gameObject);
            }
            else
            {
                // Réinitialiser les coeurs puis recharger la scène de recharge
                heart = maxHeart;
                SceneManager.LoadScene(sceneToRecharge);
            }
        }

    }

}
