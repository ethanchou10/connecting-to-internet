using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class NetworkService {
	private const string jsonApi = "https://api.openweathermap.org/data/2.5/weather?q=Sydney,au&APPID=e87991825328b10ee03463453976a4bb";

	private IEnumerator CallAPI(string url, Action<string> callback) {
		using (UnityWebRequest request = UnityWebRequest.Get(url)) {

			yield return request.SendWebRequest();

			if (request.result == UnityWebRequest.Result.ConnectionError) {
				Debug.LogError("network problem: " + request.error);
			} else if (request.result == UnityWebRequest.Result.ProtocolError) {
				Debug.LogError("response error: " + request.responseCode);
			} else {
				callback(request.downloadHandler.text);
			}
		}
	}

	public IEnumerator GetWeatherJSON(Action<string> callback) {
		return CallAPI(jsonApi, callback);
	}
}
