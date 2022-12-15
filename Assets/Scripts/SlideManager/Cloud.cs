using UnityEngine;
using UnityEngine.UI;

public class Cloud : MonoBehaviour
{
    // This class is attached to each cloud game object
    // It will move the cloud to the left and re-position and re-scale it to the right when it goes off screen to go back to the left
    // it will have random speed, transparency, scale, and position

    private Vector2 m_SpeedRange = new Vector2(10f, 20f);
    private Vector2 m_TransparencyRange = new Vector2(0.5f, 1f);
    private Vector2 m_ScreenBoundsX = new Vector2(-960f, 960f);
    private Vector2 m_ScreenBoundsY = new Vector2(0f, 540f);
    private Vector2 m_ScaleRange = new Vector2(0.3f, 1.2f);
    private RectTransform m_RectTransform;
    private Image m_CloudImage;
    private float m_Speed;
    private Rect m_Bounds;

    public void AssignParameters(Vector2 speedRange, Vector2 transparencyRange, Vector2 screenBoundsX, Vector2 screenBoundsY, Vector2 scaleRange)
    {
        m_SpeedRange = speedRange;
        m_TransparencyRange = transparencyRange;
        m_ScreenBoundsX = screenBoundsX;
        m_ScreenBoundsY = screenBoundsY;
        m_ScaleRange = scaleRange;

        // Initialize the cloud

        // assign initial position and scale
        m_RectTransform = GetComponent<RectTransform>();
        m_RectTransform.anchoredPosition = new Vector2(
            Random.Range(m_ScreenBoundsX.x, m_ScreenBoundsX.y),
            Random.Range(m_ScreenBoundsY.x, m_ScreenBoundsY.y)
        );
        m_RectTransform.localScale = Vector3.one * Random.Range(m_ScaleRange.x, m_ScaleRange.y);

        // assign initial transparency to the cloud Image component in UI
        m_CloudImage = GetComponent<UnityEngine.UI.Image>();
        m_CloudImage.color = new Color(
            m_CloudImage.color.r,
            m_CloudImage.color.g,
            m_CloudImage.color.b,
            Random.Range(m_TransparencyRange.x, m_TransparencyRange.y)
        );

        // assign initial speed
        m_Speed = Random.Range(m_SpeedRange.x, m_SpeedRange.y);

        // store bounds of the cloud to make sure the cloud is fully visible
        m_Bounds = m_RectTransform.rect;
    }

    private void Update()
    {
        // move the cloud to the left
        m_RectTransform.anchoredPosition += Vector2.left * m_Speed * Time.deltaTime;

        // if the whole cloud is off screen to the left
        if (m_RectTransform.anchoredPosition.x - m_Bounds.xMin < m_ScreenBoundsX.x)
        {
            // re-position the cloud to the right
            m_RectTransform.anchoredPosition = new Vector2(
                m_ScreenBoundsX.y + m_Bounds.xMax,
                Random.Range(m_ScreenBoundsY.x, m_ScreenBoundsY.y)
            );

            // re-scale the cloud
            m_RectTransform.localScale = Vector3.one * Random.Range(m_ScaleRange.x, m_ScaleRange.y);

            // re-assign the transparency of the cloud
            m_CloudImage.color = new Color(
                m_CloudImage.color.r,
                m_CloudImage.color.g,
                m_CloudImage.color.b,
                Random.Range(m_TransparencyRange.x, m_TransparencyRange.y)
            );

            // re-assign the speed of the cloud
            m_Speed = Random.Range(m_SpeedRange.x, m_SpeedRange.y);

            // re-assign the bounds of the cloud
            m_Bounds = m_RectTransform.rect;
        }
    }
}