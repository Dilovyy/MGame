using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MAGICGAME;

public class MainMenuState : State
{
    private List<Component> _components;
    public MainMenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
    {
        var buttonTexture = _content.Load<Texture2D>("Controls/Button");
        var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

        var newGameButton = new Button(buttonTexture, buttonFont)
        {
            Position = new Vector2(300, 200),
            Text = "New Game",
        };
        newGameButton.Click += NewGameButton_Click;

        var MapButton = new Button(buttonTexture, buttonFont)
        {
            Position = new Vector2(300, 300),
            Text = "Map",
        };
        MapButton.Click += MapButton_Click;

        var BattleButton = new Button(buttonTexture, buttonFont)
        {
            Position = new Vector2(300, 400),
            Text = "Battle",
        };
        BattleButton.Click += BattleButton_Click;

        var exitButton = new Button(buttonTexture, buttonFont)
        {
            Position = new Vector2(300, 500),
            Text = "Exit",
        };
        exitButton.Click += ExitButton_Click;


        _components = new List<Component>()
        {
            newGameButton,
            MapButton,
            BattleButton,
            exitButton,
        };

    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        _game.Exit();
    }

    private void BattleButton_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Battle state"); // Чтобы чекнуть аутпут консоли, в csproj поменять на время WinExe на Exe
        _game.ChangeState(new BattleState(_game, _graphicsDevice, _content));
        
    }

    private void MapButton_Click(object sender, EventArgs e)
    {
        Console.WriteLine("Map state");
        _game.ChangeState(new MapState(_game, _graphicsDevice, _content));
        
    }

    private void NewGameButton_Click(object sender, EventArgs e)
    {
        Console.WriteLine("New Game state");
        _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        foreach(var component in _components){
            component.Draw(gameTime, spriteBatch);
        }

        spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime)
    {
        //
    }

    public override void Update(GameTime gameTime)
    {
        foreach(var component in _components){
            component.Update(gameTime);
        }
    }
}