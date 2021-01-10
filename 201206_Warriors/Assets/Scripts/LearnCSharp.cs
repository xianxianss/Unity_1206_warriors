using UnityEngine;

public class LearnCSharp : MonoBehaviour
{

    public int a = 10;
    public int b = 3;

    void Start()
    {
        print(a > b);
        print(a < b);
        print(a == b);
        print(a != b);

        print(true && true);
        print(true && false);
        print(false && true);
        print(false && false);

        print(true|| true);
        print(true|| false);
        print(false|| true);
        print(false|| false);
    }

   
}
