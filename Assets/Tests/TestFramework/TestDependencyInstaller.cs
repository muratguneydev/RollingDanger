using UnityEngine;
using Scripts;
using Zenject;
using RollingDanger.RollingPlayer;
using Scripts.Camera;

public class TestDependencyInstaller
{
	//const int RollingPlayerVelocity= 10;
	//private const string AnimatorControllerAssetPath = "Assets/Animations/FrogPlayerController.controller";
	private readonly DiContainer _container;
	private readonly KeyInput _keyInput;
	private readonly RollingPlayerSettings _rollingPlayerSettings;
	private readonly CameraSettings _cameraSettings = new CameraSettings(default, default);

	public TestDependencyInstaller(DiContainer container, KeyInput keyInput, RollingPlayerSettings rollingPlayerSettings)
	{
		_container = container;
		_keyInput = keyInput;
		_rollingPlayerSettings = rollingPlayerSettings;
	}

	public TestDependencyInstaller(DiContainer container, KeyInput keyInput)
		: this(container, keyInput,
				new RollingPlayerSettings(1f, 2f))
	{
		
	}

	// public TestDependencyInstaller(DiContainer container)
	// 	: this(container, KeyInputStub.None)
	// {

	// }

	public void Install()
	{
		RegisterDependencies();
		//SetAnimatorControllerToBeAbleToGetAndSetAnimatorParameters();

		var dummyUIEventHandler = UIEventHandler;
	}

	public RollingPlayerBehaviour RollingPlayerBehaviour => _container.Resolve<RollingPlayerBehaviour>();
	//Note: This is to trigger UIEventHandler events like Update to be fired. If it is not resolved, its events won't be fired.
	public UIEventHandler UIEventHandler => _container.Resolve<UIEventHandler>();
	public GameObject RollingPlayerGameObject => RollingPlayerBehaviour.gameObject;
	// public IEventBus EventBus => _container.Resolve<IEventBus>();
	// public GameController GameController => _container.Resolve<GameController>();

	// public GameOverBehaviour GameOverBehaviour => _container.Resolve<GameOverBehaviour>();
	// public GameObject GameOverGameObject => GameOverBehaviour.gameObject;


	private void RegisterDependencies()
	{
		_container.Install<CoreInstaller>();

		_container.BindInstance(_cameraSettings);
		CameraInstaller.Install(_container, _cameraSettings);

		_container.BindInstance(_rollingPlayerSettings);
		RollingPlayerInstaller.Install(_container, _rollingPlayerSettings);
		//InstallEnemy1Dependencies();

		_container.Rebind<KeyInput>().FromInstance(_keyInput);//For non-interface types, rebind cannot be AsSingle.
		_container.Bind<RollingPlayerBehaviour>().FromNewComponentOnNewGameObject()
			.AsSingle();
		_container.Bind<UIEventHandler>().FromNewComponentOnNewGameObject()
			.AsSingle();
		// _container.Bind<GameOverBehaviour>().FromNewComponentOnNewGameObject()
		// 	.AsSingle();
	}

	// private void InstallEnemy1Dependencies()
	// {
	// 	//TODO: For some reason we can't reference IInitializable here as commented out below, and use a dummy for GameController
	// 	//to avoid dependency to objects which are not really needed here.
		
	// 	_container.BindInstance(_enemy1Settings);
	// 	_container.BindInstance(_enemy1BulletSettings);
	// 	Enemy1Installer.Install(_container, _enemy1Settings, _enemy1BulletSettings);
	// 	_container.Bind<Enemy1Behaviour>().FromNewComponentOnNewGameObject().AsSingle();
	// 	_container.Bind<Enemy1BulletBehaviour>().AsSingle();

	// 	//REbind interfaces???
	// 	//_container.Rebind<IInitializable>().FromInstance(new GameControllerDummy());
	// }

	// private void SetAnimatorControllerToBeAbleToGetAndSetAnimatorParameters()
	// {
	// 	//Note: This is to avoid the error: "Animator is not playing an AnimatorController"
	// 	var animator = FrogPlayerBehaviour.gameObject.GetComponent<Animator>();
	// 	var controller = UnityEditor.AssetDatabase.LoadAssetAtPath<AnimatorController>(AnimatorControllerAssetPath);
	// 	animator.runtimeAnimatorController = controller;
	// }



}
