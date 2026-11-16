using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceBCE.Core
{
    /// <summary>
    /// Se adjunta a un objeto vacío en cualquier escena que se cargue aditivamente.
    /// Al instanciarse, obliga a Unity a usar el Skybox y la iluminación de esta escena.
    /// </summary>
    public class SceneActivator : MonoBehaviour
    {
        private void Start()
        {
            // Toma la escena a la que pertenece este GameObject y la vuelve la Principal
            Scene activeScene = gameObject.scene;
            SceneManager.SetActiveScene(activeScene);
            
            Debug.Log($"[SceneActivator] La escena {activeScene.name} ahora es la activa. Skybox actualizado.");
        }
    }
}