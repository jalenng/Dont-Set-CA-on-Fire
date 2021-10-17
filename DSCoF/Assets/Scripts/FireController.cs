using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireController : MonoBehaviour
{
    public Image CA;
    public GameObject[] fires;
    private Collider2D CAC;
    private HashSet<int> used;
    void Start()
    {
        CAC = CA.GetComponent<Collider2D>();
        used = new HashSet<int>();
    }

    public void CreateFire()
    {
        var tmp = Random.Range(0, fires.Length);
        while (used.Contains(tmp)) tmp = Random.Range(0, fires.Length);
        used.Add(tmp);
        // Debug.Log(tmp);
        var rt = CA.GetComponent<RectTransform>();
        // Debug.Log(rt);
        var fire = fires[tmp];
        int i=0, j=0;
        while (true) {
        // for (int k = 0; k < 100; k++) {
            i = Random.Range(0,(int)rt.sizeDelta.x);
            j = Random.Range(0,(int)rt.sizeDelta.y);
            Collider2D[] hits = Physics2D.OverlapCircleAll(new Vector2(i,j), 0);
            // Debug.Log(hits.Length > 0);
            if (hits.Length > 0) {
                // Debug.Log(hits[0]);
                break;
            }
        }
        fire.transform.SetPositionAndRotation(new Vector3(i,j,0), fire.transform.rotation);
    }
}
