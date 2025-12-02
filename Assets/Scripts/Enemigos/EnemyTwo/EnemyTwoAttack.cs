using UnityEngine;

/*Contenido
Hacer uso del script para hacer explotar al enenigo al colisionar con el player
*/

public class EnemyTwoAttack : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("Player")) //Comparar colisión para realizar la detonación del enemigo y causar daño
        {            
            Destroy(gameObject);
            playerController.PlayerLife(15);            
        }
    }
}
