using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    // This class is attached to the CloudManager game object in the scene
    // It has a list of clouds and will set their position randomly within a certain range in top of the screen
    // It will also set their scale randomly within a certain range
    // Then it will attach a Cloud script to each cloud game object
    // The Cloud script will move the cloud to the left and re-position and re-scale it to the right when it goes off screen to go back to the left

    [SerializeField] GameObject m_CloudPrefab;
    [SerializeField] int m_NumberOfClouds = 10;
    [SerializeField] Vector2 m_SpeedRange = new Vector2(10f, 20f);
    [SerializeField] Vector2 m_TransparencyRange = new Vector2(0.5f, 1f);
    [SerializeField] Vector2 m_ScreenBoundsX = new Vector2(-960f, 960f);
    [SerializeField] Vector2 m_ScreenBoundsY = new Vector2(0f, 540f);
    [SerializeField] Vector2 m_ScaleRange = new Vector2(0.3f, 1.2f);

    private List<GameObject> clouds;

    private void Awake()
    {
        clouds = new List<GameObject>();
        for (int i = 0; i < m_NumberOfClouds; i++)
        {
            var cloud = Instantiate(m_CloudPrefab, transform);
            clouds.Add(cloud);
            cloud.transform.SetParent(transform);
            // add Cloud component to each cloud game object
            var cloudScript = cloud.AddComponent<Cloud>();
            cloudScript.AssignParameters(m_SpeedRange, m_TransparencyRange, m_ScreenBoundsX, m_ScreenBoundsY, m_ScaleRange);
        }
    }

}
