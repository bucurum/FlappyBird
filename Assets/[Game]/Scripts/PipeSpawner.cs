using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float spawnRate = 1f;

    [SerializeField] float minHeight = -1f;
    [SerializeField] float maxHeight = 1f;

    private void OnEnable() 
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);    
    }

    void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); 
    }
}
