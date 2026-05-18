using UnityEngine;

public class FireballShooter : MonoBehaviour
{
    public GameObject fireballPrefab;   // ton prefab boule de feu
    public Transform shootPoint;        // point de spawn de la boule (enfant du joueur)
    public float fireballSpeed;
    public QTEManager qtemanager;

    void Update()
    {
        // On tire uniquement si QTEFIRE est actif et qu'aucun QTE n'est en cours
        if (qtemanager.QTEFIRE == true && qtemanager.QTEIng == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        // On lit le flip du sprite pour connaitre la direction
        // localScale.x < 0 = le sprite est retourné = le perso regarde à gauche
        float direction = transform.localScale.x < 0 ? -1f : 1f;

        GameObject fireball = Instantiate(fireballPrefab, shootPoint.position, Quaternion.identity);
        Fireball fb = fireball.GetComponent<Fireball>();
        fb.Launch(direction, fireballSpeed);
    }
}
