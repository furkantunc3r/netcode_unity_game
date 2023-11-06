using UnityEngine;
using Oddworm.Framework;
using Unity.Netcode;
using System.IO;

public class CommandLineScript : MonoBehaviour
{
    void Start()
    {
        CommandLine.isEnabled = true;

        var startAs = CommandLine.GetBool("-StartAs", false);
       
        if (!startAs)
        {
            Debug.Log("test");
            NetworkManager.Singleton.StartServer();
        }
        else if (startAs)
        {
            Debug.Log("test1");
            NetworkManager.Singleton.StartClient();
        }
    }

    // On many platforms you can simply use System.IO to load a file as shown below.
    // On Android you can't use System.IO though, you need to use UnityWebRequest instead.
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    static void LoadCommandLine()
    {
        // Use commandline options passed to the application
        var text = System.Environment.CommandLine + "\n";

        // Load the commandline file content.
        // You need to adjust the path to where the file is located in your project.
        var path = System.IO.Path.Combine(Application.streamingAssetsPath, "CommandLine.txt");
        if (System.IO.File.Exists(path))
        {
            text += System.IO.File.ReadAllText(path);
        }
        else
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            Debug.LogErrorFormat("Could not find commandline file '{0}'.", path);
#endif
        }

        // Initialize the CommandLine
        Oddworm.Framework.CommandLine.Init(text);
    }

#if UNITY_EDITOR
    [UnityEditor.MenuItem("File/Open Commandline", priority = 1000)]
    static void OpenCommandLineMenuItem()
    {
        // The CommandLine.txt file location
        var path = System.IO.Path.Combine(Application.streamingAssetsPath, "CommandLine.txt");

        // If the directory does not exist, create it.
        var directory = System.IO.Path.GetDirectoryName(path);
        if (!System.IO.Directory.Exists(directory))
            System.IO.Directory.CreateDirectory(directory);

        // If the CommandLine.txt does not exist, create it.
        if (!System.IO.File.Exists(path))
        {
            System.IO.File.WriteAllText(path, "Need help? See https://github.com/pschraut/UnityCommandLine", System.Text.Encoding.UTF8);
            UnityEditor.AssetDatabase.Refresh();
        }

        // Open the CommandLine.txt file
        UnityEditor.EditorUtility.OpenWithDefaultApp(path);
    }
#endif
}
