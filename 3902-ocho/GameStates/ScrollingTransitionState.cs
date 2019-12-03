using Legend_of_zelda_game.Interfaces;
using System.IO;
using static Legend_of_zelda_game.Blocks.Door;

namespace Legend_of_zelda_game.GameStates
{
    public enum TransitionType { TO_ROOM, TO_ITEMSELECT }
    public class ScrollingTransitionState : IGameState
    {
        private IBackground originalBackground;
        private IBackground destinationBackground;
        private Direction direction;
        public ScrollingTransitionState(IBackground originalBackground, IBackground destinationBackground, Direction direction)
        {
            this.originalBackground = originalBackground;
            this.destinationBackground = destinationBackground;
            this.direction = direction;

            string path = Directory.GetCurrentDirectory() + "\\The Legend of Zelda Cartoon Sound Effects\\The Legend of Zelda Cartoon Sound Effects Door Opened.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
            player.Play();
        }
        public void Update()
        {
            originalBackground.ScrollOut(direction);
            destinationBackground.ScrollIn(direction);
        }
    }
}
