using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberInstantiate : MonoBehaviour
{
    public float timeTakenToDisapear;
    public float timeTakenToInstantiate;

    float xValue = 7.9f, topYValue = 1.8f, bottomYValue = 1.8f;

    public GameObject[] number;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomNumbers());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator RandomNumbers()
    {
        yield return new WaitForSeconds(timeTakenToInstantiate);

        //top 
        var topXposition = Random.Range(-xValue, xValue);
        var topYposition = Random.Range(topYValue, 4);
        var topPosition = new Vector2(topXposition, topYposition);

        //bottom
        var bottomXposition = Random.Range(-xValue, xValue);
        var bottomYposition = Random.Range(-4, bottomYValue);
        var bottomPosition = new Vector2(bottomXposition, bottomYposition);

        //use when the numbers or objects are  many - 0-9
        int randomnumbers = Random.Range(0, number.Length);

        GameObject gameObject = Instantiate(number[randomnumbers], topPosition, Quaternion.identity);

        StartCoroutine(RandomNumbers());

        yield return new WaitForSeconds(timeTakenToDisapear);
        Destroy(gameObject);
    }
}
