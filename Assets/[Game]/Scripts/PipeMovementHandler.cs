using UnityEngine;

public class PipeMovementHandler : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float leftEdgeOfScreen;

    void Start()
    {
        leftEdgeOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        DestroyPipes();
    }

    private void DestroyPipes()
    {
        if (transform.position.x < leftEdgeOfScreen)
        {
            Destroy(gameObject);
        }
    }
}
