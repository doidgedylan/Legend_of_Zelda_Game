using Legend_of_zelda_game;
using Legend_of_zelda_game.Interfaces;
using System;

namespace _3902_ocho.Commands
{
    public class LoadRoomCommand : ICommand
    {
        private Game1 game;
        private int roomNum;
        public LoadRoomCommand(Game1 game, int roomNum)
        {
            this.game = game;
            this.roomNum = roomNum;
        }
        public void Execute()
        {
            this.game.SelectRoom(roomNum);
        }
    }
}
