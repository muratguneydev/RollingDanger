using RollingDanger.RollingPlayer;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SettingsInstaller", menuName = "Installers/SettingsInstaller")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
	public RollingPlayerSettings RollingPlayerSettings;

    public override void InstallBindings()
    {
		Container.BindInstance(RollingPlayerSettings);
    }
}