using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 20f;
    public int CountCoins = 0;
    Vector2 WorldPos;
    Queue<Vector2> PointsToGo = new Queue<Vector2>();

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        CountCoins = 0;
        print(CountCoins);
    }

    
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Input.mousePosition;
            WorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            PointsToGo.Enqueue(WorldPos);
            print(PointsToGo.Count);
            print(PointsToGo.Peek());
        }
        if (PointsToGo.Count > 0) {
            Vector2 VecToGo = PointsToGo.Peek();
            rb.MovePosition(Vector2.MoveTowards(transform.position, VecToGo, speed * Time.deltaTime));
            if (Vector2.Distance(transform.position, VecToGo) < 0.01) {
                PointsToGo.Dequeue();
                print(PointsToGo.Count);
            }
            
        } 
        
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Coin")) {
            CountCoins += 1;
            print($"{CountCoins} of 4");
            if (CountCoins == 4) {
                Camera.main.GetComponent<UIManager>().Win();
            }
            while (CountCoins > 4) {
                CountCoins -= 4;
            }
        }

        if (collision.gameObject.CompareTag("Cactus")) {
            print($"You Died. You've collected {CountCoins} of 4");
            Camera.main.GetComponent<UIManager>().Lose();
        }
    }
}
