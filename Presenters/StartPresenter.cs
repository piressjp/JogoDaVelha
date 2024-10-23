using src.Views.Interfaces;

namespace src.Presenters
{
    public class StartPresenter
    {
        private readonly IStartView _view;

        public StartPresenter(IStartView view)
        {
            _view = view;
        }

        public void StartGame(bool vsMachine)
        {
            _view.ShowGame(vsMachine);
        }
    }
}
