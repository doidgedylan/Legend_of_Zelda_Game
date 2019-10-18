using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    public enum Buttons
    {
        Up, Down, Left, Right, W, A, S, D, Z, X, C, N, Q, R, D1, D2, D3, RightClick, LeftClick, NoButtonsPressed
    }
    interface IController
    {
        void RegisterCommand(Buttons button, ICommand command);
        void Update();
    }
}
