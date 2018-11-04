using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyDragon.Screens
{
    public class GameScreen : Screen
    {
        public Texture2D background;
        public Texture2D sand;
        public Texture2D gameover;
        public SoundEffect PipePassEffect;
        public SoundEffect PipeHitEffect;
        public Entities.Dragon Dragon;
        public Entities.Scroll Scroll;
        public SpriteFont Font;

        public int score = 0;

        public List<Entities.Spike> Spike;
        public int spikeTimer = 2000;
        public double spikeElapsed = 0;


        public GameScreen()
        {

        }
        public override void LoadContent() 
        {
            background = Statics.CONTENT.Load<Texture2D>("Textures/Background");
            sand = Statics.CONTENT.Load<Texture2D>("Textures/Sand");
            gameover = Statics.CONTENT.Load<Texture2D>("Textures/Gameover");
            this.PipePassEffect = Statics.CONTENT.Load<SoundEffect>("Effects/PipePass");
            this.PipeHitEffect = Statics.CONTENT.Load<SoundEffect>("Effects/PipeHit");
            Font = Statics.CONTENT.Load<SpriteFont>("Fonts/Font");


            Reset();

            base.LoadContent();
        }

        public void Reset()
        {
            Dragon = new Entities.Dragon();
            Scroll = new Entities.Scroll();
            Spike = new List<Entities.Spike>();
            Spike.Add(new Entities.Spike());
            score = 0;

        }
        public override void Update()
        {
            spikeCreator();
            if (!Dragon.dead)
            {
                for (int i = Spike.Count - 1; i > -1; i--)
                {
                    if (Spike[i].position.X < -50)
                        Spike.RemoveAt(i);
                    else
                    {
                        Spike[i].Update();
                        if (!Spike[i].scored && Dragon.Position.X > Spike[i].position.X + 50)
                        {
                            Spike[i].scored = true;
                            score++;
                            this.PipePassEffect.Play();
                        }

                        if (Dragon.Bound.Intersects(Spike[i].TopBound1) || Dragon.Bound.Intersects(Spike[i].TopBound2) || Dragon.Bound.Intersects(Spike[i].TopBound3) ||
                            Dragon.Bound.Intersects(Spike[i].TopBound4) || Dragon.Bound.Intersects(Spike[i].TopBound5) || Dragon.Bound.Intersects(Spike[i].TopBound6) ||
                            Dragon.Bound.Intersects(Spike[i].ButtomBound1) || Dragon.Bound.Intersects(Spike[i].ButtomBound2) || Dragon.Bound.Intersects(Spike[i].ButtomBound3) ||
                            Dragon.Bound.Intersects(Spike[i].ButtomBound4) || Dragon.Bound.Intersects(Spike[i].ButtomBound5))
                        {
                           Dragon.dead = true;
                           this.PipeHitEffect.Play();
                        }
                    }
                }
                Dragon.Update();
                Scroll.Update();
            }

            if (Dragon.dead && Statics.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.R))
            {
                this.Reset();
            }
            base.Update();
        }

        public void spikeCreator()
        {
            spikeElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (spikeElapsed > spikeTimer)
            {
                Spike.Add(new Entities.Spike());
                spikeElapsed = 0;
            }
        }

        public override void Draw()
        {
            Statics.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null);

            Statics.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White);
            foreach (var item in Spike)
            {
                item.Draw();
            }

            Statics.SPRITEBATCH.Draw(this.sand, new Vector2(0, 529), Color.White);

            Dragon.Draw();
            Scroll.Draw();

            Statics.SPRITEBATCH.DrawString(this.Font, this.score.ToString(), new Vector2(185,40), Color.Red);
            if (Dragon.dead)
            {
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, new Rectangle(0,0,Statics.GAME_WIDTH,Statics.GAME_HEIGHT), new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(this.gameover, new Vector2(70, 80), Color.White);
            }
            Statics.SPRITEBATCH.End();
            base.Draw();
        }
    }
}
