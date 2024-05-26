using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class WeatherManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}

	public float cloudValue {get; private set;}

	private NetworkService _network;

	public void Startup(NetworkService service) {
		Debug.Log("Weather manager starting...");

		_network = service;
		//StartCoroutine(_network.GetWeatherXML(OnXMLDataLoaded));
		StartCoroutine(_network.GetWeatherJSON(OnJSONDataLoaded));

		status = ManagerStatus.Initializing;
	}

	public void OnJSONDataLoaded(string data) {
		JObject root = JObject.Parse(data);
		Debug.Log(data);

        JToken clouds = root["clouds"];
		cloudValue = (long)clouds["all"] / 100f;
		Debug.Log("Value: " + cloudValue);
		
		Messenger.Broadcast(GameEvent.WEATHER_UPDATED);
		
		status = ManagerStatus.Started;
	}
}
