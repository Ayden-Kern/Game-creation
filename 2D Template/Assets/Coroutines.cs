using UnityEngine;
using System.Collections;
using System.Threading;

public class Coroutines : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Test());
    }

    IEnumerator Test()
    {
        while (true)
        {
            Debug.Log("Hello, ");
            yield return new WaitForSeconds(1);
            Debug.Log("World");
        }
    }
}
