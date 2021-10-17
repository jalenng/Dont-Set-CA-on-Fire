using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerCommunicator : MonoBehaviour
{
    [SerializeField] string url = "";

    // Singleton pattern
    private void Awake()
    {
        int serverCommunicatorCount = FindObjectsOfType<ServerCommunicator>().Length;
        if (serverCommunicatorCount > 1)
        {
            gameObject.SetActive(false);    // Important!
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
 
    IEnumerator PostResponse(int id, char choice) {
        // Create post data
        WWWForm data = new WWWForm();
        data.AddField("id", id.ToString());
        data.AddField("choice", choice.ToString().ToUpper());

        // Create and send request
        UnityWebRequest request = UnityWebRequest.Post(url, data);
        yield return request.SendWebRequest();
 
        // Check for error
        if (request.result != UnityWebRequest.Result.Success) {
            Debug.Log(request.error);
        }
        else {
            // Show results as text
            Debug.Log(request.downloadHandler.text);
        }
    }

    IEnumerator GetResponse(int[] ids) {
        // Create and send request
        string joinedIds = string.Join(",", ids);
        string query = string.Format("?id={0}", joinedIds);
        UnityWebRequest request = UnityWebRequest.Get(url + query);
        yield return request.SendWebRequest();
 
        // Check for error
        if (request.result != UnityWebRequest.Result.Success) {
            Debug.Log(request.error);
        }
        else {
            // Show results as text
            Debug.Log(request.downloadHandler.text);
        }
    }
}
