using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyDragon.Entities
{
    public class Spike
    {
        public Texture2D texture;
        public Vector2 position;

        public bool scored = false;

        public Spike()
        {
            this.texture = Statics.CONTENT.Load<Texture2D>("Textures/Spikes");
            this.position = new Vector2(420, Statics.RANDOM.Next(-200,10));
        }
        public void Update()
        {
            this.position.X -= 2f;
        }
        public Rectangle TopBound1 { get { return new Rectangle((int)this.position.X, (int)this.position.Y, 55, 235); } }
        public Rectangle TopBound2 { get { return new Rectangle((int)this.position.X+4, (int)this.position.Y, 48, 260); } }
        public Rectangle TopBound3 { get { return new Rectangle((int)this.position.X + 10, (int)this.position.Y, 38, 280); } }
        public Rectangle TopBound4 { get { return new Rectangle((int)this.position.X + 14, (int)this.position.Y, 28, 295); } }
        public Rectangle TopBound5 { get { return new Rectangle((int)this.position.X + 19, (int)this.position.Y, 18, 310); } }
        public Rectangle TopBound6 { get { return new Rectangle((int)this.position.X + 24, (int)this.position.Y, 8, 339); } }
        public Rectangle ButtomBound1 { get { return new Rectangle((int)this.position.X, (int)this.position.Y + 560, 53, 200); } }
        public Rectangle ButtomBound2 { get { return new Rectangle((int)this.position.X+4, (int)this.position.Y + 530, 45, 342); } }
        public Rectangle ButtomBound3 { get { return new Rectangle((int)this.position.X+10, (int)this.position.Y + 500, 30, 342); } }
        public Rectangle ButtomBound4 { get { return new Rectangle((int)this.position.X+18, (int)this.position.Y + 480, 15, 342); } }
        public Rectangle ButtomBound5 { get { return new Rectangle((int)this.position.X+22, (int)this.position.Y + 460, 8, 342); } }



        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(this.texture, this.position, Color.White);

           if (Statics.DEBUG)
            {
                //show debug top
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.TopBound1, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.TopBound2, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.TopBound3, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.TopBound4, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.TopBound5, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.TopBound6, new Color(1f, 0f, 0f, 0.3f));
                //show debug buttom
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.ButtomBound1, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.ButtomBound2, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.ButtomBound3, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.ButtomBound4, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.ButtomBound5, new Color(1f, 0f, 0f, 0.3f));


           }
        }
    }
}
