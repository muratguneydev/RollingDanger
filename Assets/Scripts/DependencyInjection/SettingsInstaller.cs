using RollingDanger.RollingPlayer;
using Scripts.Camera;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
	public RollingPlayerSettings RollingPlayerSettings;
	public CameraSettings CameraSettings;

    public override void InstallBindings()
    {
		Container.BindInstance(RollingPlayerSettings);
		Container.BindInstance(CameraSettings);
    }
}