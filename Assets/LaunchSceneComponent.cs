 using UnityEngine;
 using UnityEngine.SceneManagement;
 
 public class LaunchSceneComponent : MonoBehaviour
 {
    [SerializeField]
    public string scene;

    void Start()
    {
    }

    public void LaunchScene() {
        SceneManager.LoadScene(scene);
    }
 }