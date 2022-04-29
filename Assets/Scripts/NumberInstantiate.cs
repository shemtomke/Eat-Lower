using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberInstantiate : MonoBehaviour
{
    public float timeTakenToDisapear;
    public float timeTakenToInstantiate;
    public float minValueX, maxValueX, minValueY, maxValueY;
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

        var xposition = Random.Range(minValueX, maxValueX);
        var yposition = Random.Range(minValueY, maxValueY);
        var position = new Vector2(xposition, yposition);

        //use when the numbers or objects are  many - 0-9
        int randomnumbers = Random.Range(0, number.Length);
        GameObject gameObject = Instantiate(number[randomnumbers], position, Quaternion.identity);

        StartCoroutine(RandomNumbers());

        yield return new WaitForSeconds(timeTakenToDisapear);
        Destroy(gameObject);

        
    }
}
