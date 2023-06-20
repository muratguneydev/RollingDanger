using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
/// <summary>
/// By: Nathan MacAdam
/// https://nathanmacadam.dev/2020/04/21/unit-testing-monobehaviours/
/// Extra constructor with providing the dependency injection provided instance added by Murat Guney.
///
/// Calls Unity message methods through reflection.
/// Note that MonoReflector cannot access private/protected methods implemented in parent classes.
/// </summary>
/// <remarks>
/// For use in unit testing.  Since Unity creates its message implementations for the user, we can't use traditional methods
/// for testing whether the code implemented in a message is functional without abstracting its implementation elsewhere (Humble Object) or making those messages public.
/// Sometimes we need to call MonoBehaviour methods though, and a pattern like Humble Object wouldn't have access to the MonoBehaviour (in that case, it wouldn't make it more testable and defeats the purpose of abstracting it!)
/// If you need to specifically test an component's entire runtime functionality use a play mode test.
/// </remarks>
/// <example>
/// var reflectedFoo = new MonoReflector<FooComponent>();
/// reflectedFoo.Start();
/// reflectedFoo.Update();
/// </example>
/// <typeparam name="T">MonoBehaviour to call methods of</typeparam>

public class MonoReflector<T> where T : MonoBehaviour
{
    private GameObject _gameObject;
    private T _instance;

    private Dictionary<string, MethodInfo> _methods = new Dictionary<string, MethodInfo>();
    private BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy;

    public MonoReflector()
    {
        _gameObject = new GameObject();
        _instance = _gameObject.AddComponent<T>();
    }

	public MonoReflector(T monobehaviour)
	{
		_instance = monobehaviour;
		GC.SuppressFinalize(this);
	}

    ~MonoReflector()
    {
		// if (_gameObject == null)
		// 	return;
        UnityEngine.Object.Destroy(_gameObject);
    }

	public T MonoBehaviour => _instance;

    /// <summary>
    /// Attempts to call the method on _instance with the given method name and parameters, caching the
    /// reflection lookup if found, and throwing an error if the method does not exist or is not accessible.
    /// </summary>
    /// <param name="methodName">The name of the method to call</param>
    /// <param name="parameters">Optional parameters</param>
    private void TryMethod(string methodName, params object[] parameters)
    {
        if (_methods.ContainsKey(methodName))
        {
            _methods[methodName].Invoke(_instance, parameters);
        }
        else
        {
            MethodInfo info = typeof(T).GetMethod(methodName, flags);

            if (info == null)
            {
                throw new Exception($"Component of type {typeof(T).Name} does not have an accessible {methodName} method");
            }
            else
            {
                _methods.Add(methodName, info);
                info.Invoke(_instance, parameters);
            }
        }
    }

    public void Awake() { TryMethod("Awake"); }
    public void FixedUpdate() { TryMethod("FixedUpdate"); }
    public void LateUpdate() { TryMethod("LateUpdate"); }
    public void OnAnimatorIK(int layerIndex) { TryMethod("OnAnimatorIK", layerIndex); }
    public void OnAnimatorMove() { TryMethod("OnAnimatorMove"); }
    public void OnApplicationFocus(bool hasFocus) { TryMethod("OnApplicationFocus", hasFocus); }
    public void OnApplicationPause(bool pauseStatus) { TryMethod("OnApplicationPause", pauseStatus); }
    public void OnApplicationQuit() { TryMethod("OnApplicationQuit"); }
    public void OnAudioFilterRead(float[] data, int channels) { TryMethod("OnAudioFilterRead", data, channels); }
    public void OnBecameInvisible() { TryMethod("OnBecameInvisible"); }
    public void OnBecameVisible() { TryMethod("OnBecameVisible"); }
    public void OnCollisionEnter(Collision other) { TryMethod("OnCollisionEnter", other); }
    public void OnCollisionEnter2D(Collision2D other) { TryMethod("OnCollisionEnter2D", other); }
    public void OnCollisionExit(Collision other) { TryMethod("OnCollisionExit", other); }
    public void OnCollisionExit2D(Collision2D other) { TryMethod("OnCollisionExit2D", other); }
    public void OnCollisionStay(Collision other) { TryMethod("OnCollisionStay", other); }
    public void OnCollisionStay2D(Collision2D other) { TryMethod("OnCollisionStay2D", other); }
    public void OnConnectedToServer() { TryMethod("OnConnectedToServer"); }
    public void OnControllerColliderHit(ControllerColliderHit hit) { TryMethod("OnControllerColliderHit", hit); }
    public void OnDestroy() { TryMethod("OnDestroy"); }
    public void OnDisable() { TryMethod("OnDisable"); }
    public void OnDrawGizmos() { TryMethod("OnDrawGizmos"); }
    public void OnDrawGizmosSelected() { TryMethod("OnDrawGizmosSelected"); }
    public void OnEnable() { TryMethod("OnEnable"); }
    public void OnGUI() { TryMethod("OnGUI"); }
    public void OnJointBreak(float breakForce) { TryMethod("OnJointBreak", breakForce); }
    public void OnJointBreak2D(Joint2D brokenJoint) { TryMethod("OnJointBreak2D", brokenJoint); }
    public void OnMouseDown() { TryMethod("OnMouseDown"); }
    public void OnMouseDrag() { TryMethod("OnMouseDrag"); }
    public void OnMouseEnter() { TryMethod("OnMouseEnter"); }
    public void OnMouseExit() { TryMethod("OnMouseExit"); }
    public void OnMouseOver() { TryMethod("OnMouseOver"); }
    public void OnMouseUp() { TryMethod("OnMouseUp"); }
    public void OnMouseUpAsButton() { TryMethod("OnMouseUpAsButton"); }
    public void OnParticleCollision(GameObject other) { TryMethod("OnParticleCollision", other); }
    public void OnParticleSystemStopped() { TryMethod("OnParticleSystemStopped"); }
    public void OnParticleTrigger() { TryMethod("OnParticleTrigger"); }
    public void OnParticleUpdateJobScheduled() { TryMethod("OnParticleUpdateJobScheduled"); }
    public void OnPostRender() { TryMethod("OnPostRender"); }
    public void OnPreCull() { TryMethod("OnPreCull"); }
    public void OnPreRender() { TryMethod("OnPreRender"); }
    public void OnRenderImage(RenderTexture src, RenderTexture dest) { TryMethod("OnRenderImage", src, dest); }
    public void OnRenderObject() { TryMethod("OnRenderObject"); }
    public void OnServerInitialized() { TryMethod("OnServerInitialized"); }
    public void OnTransformChildrenChanged() { TryMethod("OnTransformChildrenChanged"); }
    public void OnTransformParentChanged() { TryMethod("OnTransformParentChanged"); }
    public void OnTriggerEnter(Collider other) { TryMethod("OnTriggerEnter", other); }
    public void OnTriggerEnter2D(Collider2D other) { TryMethod("OnTriggerEnter2D", other); }
    public void OnTriggerExit(Collider other) { TryMethod("OnTriggerExit", other); }
    public void OnTriggerExit2D(Collider2D other) { TryMethod("OnTriggerExit2D", other); }
    public void OnTriggerStay(Collider other) { TryMethod("OnTriggerStay", other); }
    public void OnTriggerStay2D(Collider2D other) { TryMethod("OnTriggerStay2D", other); }
    public void OnValidate() { TryMethod("OnValidate"); }
    public void OnWillRenderObject() { TryMethod("OnWillRenderObject"); }
    public void Reset() { TryMethod("Reset"); }
    public void Start() { TryMethod("Start"); }
    public void Update() { TryMethod("Update"); }
}