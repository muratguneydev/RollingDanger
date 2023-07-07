using RollingDanger.Events;
using RollingDanger.RollingPlayer;
using Zenject;

public class RollingPlayerInstaller : Installer<RollingPlayerSettings, RollingPlayerInstaller>
{
	private readonly RollingPlayerSettings _rollingPlayerSettings;

	public RollingPlayerInstaller(RollingPlayerSettings rollingPlayerSettings) => _rollingPlayerSettings = rollingPlayerSettings;

	public override void InstallBindings()
	{
		Container.Bind<Mover>().AsSingle();

		Container.DeclareSignal<JumpSignal>();
		Container.BindSignal<JumpSignal>()
            .ToMethod<Mover>(x => x.OnJump)
			.FromResolve();
		Container.DeclareSignal<RollSignal>();
		Container.BindSignal<RollSignal>()
            .ToMethod<Mover>(x => x.OnRoll)
			.FromResolve();

		Container.DeclareSignal<RollingPlayerLocationSignal>();


		//Container.BindInstance(_rollingPlayerSettings).AsSingle();
		//Container.BindInstance(_rollingPlayerSettings.Velocity).WhenInjectedInto<Mover>();

		// Container.DeclareSignal<FrogPlayerMovedSignal>();
		// Container.BindSignal<FrogPlayerMovedSignal>()
        //     .ToMethod<SpriteHorizontalDirectionManager>(x => x.OnFrogPlayerMoved)
		// 	.FromResolve();
		// Container.BindSignal<FrogPlayerMovedSignal>()
        //     .ToMethod<FrogPlayerAnimatorManager>(x => x.OnFrogPlayerMoved)
		// 	.FromResolve();
		// Container.BindSignal<FrogPlayerMovedSignal>()
        //     .ToMethod<Enemy1BulletSpawner>(x => x.OnFrogPlayerMoved)
		// 	.FromResolve();

		// Container.Bind<FrogPlayerHealthManager>().AsSingle();
		// Container.DeclareSignal<FrogPlayerDiedSignal>();
		// Container.BindSignal<FrogPlayerDiedSignal>()
        //     .ToMethod<FrogPlayerAnimatorManager>(x => x.OnFrogPlayerDied)
		// 	.FromResolve();

		// Container.DeclareSignal<FrogPlayerHitUISignal>();
		// Container.BindSignal<FrogPlayerHitUISignal>()
        //     .ToMethod<FrogPlayerHealthManager>(x => x.OnHitByAnObject)
		// 	.FromResolve();
		

		// Container.Bind<SpriteHorizontalDirectionManager>().AsSingle();
		// Container.Bind<FrogPlayerAnimatorManager>().AsSingle();
		
	}
}
