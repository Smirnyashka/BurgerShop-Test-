using Code.Services.SceneLoader;

namespace Code.Services.StateMachine.States
{
    public class LoadingState : IState
    {
        private readonly ISceneLoader _sceneLoader;

        public LoadingState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene("SampleScene");
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}