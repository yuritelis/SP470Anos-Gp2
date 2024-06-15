using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverPassaro : MonoBehaviour
{
    public Transform[] waypoints;      // Array de waypoints definidos diretamente
    public float speed = 3.0f;         // Velocidade do p�ssaro
    private int currentWaypointIndex;  // �ndice do waypoint atual

    public GameObject ovoPrefab;       // Prefab do ovo a ser lan�ado como obst�culo
    public float intervaloDeLancamento = 3.0f; // Intervalo de tempo entre lan�amentos de obst�culos
    private float tempoUltimoLancamento; // Tempo do �ltimo lan�amento de obst�culo

    void Start()
    {
        currentWaypointIndex = 0; // Come�a do primeiro waypoint
        tempoUltimoLancamento = Time.time; // Inicializa o tempo do �ltimo lan�amento
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogWarning("Nenhum waypoint definido no script para o p�ssaro mover-se.");
            return;
        }

        // Mover o p�ssaro em dire��o ao waypoint atual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        // Verificar se � hora de lan�ar um obst�culo
        if (Time.time - tempoUltimoLancamento > intervaloDeLancamento)
        {
            LancaObstaculo();
            tempoUltimoLancamento = Time.time; // Atualiza o tempo do �ltimo lan�amento
        }

        // Verificar se o p�ssaro alcan�ou o waypoint atual
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.3f)
        {
            currentWaypointIndex++; // Avan�a para o pr�ximo waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // Reinicia a partir do primeiro waypoint ao alcan�ar o �ltimo
            }
        }
    }

    void LancaObstaculo()
    {
        if (ovoPrefab != null)
        {
            // Instancia o componente "ovo" na posi��o do p�ssaro
            GameObject ovoInstanciado = Instantiate(ovoPrefab, transform.position, Quaternion.identity);
            ovoInstanciado.name = "OvoInstanciado"; // Opcional: renomeia o objeto instanciado se necess�rio
        }
    }
}
