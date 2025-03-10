using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIGetData : MonoBehaviour
{
    [SerializeField] private Button btn_GetData;
    [SerializeField] private Button btn_PostData;
    [SerializeField] private TMP_InputField outputArea;

    private void Awake()
    {
        btn_GetData.onClick.AddListener(GetData);
        btn_PostData.onClick.AddListener(PostData);
    }


    private async void GetData()
    {
        outputArea.text = "Loading...";
        string url = "https://jsonplaceholder.typicode.com/todos/1";

        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                outputArea.text = await response.Content.ReadAsStringAsync();
            }
            else
            {
                outputArea.text = response.ReasonPhrase;
            }
        }
    }
    private async void PostData()
    {
        outputArea.text = "Loading...";
        string url = "https://jsonplaceholder.typicode.com/todos/1";
        var postData = new Dictionary<string, string>();
        postData["title"] = "test data";

        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.PostAsync(url, new FormUrlEncodedContent(postData));
            if (response.IsSuccessStatusCode)
            {
                outputArea.text = await response.Content.ReadAsStringAsync();
            }
            else
            {
                outputArea.text = response.ReasonPhrase;
            }
        }
    }
}
