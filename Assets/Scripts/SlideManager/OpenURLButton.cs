using System;
using UnityEngine;
using UnityEngine.UI;

public class OpenURLButton : MonoBehaviour
{
    [SerializeField] string URL;
    Button m_Button;
    private void OnEnable()
    {
        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(OpenURL);
    }

    private void OnDisable()
    {
        m_Button.onClick.RemoveListener(OpenURL);
    }

    private void OpenURL()
    {
        Application.OpenURL(URL);
    }
}
