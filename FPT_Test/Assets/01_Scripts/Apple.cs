using UnityEngine;

public class Apple
{
    private int health;

    public Apple(int health)
    {
        this.health = health;
    }

    public void TakeABite()
    {

        health = health - 50;
        Debug.Log("take a bite");
        if (health <= 0)
        {
            Debug.Log("finished apple");
        }
    }
}
