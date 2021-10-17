using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ServerCommunicator : MonoBehaviour
{
    [SerializeField] string url = "";
    private readonly object serverLock = new object();
    private int[] DATA;

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

    public bool Post(int id, char choice) {
        lock(serverLock) {
            var tmp = StartCoroutine(PostResponse(id, choice));
        }
        return true;
    }

    public int[] Get(int[] ids) {
        lock(serverLock) {
            StartCoroutine(GetResponse(ids));
        }
        return DATA;
    }

    public IEnumerator PostResponse(int id, char choice) {

        // Create and send request
        UnityWebRequest request = new UnityWebRequest(url+string.Format("?id={0}&choice={1}", id.ToString(), choice.ToString().ToUpper()), "POST");
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
 
        // Check for error
        if (request.result != UnityWebRequest.Result.Success) {
            Debug.Log(request.error);
        } else {
            // Show results as text
            Debug.Log(request.downloadHandler.text);
        }
    }

    public IEnumerator GetResponse(int[] ids) {
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
            string res = request.downloadHandler.text;
            var id = res.Split('"')[1];
            int[] choice = new int[]{0,0,0,0};
            var d = res.Split('[')[1].Split(']')[0].Split(',');
            for (int i = 0; i < d.Length; i++) {
                choice[i] = int.Parse(d[i]);
            }
            DATA = choice;
        }
    }
}