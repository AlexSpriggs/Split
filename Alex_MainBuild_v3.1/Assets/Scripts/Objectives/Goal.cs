using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    public GameObject Key;

    Player player; 

    void Awake()
    {
        player = new Player();
    }

    void OnTriggerEnter(Collider collider)
    {
        player.AddKey(Key);

        Destroy(gameObject);
    }
}
