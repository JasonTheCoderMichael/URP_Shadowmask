using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ScreenSpaceShadowSwitch : MonoBehaviour
{
    public static string SupportSoftShadow = "";

    private bool m_screenSpaceShadow;

    private UniversalAdditionalCameraData m_camData;
    private GUIStyle m_labelStyle;
    void Start()
    {
        m_camData = GetComponent<UniversalAdditionalCameraData>();
        if (m_camData == null)
        {
            Debug.LogError("m_camData  == null");
            enabled = false;
            return;
        }

        //ShaderVariantCollection svc = Resources.Load<ShaderVariantCollection>("TestSVC");
        //if (svc == null)
        //{
        //    enabled = false;
        //    return;
        //}

        //svc.WarmUp();


        //Shader.WarmupAllShaders();

        m_labelStyle = new GUIStyle();
        m_labelStyle.fontSize = 22;
        m_labelStyle.normal.textColor = Color.black;
    }

    // Update is called once per frame
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 200, 100), "Switch Shadow"))
        {
            m_camData.useTraditionalShadow = !m_camData.useTraditionalShadow;
        }

        GUI.Label(new Rect(0, 200, 500, 100), "Current Shadow Type : " + (m_camData.useTraditionalShadow ? "Traditional Shadow" : "Screen Space Shadow"), m_labelStyle);

        GUI.Label(new Rect(0, 300, 500, 200), "graphicsDeviceType = " + SystemInfo.graphicsDeviceType +
                                              " , renderPipeline.name = " + QualitySettings.renderPipeline.name, 
            m_labelStyle);
    }
}