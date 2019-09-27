using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    public enum Buttons
    {
        Up, Down, Left, Right, W, A, S, D, Z, X, C, E, N, Q, R, RightClick, LeftClick, NoButtonsPressed
    }
    interface IController
    {
        void RegisterCommand(Buttons button, ICommand command);
        void Update();
    }
}
