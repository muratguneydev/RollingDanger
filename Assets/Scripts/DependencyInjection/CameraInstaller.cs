using RollingDanger.Events;
using Scripts.Camera;
using Zenject;

public class CameraInstaller : Installer<CameraSettings, CameraInstaller>
{
	private readonly CameraSettings _cameraSettings;

	public CameraInstaller(CameraSettings cameraSettings) => _cameraSettings = cameraSettings;

	public override void InstallBindings()
	{
		Container.Bind<CameraMover>().AsSingle();
		
		Container.BindSignal<RollingPlayerLocationSignal>()
            .ToMethod<CameraMover>(x => x.OnPlayerMoved)
			.FromResolve();
		
	}
}
