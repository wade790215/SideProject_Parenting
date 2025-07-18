using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Parenting.Scripts
{
    public class SucpabaseManager : MonoBehaviour
    {
        public static SucpabaseManager Instance { get; private set; }

        private string supabaseUrl = "https://qswfyxcbobfepytrofes.supabase.co/rest/v1/SideProject_Parenting";

        private string supabaseKey =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InFzd2Z5eGNib2JmZXB5dHJvZmVzIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDY4Mjc0NTAsImV4cCI6MjA2MjQwMzQ1MH0.o5lNzVAhiNftA5SdA-WLUwOvTYarBPhhnXtPyAcgevw";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void InsertPlayerData(FeedingData data)
        {
            string wrappedJson = "{\"feedData\":" + JsonUtility.ToJson(data) + "}";
            StartCoroutine(PostData(wrappedJson));
        }

        public void FetchPlayerData()
        {
            StartCoroutine(GetPlayerData());
        }

        private IEnumerator GetPlayerData()
        {
            string url = supabaseUrl;

            UnityWebRequest request = UnityWebRequest.Get(url);
            request.SetRequestHeader("apikey", supabaseKey);
            request.SetRequestHeader("Authorization", "Bearer " + supabaseKey);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Data received: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error fetching data: " + request.error);
            }
        }

        private IEnumerator PostData(string jsonData)
        {
            string url = supabaseUrl;

            UnityWebRequest request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer "+supabaseKey);
            request.SetRequestHeader("apikey", supabaseKey);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Data inserted successfully");
            }
            else
            {
                Debug.LogError("Error inserting data: " + request.error);
            }
        }

        [System.Serializable]
        public class FeedingData
        {
            public string name;
            public int feedingAmount;

            public FeedingData(string name, int feedingAmount)
            {
                this.name = name;
                this.feedingAmount = feedingAmount;
            }
        }
    }
}