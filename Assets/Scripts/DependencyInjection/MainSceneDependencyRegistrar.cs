using RollingDanger.RollingPlayer;
using Zenject;

public class MainSceneDependencyRegistrar : MonoInstaller
{
	[Inject] RollingPlayerSettings _rollingPlayerSettings;

    public override void InstallBindings()
    {
		Container.Install<CoreInstaller>();
		RollingPlayerInstaller.Install(Container, _rollingPlayerSettings);
    }
}
