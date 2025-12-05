using UnityEngine;

public class LifeEnemy : MonoBehaviour
{

    [SerializeField] private int lifeEnemy = 4;
     //Contador estatico para el numero de enemigos muertos
    private const int RequiredEnemyDeath = 25; //Numero requerido de enemigos muertos para activar la invocacion del jefe

    public void CountEnemyDeath()
    {
        GameManager.NumberEnemyDeath++;
        print("Numero de enemigos muertos: " + GameManager.NumberEnemyDeath);
    }

    /*public void WinCondition()
    {
        if (GameManager.NumberEnemyDeath >= RequiredEnemyDeath)
        {
            print("¡Ahora debemos acabar con el m�s fuerte!");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("trigger entro: " + collision.tag);
        if (collision.CompareTag("ShotPlayer"))
        {
            lifeEnemy--;
            //print("Enemigo 1 tiene de vida: " + lifeEnemy);
            if (lifeEnemy <= 0)
            {
          
                Destroy(gameObject);
                CountEnemyDeath();
                EnemyController.currentQuantity--;
                //WinCondition();
            }
        }
    }

    public static int NumberEnemyDeathGet()
    {
        return GameManager.NumberEnemyDeath;
    }

    public static int RequiredEnemyDeathGet()
    {
        return RequiredEnemyDeath;
    }
}