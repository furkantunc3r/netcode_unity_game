using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Threading;

public class BuildAndRun : EditorWindow
{
    private string serverCount;
    private string clientCount;
    private readonly string path = "D:\\Unity\\Projects\\Builds\\MultiplayerGame\\MultiplayerGame_Data\\StreamingAssets\\CommandLine.txt";

    [MenuItem("Build/Run Custom")]
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

        if (GUILayout.Button("Build and Run"))
        {
            BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "D:/Unity/Projects/Builds/MultiplayerGame/MultiplayerGame.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
            startServer();
            Thread.Sleep(2000);
            startClient();
            this.Close();
        }
        else if (GUILayout.Button("Only Build"))
        {
            BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, "D:/Unity/Projects/Builds/MultiplayerGame/MultiplayerGame.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
            this.Close();
        }
        else if (GUILayout.Button("Only Run"))
        {
            startServer();
            Thread.Sleep(2000);
            startClient();
            this.Close();
        }
        else if (GUILayout.Button("Cancel"))
        {
            this.Close();
        }
    }

    void startServer()
    {
        var lines = File.ReadAllLines(path);
        lines[0] = "-StartAs 0";
        File.WriteAllLines(path, lines);

        for (int x = Int32.Parse(serverCount); x > 0; x--)
            System.Diagnostics.Process.Start("D:/Unity/Projects/Builds/MultiplayerGame/MultiplayerGame.exe");
    }

    void startClient()
    {
        var lines = File.ReadAllLines(path);
        lines[0] = "-StartAs 1";
        File.WriteAllLines(path, lines);

        for (int x = Int32.Parse(clientCount); x > 0; x--)
            System.Diagnostics.Process.Start("D:/Unity/Projects/Builds/MultiplayerGame/MultiplayerGame.exe");
    }
}