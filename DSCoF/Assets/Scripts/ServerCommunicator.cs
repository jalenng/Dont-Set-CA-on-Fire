using System.Collections;
using System.Collections.Generic;
using System.Text;
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

    // Used for testing 
    private void Start()
    {
        Debug.Log("Testing Get...");
        int[] ids = {1, 2, 3, 4, 5};
        StartCoroutine(GetResponse(ids));
        
        Debug.Log("Testing Post...");
        StartCoroutine(PostResponse(1, 'A'));
    }
 
    IEnumerator PostResponse(int id, char choice) {
        // Create post data
        string bodyJsonString = string.Format(
            "{{\"id\": \"{0}\", \"choice\", \"{1}\"}}", 
            id.ToString(), 
            choice.ToString().ToUpper());

        // Create and send request
        UnityWebRequest request = new UnityWebRequest(url, "POST");

        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

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
        UnityWebRequest request = new UnityWebRequest(url + query, "POST");
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
