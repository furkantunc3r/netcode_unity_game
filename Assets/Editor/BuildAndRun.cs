using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildAndRun : EditorWindow
{
    private string serverCount;
    private string clientCount;
    private string path = "D:\\Unity\\Projects\\MultiplayerGame\\StartGame.bat";

    [MenuItem("Build/Run Custom Batch")]
    public static void Play()
    {
        BuildAndRun window = ScriptableObject.CreateInstance<BuildAndRun>();
        window.position = new Rect(Screen.width / 10, Screen.height / 10, 200, 150);
        window.ShowPopup();
    }

    void OnGUI()
    {
        serverCount = EditorGUILayout.TextField("Server Count", serverCount);
        clientCount = EditorGUILayout.TextField("Client Count", clientCount);

        GUILayout.Space(20);

        if (GUILayout.Button("Build and Run!"))
        {
            BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "D:/Unity/Projects/Builds/MultiplayerGame/MultiplayerGame.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
            System.Diagnostics.Process.Start("CMD.exe", $"/C {path} {serverCount} {clientCount}");
            this.Close();
        }
        else if (GUILayout.Button("Only Build!"))
        {
            BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "D:/Unity/Projects/Builds/MultiplayerGame/MultiplayerGame.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
            this.Close();
        }
        else if (GUILayout.Button("Only Run!"))
        {
            System.Diagnostics.Process.Start("CMD.exe", $"/C {path} {serverCount} {clientCount}");
            this.Close();
        }
        else if (GUILayout.Button("Cancel!"))
        {
            this.Close();
        }
    }
}