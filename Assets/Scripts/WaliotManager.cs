using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Helpers;
using Assets.Scripts.Model;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.Networking;

[AddComponentMenu("Waliot/Manager")]
public class WaliotManager : MonoBehaviour
{
    public string ApiKey = "KOKaJXALHUO7l9WDQgOrwk1bPIfeM9xbCpO74xdJseGAzGR9MnSKg7IpGtAeUsHe";

    public AbstractMap AbstractMap;
    public GameObject VehiclePrefab;

    private List<Vehicle> _vehicles = new List<Vehicle>();
    private List<GameObject> _markers = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(LoadVehicles());
    }

    private void Update()
    {
        /*
        int count = _markers.Count;
        for (int i = 0; i < count; i++)
        {
            var marker = _markers[i];
            var vehicle = _vehicles[i];
            marker.transform.localPosition = AbstractMap.GeoToWorldPosition(new Vector2d(vehicle.Latitude, vehicle.Longitude), true);
            marker.transform.localScale = new Vector3(1f, 1f, 1f);
            Debug.Log(vehicle);
        }
        */
    }

    private IEnumerator LoadVehicles()
    {
        using (var webRequest = UnityWebRequest.Get("https://api.waliot.com/api/states?org-id=1062&tree=true"))
        {
            webRequest.SetRequestHeader("Authorization", "ApiKey " + ApiKey);

            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:
                    var json = webRequest.downloadHandler.text;
                    _vehicles = JsonUtility.FromJson<JsonUtil.Wrapper<Vehicle>>("{\"Items\":" + json + "}").Items.ToList();
                    Debug.Log(json);
                    Debug.Log(JsonUtility.FromJson<JsonUtil.Wrapper<Vehicle>>("{\"Items\":" + json + "}").Items[0]);
                    break;
                
                default:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
            }
        }

        /*
        _markers = new List<GameObject>();
        foreach (var vehicle in _vehicles)
        {
            var instance = Instantiate(VehiclePrefab, AbstractMap.transform);
            instance.transform.localPosition = AbstractMap.GeoToWorldPosition(new Vector2d(vehicle.Latitude, vehicle.Longitude), false);
            instance.transform.localScale = new Vector3(1f, 1f, 1f);
            _markers.Add(instance);
        }
        */
    }
}