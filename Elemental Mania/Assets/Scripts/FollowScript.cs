using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    private float minSizeY = 5f;
    public Camera m_OrthographicCamera;

    void Start()
    {
    }

    void LateUpdate()
    {
        SetCameraPos();
        SetCameraSize();
    }

    void SetCameraPos()
    {
        Vector3 middle = (player1.transform.position + player2.transform.position) * 0.5f;
        transform.position = new Vector3(
            middle.x,
            middle.y,
            transform.position.z
        );
    }

    void SetCameraSize()
    {
        m_OrthographicCamera.orthographic = true;
        float minSizeX = minSizeY * Screen.width / Screen.height;
        float width = (Mathf.Abs(player1.position.x - player2.position.x) * 0.5f) + 2f;
        float height = Mathf.Abs(player1.position.y - player2.position.y) * 0.5f;
        float camSizeX = Mathf.Max(width, minSizeX);
        m_OrthographicCamera.orthographicSize = Mathf.Max(height,
            camSizeX * Screen.height / Screen.width, minSizeY);
    }
}