using RollingDanger.RollingPlayer;
using Scripts.Camera;
using Zenject;

public class MainSceneDependencyRegistrar : MonoInstaller
{
	[Inject] RollingPlayerSettings _rollingPlayerSettings;
	[Inject] CameraSettings _cameraSettings;

    public override void InstallBindings()
    {
		Container.Install<CoreInstaller>();
		CameraInstaller.Install(Container, _cameraSettings);
		RollingPlayerInstaller.Install(Container, _rollingPlayerSettings);
    }
}
