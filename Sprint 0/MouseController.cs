using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint_0
{
    class MouseController : IController
    {
        private int xAxis;
        private int yAxis;
        private ICommand exitCommand;
        private ICommand stationarySpriteCommand;
        private ICommand animatedSpriteCommand;
        private ICommand movingSpriteCommand;
        private ICommand movingAnimatedSpriteCommand;

        public MouseController(int xAxis, int yAxis, ICommand exitCommand, ICommand stationarySpriteCommand, ICommand animatedSpriteCommand, ICommand movingSpriteCommand, ICommand movingAnimatedSpriteCommand)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
            this.exitCommand = exitCommand;
            this.stationarySpriteCommand = stationarySpriteCommand;
            this.animatedSpriteCommand = animatedSpriteCommand;
            this.movingSpriteCommand = movingSpriteCommand;
            this.movingAnimatedSpriteCommand = movingAnimatedSpriteCommand;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            
        }

        public void Update()
        {
            MouseState currentState = Mouse.GetState();
            int mouseX = currentState.X;
            int mouseY = currentState.Y;
            if (currentState.RightButton == ButtonState.Pressed)
            {
                this.exitCommand.Execute();
            }
            if (currentState.LeftButton == ButtonState.Pressed)
            {
                if (mouseX < yAxis && mouseX > 0)
                {
                    if (mouseY < xAxis && mouseY > 0)
                    {
                        // top left
                        this.stationarySpriteCommand.Execute();
                    }
                    else if (mouseY < 480)
                    {
                        // bottom left
                        this.movingSpriteCommand.Execute();
                    }
                }
                else if (mouseX < 800)
                {
                    if (mouseY < xAxis && mouseY > 0)
                    {
                        // top right
                        this.animatedSpriteCommand.Execute();
                    }
                    else if (mouseY < 480)
                    {
                        // bottom right
                        this.movingAnimatedSpriteCommand.Execute();
                    }
                }
            }
        }
    }
}