using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Doro;   // Referencia al Player
    public float speed = 3f;   // Velocidad del enemigo

    void Update()
    {
        // 1. Calcular dirección hacia el jugador (Vector2)
        Vector2 direction = (Vector2)Doro.position - (Vector2)transform.position;

        // 2. Normalizar la dirección
        direction = direction.normalized;

        // 3. Mover al enemigo usando solo Vector2
        transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
    }
}