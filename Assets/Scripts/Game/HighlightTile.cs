using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTile : MonoBehaviour
{
    [SerializeField] private GameObject m_renderable;
    
    private Color m_baseColor;
    private float m_intensity = 3.0f;

    void Awake()
    {
        m_baseColor = m_renderable.GetComponent<MeshRenderer>().material.color;
    }

    // Eventos da Unity
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            m_renderable.GetComponent<MeshRenderer>().material.color = m_baseColor * m_intensity;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            m_renderable.GetComponent<MeshRenderer>().material.color = m_baseColor;
    }
}
