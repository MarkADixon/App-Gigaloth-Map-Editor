using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ParallaxEngine;

namespace GigalothMapEditor
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region DECLARATIONS
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public SpriteFont spriteFont;
        //public ContentManager content;
        public Random rand = new Random();

        IntPtr drawSurface;
        //IntPtr drawSurface2;
        System.Windows.Forms.Form parentForm;
        System.Windows.Forms.PictureBox pictureBox;
        System.Windows.Forms.Control gameForm;

        //integrate the parallaxengine which holds sprite and layer data and manipulation functions
        public ParallaxManager parallaxEngine;

        public int editingLayer = 0;  //which layer of the current map are we editing?
        //placement sprite is one created from the texture sheets and serves as a buffer until placed in right click place mode
        //selected sprite copies an existing sprite from the layer as an available placement option
        public Sprite placementSprite;
        
        public bool isPlacementBlocked = false;
        public List<Sprite> placementBlockingSprites = new List<Sprite>();
        public bool isMouseOverPlacedSprite = false;
        public bool isExistingSpriteSelected = false;  //while true this flag allows selected sprite in the layer to be highlighted
        public int selectedSpriteIndex = 0, tempselectedSpriteIndex = 0; //index in the list of sprites existing on the editinglayer for a selected one

        //initialize the size of the world and the grid
        public int worldGridTileWidth = 16;
        public int worldGridTileHeight = 16;
        public int worldGridMapWidth = 200;
        public int worldGridMapHeight = 100;
        public int worldWidth=0;
        public int worldHeight=0;
        public int world = 0;
        public int level = 0;
        public string texturePack = @"\Textures\GrassTexturePack.pck";

        //variables to used to translate parallax to draw place correctly when parallaxes layer is selected
        Vector2 parallaxOffset = Vector2.Zero;
        MouseState ms;
        Vector2 mouseLoc = Vector2.Zero;

        //basic textures used to create editor effects
        public Texture2D worldGridTexture,boxOutlineTexture,boxHighlightTexture;
     

        //view select variables
        public bool isWorldGridOn = true, isTextOverlayOn = true, isSpriteTypeOverlayOn = true, isShowNearerLayers = false;
        public float highlightEffect = 0.0f;
        public bool highlightEffectIncrease = true;
        public string spriteTypeOverlay = "";
        public bool isInputSuspended = false;
        public bool isSelectSpriteMode = false;
        public bool isSpriteJustSelected = false;

        //form button toggle states
        public enum RightClickMode { PlaceTile, ClearTile};
        public RightClickMode rightClickMode = RightClickMode.PlaceTile;
        public enum PlaceMode { GridSnap, FreePlace };
        public PlaceMode placeMode = PlaceMode.GridSnap;
      
        

        public MouseState lastMouseState;
        public Vector2 lastGridLocation=Vector2.Zero;
        System.Windows.Forms.VScrollBar vscroll;
        System.Windows.Forms.HScrollBar hscroll;
        public float elapsedTime;
        #endregion


        #region CONSTRUCTOR
        //public Game1(IntPtr drawSurface, IntPtr drawSurface2, System.Windows.Forms.Form parentForm, System.Windows.Forms.PictureBox pictureBox )
        public Game1(IntPtr drawSurface, System.Windows.Forms.Form parentForm, System.Windows.Forms.PictureBox pictureBox )
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            #region Winforms setup
            this.drawSurface = drawSurface;
            //this.drawSurface2 = drawSurface2;
            this.parentForm = parentForm;
            this.pictureBox = pictureBox;
           
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            
            Mouse.WindowHandle = drawSurface;

            vscroll = (System.Windows.Forms.VScrollBar)parentForm.Controls["vScrollBar1"];
            hscroll = (System.Windows.Forms.HScrollBar)parentForm.Controls["hScrollBar1"];
            
            gameForm = System.Windows.Forms.Control.FromHandle(this.Window.Handle);
            gameForm.VisibleChanged += new EventHandler(gameForm_VisibleChanged);
            gameForm.SizeChanged += new EventHandler(pictureBox_SizeChanged);
            #endregion


            
            parallaxEngine = new ParallaxManager(this);
   
        }

        #endregion


        #region EVENTHANDLERS

        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
        }

        //passes editor window size changes to camera and graphics device
        void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            if (parentForm.WindowState != System.Windows.Forms.FormWindowState.Minimized)
            {
                graphics.PreferredBackBufferWidth = pictureBox.Width;
                graphics.PreferredBackBufferHeight = pictureBox.Height;
                Camera.ViewportWidth = pictureBox.Width;
                Camera.ViewportHeight = pictureBox.Height;
                graphics.PreferMultiSampling = true;
                graphics.ApplyChanges();
            }

        }

        void gameForm_VisibleChanged(object sender, EventArgs e)
        {
            if (gameForm.Visible == true) gameForm.Visible = false;
        }

        #endregion

        #region INITIALIZE (empty)
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
 

            base.Initialize();
        }

        #endregion


        #region LOAD CONTENT
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            LevelDataManager.Initialize(this);

            
            spriteFont = Content.Load<SpriteFont>(@"Fonts\Moire");

            worldWidth = worldGridTileWidth * worldGridMapWidth;
            worldHeight = worldGridTileHeight * worldGridMapHeight;
            worldGridTexture = Content.Load<Texture2D>(@"defaultTextures\grid");
            boxOutlineTexture = Content.Load<Texture2D>(@"defaultTextures\outline");
            boxHighlightTexture = Content.Load<Texture2D>(@"defaultTextures\highlight");

            Camera.ViewportWidth = pictureBox.Width;
            Camera.ViewportHeight = pictureBox.Height;
            Camera.WorldRectangle = new Rectangle(0, 0, worldWidth, worldHeight);
            Camera.Position = new Vector2(0, (worldHeight - Camera.ViewportHeight));
            Camera.SetScreenRectangle();

            lastMouseState = Mouse.GetState();
            pictureBox_SizeChanged(null, null);


            NewMap(Content.RootDirectory+texturePack, 16, 16, 200, 100);

        }
        #endregion



        #region UNLOAD
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        #endregion

        #region UPDATE

        protected override void Update(GameTime gameTime)
        {
            //allows skipping input based on flag
            if (isInputSuspended)
            {
                base.Update(gameTime);
                return;
            }

            

            HandleKeyboardInput(gameTime);

            //update campera position based on window scrollbars
            if (Camera.Rotation == 0.0) Camera.Position = new Vector2(hscroll.Value, vscroll.Value);

            #region HANDLE MOUSE INPUT
            
            //get mousestate
            ms = Mouse.GetState();

            Rectangle mouseInterceptRect = new Rectangle((int)(ms.X + Camera.Position.X), (int)(ms.Y + Camera.Position.Y), 1, 1);
            //creates the offset for the display of grid and selected sprite on mouse on the parallax Layers (used by Draw Method on next tick)
            parallaxOffset = new Vector2(((1.0f - parallaxEngine.worldLayers[editingLayer].LayerParallax.X) * Camera.Position.X),
                                                  ((1.0f - parallaxEngine.worldLayers[editingLayer].LayerParallax.Y) * Camera.Position.Y));
 
            //if mouse is in bounds of the screen check for button pressed
            if (Camera.Viewport.Contains(mouseInterceptRect))
            {
                //translate the mouse coordinates to world coordinates
                mouseLoc = Camera.ScreenToWorld(new Vector2(ms.X, ms.Y), parallaxEngine.worldLayers[editingLayer].LayerParallax);

                Rectangle mouseLocRect = new Rectangle((int)(mouseLoc.X), (int)(mouseLoc.Y), 1, 1);

                CheckForBlockedPlacement(gameTime);
                if (isSelectSpriteMode) CheckForMouseOverSprite(gameTime,mouseLocRect);


                //sets the location of the "yet to be placed" sprite to the exact location of the mouse pointer
                if (placeMode == PlaceMode.FreePlace)
                {
                        placementSprite.Location = mouseLoc;
                }

                //snaps the value of the "yet to be placed" sprite location to the grid size currently set
                if (placeMode == PlaceMode.GridSnap)
                {
                    placementSprite.Location = new Vector2(
                        ((int)(mouseLoc.X / worldGridTileWidth)) * worldGridTileWidth,
                        ((int)(mouseLoc.Y / worldGridTileHeight)) * worldGridTileHeight);
                }

                //if left button is pressed, selects the already placed sprite at that location
                if (ms.LeftButton == ButtonState.Pressed && isMouseOverPlacedSprite == true)
                {
                    selectedSpriteIndex = tempselectedSpriteIndex;
                    placementSprite = parallaxEngine.worldLayers[editingLayer].layerSprites[selectedSpriteIndex].Clone();
                    isExistingSpriteSelected = true;
                    isSpriteJustSelected = true;
                }
                //deselect by clicking elsewhere
                if (ms.LeftButton == ButtonState.Pressed && isMouseOverPlacedSprite == false)
                {
                    isExistingSpriteSelected = false;
                }

                //if right button is pressed, places the sprite into the layer, or clears the sprite from the layer
                if (ms.RightButton == ButtonState.Pressed)
                {
                   switch (rightClickMode)
                   {
                       case RightClickMode.PlaceTile :
                       {
                           if (!isPlacementBlocked)
                           {
                               placementSprite.SpriteType = LevelDataManager.levelTextures[placementSprite.TextureID].SpriteType;
                               placementSprite.InitPathingPoint();
                               parallaxEngine.worldLayers[editingLayer].AddSpriteToLayer(placementSprite.Clone());
                               if (placementSprite.SpriteType == "TERRAIN" && placementSprite.TextureIndex < 2)
                               {
                                   parallaxEngine.worldLayers[editingLayer].LayerSprites[parallaxEngine.worldLayers[editingLayer].SpriteCount - 1].TextureIndex =
                                       rand.Next(0, 2);
                               }
                           }
                           break; 
                       }

                       case RightClickMode.ClearTile:
                       {
                           if (isMouseOverPlacedSprite)
                           {
                               isExistingSpriteSelected = false;
                               isMouseOverPlacedSprite = false;
                               parallaxEngine.worldLayers[editingLayer].DeleteSpriteFromLayer(parallaxEngine.worldLayers[editingLayer].layerSprites[tempselectedSpriteIndex]);
                           }
                           break;
                       }                       
                    }
                }
            }
            #endregion



            parallaxEngine.Update(gameTime);
            placementSprite.Update(gameTime);
            //UpdateHighlightEffect(gameTime);

            foreach (Layer layer in parallaxEngine.worldLayers)
            {
                bool spriteDeleteFlag = parallaxEngine.DeleteOffWorldSprites(layer);
                //failsafe to prevent errors that occur because of deleting of selected sprite by level culling
                if (spriteDeleteFlag)
                {
                    selectedSpriteIndex = 0;
                    isExistingSpriteSelected = false;
                }
            }




            base.Update(gameTime);
        }

        #region UPDATE HELPER METHODS



        //Method handles all game related Keyboard Input, the Editor via winform seperately captures keystrokes from the hardware
        //unable to seperate the two or intercept them, so no keys are used in here that react with teh winform part of the screen
        private void HandleKeyboardInput(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            //camera keys
            elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Right))
                if (Camera.Rotation != 0.0 || Camera.Zoom != 1.0) Camera.Move(new Vector2(400.0f * elapsedTime, 0.0f), true);
                else hscroll.Value = (int)MathHelper.Clamp(hscroll.Value + (600.0f * elapsedTime), 0, hscroll.Maximum);

            if (keyboardState.IsKeyDown(Keys.Left))
                if (Camera.Rotation != 0.0 || Camera.Zoom != 1.0) Camera.Move(new Vector2(-400.0f * elapsedTime, 0.0f), true);
                else hscroll.Value = (int)MathHelper.Clamp(hscroll.Value - (600.0f * elapsedTime), 0, hscroll.Maximum);

            if (keyboardState.IsKeyDown(Keys.Down))
                if (Camera.Rotation != 0.0) Camera.Move(new Vector2(0.0f, 400.0f * elapsedTime), true);
                else vscroll.Value = (int)MathHelper.Clamp(vscroll.Value + (600.0f * elapsedTime), 0, vscroll.Maximum);

            if (keyboardState.IsKeyDown(Keys.Up))
                if (Camera.Rotation != 0.0) Camera.Move(new Vector2(0.0f, -400.0f * elapsedTime), true);
                else vscroll.Value = (int)MathHelper.Clamp(vscroll.Value - (600.0f * elapsedTime), 0, vscroll.Maximum);

            if (keyboardState.IsKeyDown(Keys.PageUp))
                Camera.Zoom += 1.0f * elapsedTime;

            if (keyboardState.IsKeyDown(Keys.PageDown))
                Camera.Zoom -= 1.0f * elapsedTime;

            //if (keyboardState.IsKeyDown(Keys.Q))
            //    Camera.Rotation += 3.0f * elapsedTime;

            //if (keyboardState.IsKeyDown(Keys.E))
            //    Camera.Rotation -= 3.0f * elapsedTime;

            if (keyboardState.IsKeyDown(Keys.Home))
            {
                Camera.Position = Vector2.Zero;
                Camera.Zoom = 1.0f;
                Camera.Rotation = 0.0f;
            }
        }

        #region COLLISION DETECTION
        private void CheckForBlockedPlacement(GameTime gameTime)
        {
            isPlacementBlocked = false;
            placementBlockingSprites.Clear();

            // Build the placement sprites transform
            Matrix placementSpriteTransform =
                Matrix.CreateTranslation(new Vector3(-placementSprite.SpriteOrigin, 0.0f)) *
                Matrix.CreateScale(placementSprite.Scale) *  
                Matrix.CreateRotationZ(placementSprite.TotalRotation) *
                Matrix.CreateTranslation(new Vector3(placementSprite.SpriteCenterInWorld, 0.0f));

            // Calculate the bounding rectangle of this block in world space
            Rectangle placementSpriteBoundingRectangle = CalculateBoundingRectangle(
                     new Rectangle(0, 0, placementSprite.SpriteRectangle.Width, placementSprite.SpriteRectangle.Height),
                     placementSpriteTransform);

            foreach (Sprite placedSprite in parallaxEngine.worldLayers[editingLayer].layerSprites)
            {
                // Build the sprites transform
                Matrix placedSpriteTransform =
                    Matrix.CreateTranslation(new Vector3(-placedSprite.SpriteOrigin, 0.0f)) *
                    Matrix.CreateScale(placedSprite.Scale) *  
                    Matrix.CreateRotationZ(placedSprite.TotalRotation) *
                    Matrix.CreateTranslation(new Vector3(placedSprite.SpriteCenterInWorld, 0.0f));

                // Calculate the bounding rectangle of this block in world space
                Rectangle placedSpriteBoundingRectangle = CalculateBoundingRectangle(
                         new Rectangle(0, 0, placedSprite.SpriteRectangle.Width, placedSprite.SpriteRectangle.Height),
                         placedSpriteTransform);

                if (placementSpriteBoundingRectangle.Intersects(placedSpriteBoundingRectangle))
                {
                    isPlacementBlocked = true;
                    Sprite blocker = placedSprite.Clone();
                    placementBlockingSprites.Add(blocker);
                }
            }

            foreach (Sprite blockingSprite in placementBlockingSprites)
            {
                    // Build the sprites transform
                    Matrix blockingSpriteTransform =
                        Matrix.CreateTranslation(new Vector3(-blockingSprite.SpriteOrigin, 0.0f)) *
                        Matrix.CreateScale(blockingSprite.Scale) *
                        Matrix.CreateRotationZ(blockingSprite.TotalRotation) *
                        Matrix.CreateTranslation(new Vector3(blockingSprite.SpriteCenterInWorld, 0.0f));

                    // Calculate the bounding rectangle of this block in world space
                    Rectangle blockingSpriteBoundingRectangle = CalculateBoundingRectangle(
                             new Rectangle(0, 0, blockingSprite.SpriteRectangle.Width, blockingSprite.SpriteRectangle.Height),
                             blockingSpriteTransform);

                    isPlacementBlocked = IntersectPixels(placementSpriteTransform, placementSprite, placementSprite.GetCollisionData,
                                                          blockingSpriteTransform, blockingSprite, blockingSprite.GetCollisionData);
                    if (isPlacementBlocked) break;
            }
            return;
        }

        //can be used for per pixel collision on 2 non transformed nonrotated sprites
        private bool IntersectPixels(Rectangle rectangleA, bool[,] dataA, Rectangle rectangleB, bool[,] dataB)
        {
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    bool collisionA = dataA[(x - rectangleA.Left), (y - rectangleA.Top)];
                    bool collisionB = dataB[(x - rectangleB.Left), (y - rectangleB.Top)];

                    if (collisionA && collisionB)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Determines if there is overlap of the non-transparent pixels between two
        /// sprites.
        /// </summary>
        /// <param name="transformA">World transform of the first sprite.</param>
        /// <param name="widthA">Width of the first sprite's texture.</param>
        /// <param name="heightA">Height of the first sprite's texture.</param>
        /// <param name="dataA">Pixel color data of the first sprite.</param>
        /// <param name="transformB">World transform of the second sprite.</param>
        /// <param name="widthB">Width of the second sprite's texture.</param>
        /// <param name="heightB">Height of the second sprite's texture.</param>
        /// <param name="dataB">Pixel color data of the second sprite.</param>
        /// <returns>True if non-transparent pixels overlap; false otherwise</returns>
        public static bool IntersectPixels(
                            Matrix transformA, Sprite spriteA, bool[,] dataA,
                            Matrix transformB, Sprite spriteB, bool[,] dataB)
        {
            int widthA = spriteA.SpriteRectWidth;
            int heightA = spriteA.SpriteRectHeight;
            int widthB = spriteB.SpriteRectWidth;
            int heightB = spriteB.SpriteRectHeight;
            float scaleXA = (float)widthA /(float)spriteA.TileWidth;
            float scaleYA = (float)heightA / (float)spriteA.TileHeight;
            float scaleXB = (float)widthB /(float) spriteB.TileWidth;
            float scaleYB = (float)heightB / (float) spriteB.TileHeight;
            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            Matrix transformAToB = transformA * Matrix.Invert(transformB);

            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            Vector2 stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            Vector2 stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            Vector2 yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            // For each row of pixels in A
            for (int yA = 0; yA < heightA; yA++)
            {
                // Start at the beginning of the row
                Vector2 posInB = yPosInB;

                // For each pixel in this row
                for (int xA = 0; xA < widthA; xA++)
                {
                    // Round to the nearest pixel
                    int xB = (int)Math.Round(posInB.X);
                    int yB = (int)Math.Round(posInB.Y);

                    // If the pixel lies within the bounds of B
                    if (0 <= xB && xB < widthB &&
                        0 <= yB && yB < heightB)
                    {
                        if (scaleXA != 1.0f) xA = (int) ((float)xA / (float)scaleXA);
                        if (scaleYA != 1.0f) yA = (int) ((float)yA / (float)scaleYA);
                        if (scaleXB != 1.0f) xB = (int) ((float)xB / (float)scaleXB);
                        if (scaleYB != 1.0f) yB = (int) ((float)yB / (float)scaleYB);

                        bool collisionA = dataA[xA , yA];
                        bool collisionB = dataB[xB , yB];

                        if (collisionA && collisionB)
                        {
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInB += stepX;
                }

                // Move to the next row
                yPosInB += stepY;
            }

            // No intersection found
            return false;
        }

        /// <summary>
        /// Calculates an axis aligned rectangle which fully contains an arbitrarily
        /// transformed axis aligned rectangle.
        /// </summary>
        /// <param name="rectangle">Original bounding rectangle.</param>
        /// <param name="transform">World transform of the rectangle.</param>
        /// <returns>A new rectangle which contains the trasnformed rectangle.</returns>
        public static Rectangle CalculateBoundingRectangle(Rectangle rectangle,
                                                           Matrix transform)
        {
            // Get all four corners in local space
            Vector2 leftTop = new Vector2(rectangle.Left, rectangle.Top);
            Vector2 rightTop = new Vector2(rectangle.Right, rectangle.Top);
            Vector2 leftBottom = new Vector2(rectangle.Left, rectangle.Bottom);
            Vector2 rightBottom = new Vector2(rectangle.Right, rectangle.Bottom);

            // Transform all four corners into work space
            Vector2.Transform(ref leftTop, ref transform, out leftTop);
            Vector2.Transform(ref rightTop, ref transform, out rightTop);
            Vector2.Transform(ref leftBottom, ref transform, out leftBottom);
            Vector2.Transform(ref rightBottom, ref transform, out rightBottom);

            // Find the minimum and maximum extents of the rectangle in world space
            Vector2 min = Vector2.Min(Vector2.Min(leftTop, rightTop),
                                      Vector2.Min(leftBottom, rightBottom));
            Vector2 max = Vector2.Max(Vector2.Max(leftTop, rightTop),
                                      Vector2.Max(leftBottom, rightBottom));

            // Return that as a rectangle
            return new Rectangle((int)min.X, (int)min.Y,
                                 (int)(max.X - min.X), (int)(max.Y - min.Y));
        }
        #endregion

        private void CheckForMouseOverSprite(GameTime gameTime, Rectangle _mouseInterceptRect)
        {
            isMouseOverPlacedSprite = false;

            for (int i = 0; i < parallaxEngine.worldLayers[editingLayer].layerSprites.Count; i++ )
            {
                if (parallaxEngine.worldLayers[editingLayer].layerSprites[i].SpriteRectangle.Contains(_mouseInterceptRect))
                    {
                        isMouseOverPlacedSprite = true;
                        tempselectedSpriteIndex = i;
                        return;
                    }
            }
            return;
        }

        private void UpdateHighlightEffect(GameTime gameTime)
        {
            if (highlightEffectIncrease)
            {
                highlightEffect += (float)gameTime.ElapsedGameTime.TotalSeconds / 8.0f;
                if (highlightEffect > 0.2f) highlightEffectIncrease = false;
            }
            else
            {
                highlightEffect -= (float)gameTime.ElapsedGameTime.TotalSeconds / 8.0f;
                if (highlightEffect < 0)
                {
                    highlightEffect = 0;
                    highlightEffectIncrease = true;
                }
            }
        }

        #endregion

        #endregion

        #region DRAW
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gainsboro);
            

            //Draw sprites in editing layer and behind
            for (int i = 0; i <= editingLayer; i++)
            {
                if (!parallaxEngine.worldLayers[i].IsExpired) parallaxEngine.worldLayers[i].Draw(gameTime, spriteBatch);
            }

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, Camera.GetViewMatrix(parallaxEngine.worldLayers[editingLayer].LayerParallax));

            //display sprite types on the screen next to sprites
            if (isSpriteTypeOverlayOn) DisplaySpriteTypes(spriteBatch);

            if (isMouseOverPlacedSprite && tempselectedSpriteIndex < parallaxEngine.worldLayers[editingLayer].layerSprites.Count) spriteBatch.Draw(boxOutlineTexture, parallaxEngine.worldLayers[editingLayer].layerSprites[tempselectedSpriteIndex].SpriteRectangle, Color.White);

            //highlight a selected sprite
            if (isExistingSpriteSelected)
            {
                spriteBatch.Draw(boxOutlineTexture, parallaxEngine.worldLayers[editingLayer].layerSprites[selectedSpriteIndex].SpriteRectangle, Color.Yellow);
            }

            //draw grid if enabled
            if (isWorldGridOn) GridDraw(spriteBatch);

            spriteBatch.End();
            
            //show layers nearer to camera if option flagged
            if (isShowNearerLayers)
            {
                int i = editingLayer+1;
                while (i < parallaxEngine.worldLayers.Count)
                {
                    if (!parallaxEngine.worldLayers[i].IsExpired) parallaxEngine.worldLayers[i].Draw(gameTime, spriteBatch);
                    i++;
                }
            }

            #region DRAW OVERLAY COMPONENTS
            //Draw all overlay components in this SpriteBatch
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Camera.GetViewMatrix(Vector2.One));
           
            //draws selected sprite under mouse cursor, and halo it, if the mouse cursor is on the screen 
            //(placementSprite.Location is set to mouse position (snap or free) at each update
            if (!isMouseOverPlacedSprite) DrawMouseCursorSprite(gameTime, spriteBatch);

            //draw text overlay if enabled
            if (isTextOverlayOn) TextOverlayDraw(spriteBatch);

            spriteBatch.End();
            
           
            #endregion


           
            base.Draw(gameTime);
        }

        #region DRAW HELPER METHODS

        private void DrawMouseCursorSprite(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Camera.Viewport.Contains(new Rectangle((int)(ms.X + Camera.Position.X), (int)(ms.Y + Camera.Position.Y), 1, 1)))
            {
                placementSprite.Location += parallaxOffset;
                placementSprite.Draw(gameTime, spriteBatch);
                if (isPlacementBlocked) spriteBatch.Draw(boxOutlineTexture, placementSprite.SpriteRectangle, Color.Red);
                else spriteBatch.Draw(boxOutlineTexture, placementSprite.SpriteRectangle, Color.GreenYellow);
                placementSprite.Location -= parallaxOffset;
            }
            return;
        }

        private void GridDraw(SpriteBatch spriteBatch)
        {
            if (isWorldGridOn)
            {
                float layerWidth = (float)Camera.ViewportWidth + (parallaxEngine.worldLayers[editingLayer].LayerParallax.X * ((float)Camera.WorldRectangle.Width - (float)Camera.ViewportWidth));
                float layerHeight = (float)Camera.ViewportHeight + (parallaxEngine.worldLayers[editingLayer].LayerParallax.Y * ((float)Camera.WorldRectangle.Height - (float)Camera.ViewportHeight));
    
                for (int y = 0; y < ((layerHeight/worldGridTileHeight +1)); y++)
                {
                    for (int x = 0; x < ((layerWidth / worldGridTileWidth) + 1); x++)
                    {
                        if (Camera.IsObjectVisible(new Rectangle(x * worldGridTileWidth, y * worldGridTileHeight, worldGridTileWidth, worldGridTileHeight),parallaxEngine.worldLayers[editingLayer].LayerParallax))
                        {
                        spriteBatch.Draw(worldGridTexture,
                            new Rectangle(x * worldGridTileWidth, y * worldGridTileHeight, worldGridTileWidth, worldGridTileHeight),
                            Color.Black * 0.2f);
                        }
                    }
                }
            }
            return;
        }

        private void DisplaySpriteTypes(SpriteBatch spriteBatch)
        {
            
            foreach (Sprite sprite in parallaxEngine.worldLayers[editingLayer].layerSprites)
            {
                if (sprite.SpriteType != "NONE")
                    DrawStringHelper(spriteBatch, spriteFont,sprite.SpriteType.ToString(), new Vector2(sprite.SpriteRectangle.X, sprite.SpriteRectangle.Y));
            }
            return;
        }

        private void TextOverlayDraw(SpriteBatch spriteBatch)
        {
            DrawStringHelper(spriteBatch, spriteFont, "World Size : " + Camera.WorldRectangle.ToString(), new Vector2(Camera.Position.X + 0, Camera.Position.Y + 2));
            DrawStringHelper(spriteBatch, spriteFont, "Camera Viewport : " + Camera.Viewport.ToString(), new Vector2(Camera.Position.X+0, Camera.Position.Y+ 14));
            DrawStringHelper(spriteBatch, spriteFont, "Layers In Level :" + parallaxEngine.worldLayers.Count.ToString(), new Vector2(Camera.Position.X + 0, Camera.Position.Y + 28));
            DrawStringHelper(spriteBatch, spriteFont, "Sprites in Layer : " + parallaxEngine.worldLayers[editingLayer].LayerName + " : " + parallaxEngine.worldLayers[editingLayer].SpriteCount.ToString(), new Vector2(Camera.Position.X + 0, Camera.Position.Y + 40));
            return;
        }

        private  void DrawStringHelper(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, text, new Vector2(1, 1) + position, Color.Black);
            spriteBatch.DrawString(spriteFont, text, new Vector2(-1, 1) + position, Color.Black);
            spriteBatch.DrawString(spriteFont, text, new Vector2(1, -1) + position, Color.Black);
            spriteBatch.DrawString(spriteFont, text, new Vector2(-1, -1) + position, Color.Black);
            spriteBatch.DrawString(spriteFont, text, position, Color.White);
        }
        #endregion

        #endregion

        #region NEW/LOAD/SAVE MAP METHODS

        public void NewMap(string _loadFilePath, int _tileWidth, int _tileHeight, int _tilesWide, int _tilesHigh)
        {


            worldGridTileWidth = _tileWidth;
            worldGridTileHeight = _tileHeight;
            worldGridMapWidth = _tilesWide;
            worldGridMapHeight = _tilesHigh;
            worldWidth = worldGridTileWidth * worldGridMapWidth;
            worldHeight = worldGridTileHeight * worldGridMapHeight;
            Camera.WorldRectangle = new Rectangle(0, 0, worldWidth, worldHeight);
            Camera.LookAt(new Vector2(0, (worldHeight - Camera.ViewportHeight)));
            world = 0;
            level = 0;
            
            //in the New Map function, a texture pack file was opened in the editor and that path passed here.
            //the texture pack file is just like a level file except it only contains instructions to load a list of textures
            LoadMap(_loadFilePath);
            Layer newLayer = new Layer("layer 0");
            parallaxEngine.AddLayerToWorld(newLayer);
            editingLayer = 0;
        }

        //TODO write subroutine that will drop unused textures from the list and renumber existing sprites accordingly
        public void SaveMap(string startPath)
        {
            DeactivateSprites();
            FileStream fs = new FileStream(startPath + "\\Levels\\" + world.ToString() + "_" + level.ToString() + ".lvl", FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine("<WORLD>"); 
            writer.WriteLine("World:" + world);
            writer.WriteLine("Level:" + level);
            writer.WriteLine("WorldGridTileWidth:" + worldGridTileWidth);
            writer.WriteLine("WorldGridTileHeight:" + worldGridTileHeight);
            writer.WriteLine("WorldGridMapWidth:" + worldGridMapWidth);
            writer.WriteLine("WorldGridMapHeight:" + worldGridMapHeight);
            writer.WriteLine("TexturePack:" + texturePack);
            writer.WriteLine("<ENDWORLD>");
            writer.WriteLine("");

            //foreach (TextureData texture in LevelDataManager.levelTextures)
            //{
            //    writer.WriteLine("<TEXTUREDATA>");
            //    writer.WriteLine("FilePath:" + texture.FilePath);
            //    writer.WriteLine("FileName:" + texture.FileName);
            //    writer.WriteLine("TextureID:" + texture.TextureID);
            //    writer.WriteLine("SpriteType:" + texture.SpriteType);
            //    writer.WriteLine("IsTiled:" + texture.IsTiled);
            //    writer.WriteLine("IsAnimated:" + texture.IsAnimated);
            //    writer.WriteLine("TileWidth:" + texture.TileWidth);
            //    writer.WriteLine("TileHeight:" + texture.TileHeight);
            //    writer.WriteLine("<ENDTEXTUREDATA>");
            //   writer.WriteLine("");
            //}

            foreach (Layer layer in parallaxEngine.worldLayers)
            {
                writer.WriteLine("<LAYER>");
                writer.WriteLine("LayerName:" + layer.LayerName);
                writer.WriteLine("LayerParallax:" + layer.LayerParallax);
                //writer.WriteLine("IsAwake:" + layer.IsAwake);
                //writer.WriteLine("IsVisible:" + layer.IsVisible);
                //writer.WriteLine("IsLayerMotion:" + layer.IsLayerMotion);
                //writer.WriteLine("LayerVelocity:" + layer.LayerVelocity);
                //writer.WriteLine("LayerVDirection:" + layer.LayerVDirection);
                //writer.WriteLine("IsLayerGravity:" + layer.IsLayerGravity);
                //writer.WriteLine("LayerAcceleration:" + layer.LayerAcceleration);
                //writer.WriteLine("LayerADirection:" + layer.LayerADirection);
                writer.WriteLine("<ENDLAYER>");
                writer.WriteLine("");

                foreach (Sprite sprite in layer.layerSprites)
                {
                    writer.WriteLine("<SPRITE>");
                    //writer.WriteLine("SpriteType:" + sprite.SpriteType);
                    writer.WriteLine("ID:" + sprite.TextureID);
                    writer.WriteLine("Index:" + sprite.TextureIndex);
                    writer.WriteLine("Rect:" + sprite.SpriteRectangle);
                    //writer.WriteLine("Tint:" + sprite.TintColor);
                    if (sprite.IsFlippedHorizontally) writer.WriteLine("FlipH:" + sprite.IsFlippedHorizontally);
                    if (sprite.IsFlippedVertically) writer.WriteLine("FlipV:" + sprite.IsFlippedVertically);
                    //writer.WriteLine("IsAwake:" + sprite.IsAwake);
                    //writer.WriteLine("IsVisible:" + sprite.IsVisible);
                    //writer.WriteLine("IsCollidable:" + sprite.IsCollidable);
                    //writer.WriteLine("CollisionRadius:" + sprite.CollisionRadius);
                    //writer.WriteLine("IsMobile:" + sprite.IsMobile);
                    //writer.WriteLine("Velocity:" + sprite.Velocity);
                    //writer.WriteLine("Direction:" + sprite.Direction);
                    //writer.WriteLine("IsRotating:" + sprite.IsRotating);
                    //writer.WriteLine("RotationSpeed:" + sprite.RotationSpeed);
                    if (sprite.TotalRotation != 0) writer.WriteLine("Rot:" + sprite.TotalRotation);
                    if (sprite.HitPoints != 0) writer.WriteLine("HP:" + sprite.HitPoints);
                    if (sprite.TimeDelay != 0) writer.WriteLine("Timer:" + sprite.TimeDelay);
                    //writer.WriteLine("Scale:" + sprite.Scale);
                    //writer.WriteLine("IsAnimated:" + sprite.IsAnimated);
                    //writer.WriteLine("IsAnimatedWhileStopped:" + sprite.IsAnimatedWhileStopped);
                    //writer.WriteLine("IsBounceAnimated:" + sprite.IsBounceAnimated);
                    //writer.WriteLine("AnimationFPS:" + sprite.AnimationFPS);
                    if (sprite.pathing != Sprite.Pathing.None)
                    {
                        writer.WriteLine("Path:" + (int)sprite.pathing);
                        writer.WriteLine("PathX:" + sprite.PathingRadiusX);
                        writer.WriteLine("PathY:" + sprite.PathingRadiusY);
                        writer.WriteLine("PathSp:" + sprite.PathingSpeed);
                        writer.WriteLine("Path%:" + sprite.PathingPercentComplete);
                        writer.WriteLine("PathI:" + sprite.IsPathingInertia);
                    }
                    writer.WriteLine("<ENDSPRITE>");
                    writer.WriteLine("");
                }
            }
            writer.WriteLine("<ENDFILE>");
            writer.Close();
            fs.Close();

            return;
        }

        public void LoadMap(string _loadFilePath)
        {
            //reset parallax game engine
            parallaxEngine = new ParallaxManager(this);
            Camera.Move(new Vector2(-Camera.Position.X, -Camera.Position.Y + worldHeight - Camera.ViewportHeight - Camera.Position.Y));  //set camera to bottom left
            LevelDataManager.Unload();
            spriteFont = Content.Load<SpriteFont>(@"Fonts\Moire");
            worldGridTexture = Content.Load<Texture2D>(@"defaultTextures\grid");
            boxOutlineTexture = Content.Load<Texture2D>(@"defaultTextures\outline");
            boxHighlightTexture = Content.Load<Texture2D>(@"defaultTextures\highlight");

            LoadWorld(_loadFilePath);
            LoadTextures(Content.RootDirectory + texturePack);

            FileStream fs = new FileStream(_loadFilePath, FileMode.Open);
            StreamReader read = new StreamReader(fs);
            string data = read.ReadLine();
            do
            {
                switch (data)
                {
                    case "<LAYER>":
                        LoadLayerData(read);
                        break;
                    case "<SPRITE>":
                        LoadSpriteData(read);
                        break;
                    default: 
                        break;
                }

                data = read.ReadLine();
            } while (data != "<ENDFILE>");


            read.Close();
            fs.Close();

            

            //reset variables
            editingLayer = parallaxEngine.worldLayers.Count-1;
            placementSprite = new Sprite(0, 0, Vector2.Zero);
            isPlacementBlocked = false;
            placementBlockingSprites = new List<Sprite>();
            isMouseOverPlacedSprite = false;
            isExistingSpriteSelected = false;
            selectedSpriteIndex = 0;
            tempselectedSpriteIndex = 0;

            return;

        }

        public void LoadWorld(string _loadFilePath)
        {
            FileStream fs = new FileStream(_loadFilePath, FileMode.Open);
            StreamReader read = new StreamReader(fs);
            string data = read.ReadLine();
            do
            {
                switch (data)
                {
                    case "<WORLD>":
                        LoadWorldData(read);
                        break;
                    default:
                        break;
                }

                data = read.ReadLine();
            } while (data != "<ENDFILE>");


            read.Close();
            fs.Close();
            return;
        }

        public void LoadTextures(string _loadFilePath)
        {
            FileStream fs = new FileStream(_loadFilePath, FileMode.Open);
            StreamReader read = new StreamReader(fs);
            string data = read.ReadLine();
            do
            {
                switch (data)
                {
                    case "<TEXTUREDATA>":
                        LoadTextureData(read);
                        break;
                    default:
                        break;
                }

                data = read.ReadLine();
            } while (data != "<ENDFILE>");
            read.Close();
            fs.Close();
            return;
        }

        public void LoadWorldData(StreamReader read)
        {
            string line = read.ReadLine();
            string elementName = null;
            do
            {
                string[] stringSeparators = new string[] { ":" };
                string[] result = line.Split(stringSeparators,
                StringSplitOptions.RemoveEmptyEntries);
                elementName = result[0];
  
                switch (elementName)
                {
                    case "World":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) world = value;
                            break;
                        }
                    case "Level":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) level = value;
                            break;
                        }
                    case "WorldGridTileWidth":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) worldGridTileWidth = value;
                            break;
                        }
                    case "WorldGridTileHeight":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) worldGridTileHeight = value;
                            break;
                        }
                    case "WorldGridMapWidth":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) worldGridMapWidth = value;
                            break;
                        }
                    case "WorldGridMapHeight":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) worldGridMapHeight = value;
                            break;
                        }
                    case "TexturePack":
                        {
                            texturePack = result[1];
                            break;
                        }
                    default:
                        break;
                }     
                line = read.ReadLine();
            } while (line != "<ENDWORLD>");

            worldWidth = worldGridTileWidth * worldGridMapWidth;
            worldHeight = worldGridTileHeight * worldGridMapHeight;
            Camera.WorldRectangle = new Rectangle(0, 0, worldWidth, worldHeight);
            Camera.LookAt( new Vector2(0, (worldHeight - Camera.ViewportHeight)));

            return;
        }

        public void LoadTextureData(StreamReader read)
        {
            //variables to initialize new TextureData when read in
            string filePath = null;
            string fileName = null;
            int textureID = -1;
            string spriteType = "";
            bool isTiled = false;
            bool isAnimated = false;
            int tileWidth = 0;
            int tileHeight = 0;

            string line = read.ReadLine();
            string elementName = null;
         
            do
            {
                string[] stringSeparators = new string[] { ":" };
                string[] result = line.Split(stringSeparators,
                StringSplitOptions.RemoveEmptyEntries);
                elementName = result[0];

                switch (elementName)
                {
                    case "FilePath":
                        {
                            filePath = result[1];
                            break;
                        }
                    case "FileName":
                        {
                            fileName = result[1];
                            break;
                        }
                    case "TextureID":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) textureID = value;
                            break;
                        }
                    case "SpriteType":
                        {
                            if (result.Length > 1) spriteType = result[1];
                            break;
                        }
                    case "IsTiled":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isTiled = value;
                            break;
                        }
                    case "IsAnimated":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isAnimated = value;
                            break;
                        }
                    case "TileWidth":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) tileWidth = value;
                            break;
                        }
                    case "TileHeight":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) tileHeight = value;
                            break;
                        }
                    default:
                        break;
                }
                line = read.ReadLine();
            } while (line != "<ENDTEXTUREDATA>");

            TextureData textureData = new TextureData(filePath, fileName, textureID, spriteType, isTiled, isAnimated, tileWidth, tileHeight);
            LevelDataManager.Load(textureData);

            return;
        }

        public void LoadLayerData(StreamReader read)
        {
            //variables to initialize new Layer when read in
            string layerName = "";
            Vector2 layerParallax = new Vector2 (1f, 0f);
            bool isAwake = true;
            bool isVisible = true;
            bool isLayerMotion = false;
            float layerVelocity = 0.0f; 
            Vector2 layerVDirection = Vector2.Zero; 
            bool isLayerGravity = false;  
            float layerAcceleration = 0.0f; 
            Vector2 layerADirection = Vector2.UnitY;

            string line = read.ReadLine();
            string elementName = null;
         
            do
            {
                string[] stringSeparators = new string[] { ":" };
                string[] result = line.Split(stringSeparators,
                StringSplitOptions.RemoveEmptyEntries);
                elementName = result[0];

                switch (elementName)
                {
                    case "LayerName":
                        {
                            layerName = result[1];
                            break;
                        }
                    case "LayerParallax":
                        {
                            float x=1.0f;
                            float y=1.0f;
                            if (result[1] == "{X")
                            {
                                float value;
                                string temp;
                                temp = result[2].Replace(" Y", null);
                                if (float.TryParse(temp, out value)) x = value;
                                temp = result[3].Replace("}", null);
                                if (float.TryParse(temp, out value)) y = value;
                            }
                            layerParallax = new Vector2(x, y);
                            break;
                        }
                    case "IsAwake":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isAwake = value;
                            break;
                        }
                    case "IsVisible":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isVisible = value;
                            break;
                        }
                    case "IsLayerMotion":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isLayerMotion = value;
                            break;
                        }
                    case "LayerVelocity":
                        {
                            float value;
                            if (float.TryParse(result[1], out value)) layerVelocity = value;
                            break;
                        }
                    case "LayerVDirection":
                        {
                            float x = 1.0f;
                            float y = 1.0f;
                            if (result[1] == "{X")
                            {
                                float value;
                                string temp;
                                temp = result[2].Replace(" Y", null);
                                if (float.TryParse(temp, out value)) x = value;
                                temp = result[3].Replace("}", null);
                                if (float.TryParse(temp, out value)) y = value;
                            }
                            layerVDirection = new Vector2(x, y);
                            break;
                        }
                    case "IsLayerGravity":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isLayerGravity = value;
                            break;
                        }
                    case "LayerAcceleration":
                        {
                            float value;
                            if (float.TryParse(result[1], out value)) layerAcceleration = value;
                            break;
                        }
                    case "LayerADirection":
                        {
                            float x = 1.0f;
                            float y = 1.0f;
                            if (result[1] == "{X")
                            {
                                float value;
                                string temp;
                                temp = result[2].Replace(" Y", null);
                                if (float.TryParse(temp, out value)) x = value;
                                temp = result[3].Replace("}", null);
                                if (float.TryParse(temp, out value)) y = value;
                            }
                            layerADirection = new Vector2(x, y);
                            break;
                        }
                    default:
                        break;
                }
                line = read.ReadLine();
            } while (line != "<ENDLAYER>");

            Layer newLayer = new Layer(layerName,layerParallax,isAwake,isVisible,isLayerMotion,layerVelocity,layerVDirection,isLayerGravity,layerAcceleration,layerADirection);
            parallaxEngine.AddLayerToWorld(newLayer);

            return;
        }

        public void LoadSpriteData(StreamReader read)
        {
            //variables to initialize new Sprite, defaluts changed when read in
            string spriteType = "NONE";
            int textureID = 0;
            int textureIndex = 0;
            Rectangle spriteRectangle = new Rectangle(0, 0, 1, 1); //calls property to also set location
            Color tintColor = Color.White;
            bool isFlippedHorizontally = false;
            bool isFlippedVertically = false;
            bool isAwake = false;
            bool isVisible = true;
            bool isCollidable = false;
            int hitPoints = 0;
            bool isMobile = false;
            float velocity = 0.0f;
            Vector2 direction = Vector2.Zero;
            bool isRotating = false;
            float rotationSpeed = 0.0f;
            float totalRotation = 0.0f;
            float scale = 1.0f;
            bool isAnimated = false;
            bool isAnimatedWhileStopped = false;
            bool isBounceAnimated = false;
            float animationFPS = 0.0f;
            Sprite.Pathing pathingType = Sprite.Pathing.None;
            int pathingX = 0;
            int pathingY = 0;
            int pathingSpeed = 0;
            int pathingStart = 0;
            bool isPathingInertia = false;
            float timerDelay = 0f;


            string line = read.ReadLine();
            string elementName = null;

            do
            {
                string[] stringSeparators = new string[] { ":" };
                string[] result = line.Split(stringSeparators,
                StringSplitOptions.RemoveEmptyEntries);
                elementName = result[0];

                switch (elementName)
                {
                    case "SpriteType":
                        {
                            if (result.Length > 1 ) spriteType = result[1];
                            break;
                        }
                    case "ID":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) textureID = value;
                            break;
                        }
                    case "Index":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) textureIndex = value;
                            break;
                        }
                    case "Rect":
                        {
                            int x = 1;
                            int y = 1;
                            int width = 2;
                            int height = 2;
                            string temp;
                            if (result[1] == "{X")
                            {
                                int value = 1;
                                temp = result[2].Replace(" Y", null);
                                if (int.TryParse(temp, out value)) x = value;
                                temp = result[3].Replace(" Width", null);
                                if (int.TryParse(temp, out value)) y = value;
                                temp = result[4].Replace(" Height", null);
                                if (int.TryParse(temp, out value)) width = value;
                                temp = result[5].Replace("}", null);
                                if (int.TryParse(temp, out value)) height = value;
                            }
                            spriteRectangle = new Rectangle(x, y, width, height); 
                            break;
                        }
                    case "Tint":
                        {
                            float r = 255;
                            float g = 255;
                            float b = 255;
                            float a = 255;
                            string temp;
                            if (result[1] == "{R")
                            {
                                float value = 255;
                                temp = result[2].Replace(" G", null);
                                if (float.TryParse(temp, out value)) r = value;
                                temp = result[3].Replace(" B", null);
                                if (float.TryParse(temp, out value)) g = value;
                                temp = result[4].Replace(" A", null);
                                if (float.TryParse(temp, out value)) b = value;
                                temp = result[5].Replace("}", null);
                                if (float.TryParse(temp, out value)) a = value;
                            }
                            a = a / 255; r = r / 255; g = g / 255; b = b / 255;
                            tintColor = new Color(r,g,b,a);
                            break;
                        }
                    case "FlipH":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isFlippedHorizontally = value;
                            break;
                        }
                    case "FlipV":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isFlippedVertically = value;
                            break;
                        }
                    case "IsAwake":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isAwake = value;
                            break;
                        }
                    case "IsVisible":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isVisible = value;
                            break;
                        }
                    case "IsCollidable":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isCollidable = value;
                            break;
                        }
                    case "HP":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) hitPoints = value;
                            break;
                        }
                    case "IsMobile":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isMobile = value;
                            break;
                        }
                    case "Velocity":
                        {
                            float value;
                            if (float.TryParse(result[1], out value)) velocity = value;
                            break;
                        }
                    case "Direction":
                        {
                            float x = 0.0f;
                            float y = 0.0f;
                            if (result[1] == "{X")
                            {
                                float value;
                                string temp;
                                temp = result[2].Replace(" Y", null);
                                if (float.TryParse(temp, out value)) x = value;
                                temp = result[3].Replace("}", null);
                                if (float.TryParse(temp, out value)) y = value;
                            }
                            direction = new Vector2(x, y);
                            break;
                        }
                    case "IsRotating":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isRotating = value;
                            break;
                        }
                    case "RotationSpeed":
                        {
                            float value;
                            if (float.TryParse(result[1], out value)) rotationSpeed = value;
                            break;
                        }
                    case "Rot":
                        {
                            float value;
                            if (float.TryParse(result[1], out value)) totalRotation = value;
                            break;
                        }
                    case "Timer":
                        {
                            float value;
                            if (float.TryParse(result[1], out value)) timerDelay = value;
                            break;
                        }
                    case "Scale:":
                        {
                            float value;
                            if (float.TryParse(result[1], out value)) scale = value;
                            break;
                        }
                    case "IsAnimated":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isAnimated = value;
                            break;
                        }
                    case "IsAnimatedWhileStopped":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isAnimatedWhileStopped = value;
                            break;
                        }
                    case "IsBounceAnimated":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isBounceAnimated = value;
                            break;
                        }
                    case "AnimationFPS":
                        {
                            float value;
                            if (float.TryParse(result[1], out value)) animationFPS = value;
                            break;
                        }
                    case "Path":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) pathingType = (Sprite.Pathing)value;
                            break;
                        }
                    case "PathX":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) pathingX = value;
                            break;
                        }
                    case "PathY":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) pathingY = value;
                            break;
                        }
                    case "PathSp":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) pathingSpeed = value;
                            break;
                        }
                    case "Path%":
                        {
                            int value;
                            if (int.TryParse(result[1], out value)) pathingStart = value;
                            break;
                        }
                    case "PathI":
                        {
                            bool value;
                            if (bool.TryParse(result[1], out value)) isPathingInertia = value;
                            break;
                        } 
                    default:
                        break;
                }
                line = read.ReadLine();
            } while (line != "<ENDSPRITE>");

            Sprite newSprite = new Sprite(spriteType, textureID, textureIndex, spriteRectangle, tintColor, isFlippedHorizontally, isFlippedVertically,
                                          isAwake, isVisible, isCollidable, hitPoints, isMobile, velocity, direction,
                                          isRotating, rotationSpeed, totalRotation, scale, isAnimated, isAnimatedWhileStopped, isBounceAnimated, animationFPS,
                                          pathingType, pathingX, pathingY, pathingSpeed, pathingStart, isPathingInertia,timerDelay);
            //set up pathing
            newSprite.InitPathingPoint();
            if (newSprite.pathing != Sprite.Pathing.None) newSprite.InitializePathing();

            parallaxEngine.worldLayers[parallaxEngine.worldLayers.Count-1].AddSpriteToLayer(newSprite);

            return;
        }
        #endregion

        #region FUNCTIONS
        public void ActivateSprites()
        {
            DeactivateSprites();
            for( int x = 0; x < parallaxEngine.worldLayers.Count; x++)
            {
                for (int y = 0; y < parallaxEngine.worldLayers[x].layerSprites.Count; y++ )
                {
                    //if pathed, awaken and initialize pathing variables
                    if (parallaxEngine.worldLayers[x].layerSprites[y].pathing != Sprite.Pathing.None)
                    {
                        parallaxEngine.worldLayers[x].layerSprites[y].InitializePathing();
                        parallaxEngine.worldLayers[x].layerSprites[y].IsAwake = true;
                    }
                }
            }
            return;
        }

        public void DeactivateSprites()
        {
            for (int x = 0; x < parallaxEngine.worldLayers.Count; x++)
            {
                for (int y = 0; y < parallaxEngine.worldLayers[x].layerSprites.Count; y++)
                {
                    parallaxEngine.worldLayers[x].layerSprites[y].IsAwake = false;

                    //if pathed, reset location to origin point
                    if (parallaxEngine.worldLayers[x].layerSprites[y].pathing != Sprite.Pathing.None)
                    {
                        parallaxEngine.worldLayers[x].layerSprites[y].Location = parallaxEngine.worldLayers[x].layerSprites[y].pathingPoints[0];
                    }

                }
            }
            return;

        }
        #endregion

    }
}
