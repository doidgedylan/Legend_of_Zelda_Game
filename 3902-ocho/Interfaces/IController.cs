using Legend_of_zelda_game.Interfaces;

namespace Legend_of_zelda_game
{
    public enum Buttons
    {
        Up, Down, Left, Right, W, A, S, D, Z, X, C, N, Q, R, B, G, D1, D2, D3, D4, D5, D6, D7, D8, D9, D0, 
        NumPad1, NumPad2, NumPad3, NumPad4, NumPad5, NumPad6, NumPad7, NumPad8, RightClick, LeftClick, NoButtonsPressed
    }
    interface IController
    {
        void RegisterCommand(Buttons button, ICommand command);
        void Update();
    }
}
