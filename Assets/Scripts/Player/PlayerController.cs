using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
/*Contenido
Control de movimento (tipo MOBA)
Creación de disparo y acción de disparo
Vida del player
*/
public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    [SerializeField] private float Speed;
    [SerializeField] private float lifePlayer = 50f;
    private bool move = false; //Simula un swichs de cambio para no hacer un movimiento constante al dar click
    private Vector2 destiny;

    void Update()
    {
        //Disparo
        if (Input.GetMouseButtonDown(1))
            ShootProyectile();

        //Controles de movimiento
        if (move) //Si es TRUE hay movimiento 
            MoveToDirection(); 

        if (Input.GetMouseButton(0))
            SetDestiny();                
    }  

    public void SetDestiny() //Método para obtener las coordenadas del mouse
    {
        destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        move = true; 
    }

    public void MoveToDirection()
    {      
        Vector3 moveDirection = (destiny - (Vector2)transform.position).normalized; 
        transform.position += moveDirection * Speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, destiny) <= 0.1f)
            move = false;
    }

    public void ShootProyectile()
    {        
        Vector2 mousePosition = Input.mousePosition;                            //-> obtener posicon del mouse respecto a la resolucion de la patanlla
        Vector2 worldPositon = Camera.main.ScreenToWorldPoint(mousePosition);   // convirtiendo la posicon del mouse a la posicion en el mundo
        Vector2 shootDirection = worldPositon - (Vector2)transform.position;    //calculdo la direccion de disparo
        Vector2 normalizeShootDirection = shootDirection.normalized;            //normalizando la direccion
        GameObject bullet = Instantiate(BulletPrefab);                          //-> Crear 
        bullet.transform.position = transform.position;            //Coloca la bala en la posición del player
        bullet.transform.up = normalizeShootDirection;             //Ajusta el ángulo de la bala a la ubicación del mouse
        //print(worldPositon);                                       //Imprime la ubicación del mouse al dar click
    }

    public void PlayerLife(float damage)
    {
        lifePlayer -= damage;
        print("Tu vida actual es: " + lifePlayer);
    }

}
