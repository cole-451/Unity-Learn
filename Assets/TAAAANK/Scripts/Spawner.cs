using UnityEngine;
using UnityEngine.InputSystem;
public class Spawner : MonoBehaviour
{

    [SerializeField] float spawnTime = 10.0f;
    // cant see from outside, but is exposed to the editor
    [SerializeField] GameObject spawnObject;

    private void Awake()
    {
        print("awake");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= 1;
        if (Keyboard.current.spaceKey.isPressed)
        {
            Vector3 position = transform.position;
            position.x = Random.Range(-5.0f, 5.0f);
            position.y = Random.Range(-5.0f, 5.0f);
        var go = Instantiate(spawnObject, transform.position, transform.rotation);
            Destroy(go, 4);

        }
        
        
    }
}
