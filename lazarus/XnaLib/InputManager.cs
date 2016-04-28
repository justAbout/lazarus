using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace XnaLib
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class InputManager : Microsoft.Xna.Framework.GameComponent
    {
        static KeyboardState keyboardstate;
        static KeyboardState lastKeyboardstate;

        public static KeyboardState GetKeyboardstate
        {
            get { return keyboardstate;  }
        }

        public static KeyboardState GetLastKeyboardstate
        {
            get { return lastKeyboardstate;  }
        }

        public InputManager(Game game)
            : base(game)
        {
            keyboardstate = Keyboard.GetState();
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            lastKeyboardstate = keyboardstate;
            keyboardstate = Keyboard.GetState();

            base.Update(gameTime);
        }

        public static void Flush()
        {
            lastKeyboardstate = keyboardstate;
        }

        public static bool KeyReleased(Keys key)
        {
            return keyboardstate.IsKeyUp(key) && lastKeyboardstate.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardstate.IsKeyDown(key);
        }

    }
}
