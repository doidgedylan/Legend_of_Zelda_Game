using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legend_of_zelda_game
{
    public class Camera
    {
        private readonly Viewport view;
        private Vector2 position;

        public Vector2 Origin { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }
        public Camera(Viewport viewport)
        {
            this.view = viewport;
            Origin = new Vector2(viewport.Width / 2.0f, viewport.Height / 2.0f);
            Zoom = 1.0f;
        }
        

        public Matrix TransformMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-position, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1f) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));

        }

        

    }
}
