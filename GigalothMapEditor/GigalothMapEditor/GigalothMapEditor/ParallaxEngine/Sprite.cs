using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;



namespace ParallaxEngine
{
    //Sprites must be initialized after the Level Texture Manager has loaded textures
    public class Sprite
    {
        #region DECLARATIONS
        
        //set to subclass name or "Player" or "Enemy" or "Terrain" or "Bullet" etc.
        //used by save/load methods to initialize subclass (if applicable) or put sprite data in the correct Lists etc. 
        //used by game methods to apply logic and behavior 
        protected string spriteType = "NONE";

        public enum SpriteState
        {
            None,
            Fruit,
            Coin
        };

        public SpriteState spriteState = SpriteState.None;

        //Texture Variables 
        //A Sprite uses calls to the Level Texture Manager class using ID and Index to retrieve texture and source rectangle for its draw function
        //Save/load data files also will use the ID and Index, initialized at (-1) means it was not explicitly set
        //to avoid crashes and detect bugs, the Level Texture Manager will return whitespace texture if either value is passed out of bounds
        protected int textureID = 0; //identifies which texture sheet the Level Texture Manager should use 
        protected int textureIndex = 0; //identifies where on a texture sheet the sprite is sourced from
        
        //Location and Draw Variables
        protected Rectangle spriteRectangle = new Rectangle (0,0,1,1);
        protected Vector2 location = Vector2.Zero;
        protected Color tintColor = Color.White;
        protected bool isFlippedHorizontally = false;
        protected bool isFlippedVertically = false;
        protected SpriteEffects spriteEffect = SpriteEffects.None;  //the spritebatch flipping variable


        //sprite physical state variables
        protected bool isAwake = false; //skip update if flagged false
        protected bool isVisible = true; //skip draw if flagged false
        protected bool isExpired = false; //when flagged for true, auto flags isAwake and isVisible to false, allows for disposal or reuse by game logic
        protected bool isCollidable = false;
        protected bool isHit = false;//used by the managers for sprite types
        protected int hitPoints = 0;//used by the managers for sprite types
        protected float timer = 0.0f; //used by the managers for sprite types
        protected float timeDelay = 0.0f;//total time for behaivior change, may come stored from editor for certain sprites
        public Body spriteBody;

        //Motion Variables 
        protected bool isMobile = false; //set to true if the sprite has velocity relative to game world, immovable if set false
        protected float velocity = 0.0f; //velocity units per second (pixels if traveling on axis)
        protected Vector2 direction = Vector2.Zero; //normalized direction vector, does not affect velocity only used for direction determination 

        //Rotation and Scaling Variables
        protected bool isRotating = false;  
        protected float rotationSpeed = 0.0f; // velocity of rotation in degrees per second units, negative is counterclockwise
        protected float totalRotation = 0.0f; //internal variable to track roatation and pass to draw method
        protected float scale = 1.0f; //sprite scale

        //Animation Variables
        protected bool isAnimated = false;
        protected bool isAnimatedWhileStopped = false;
        protected bool isBounceAnimated = false;  //will scroll back and forth on the animation row if true, will loop from end to beginning if false
        protected bool isAnimationDirectionForward = true; //internal flag to make bounce animation work
        protected int currentFrame = 0; //would be added to textureIndex with a call to the Level Texture Manager to retrieve source rect for animated sprites
        protected float animationFPS = 0.0f;
        protected float animationFramePrecise = 0.0f;

        //Behavior Variables
        public enum Pathing
        {
            None,
            Linear,
            Rectangle,
            Round,
            Fish,
            Bat,
            Spider,
            Bird,
            Gremlin
        };

        public Pathing pathing = Pathing.None;
        protected int pathingRadiusX = 0; //X distance on rounds or rects, x part of the slope on linear
        protected int pathingRadiusY = 0; //Y distance on round and rect pathing, y part of the slope on linear
        protected int pathingSpeed = 0;
        protected int pathingPercentComplete = 0; //used to calculate where on the path the initial position is
        public List<Vector2> pathingPoints;
        public int pathingPointsDestinationIndex = 0;
        protected bool isPathingInertia = false;
        public float pathingTravelled = 0f;



#endregion

    #region CONSTRUCTORS

        //Minimum constructor for sprite from a sprite sheet, LevelDataManager class manages the calls for a sprite's current texture
        public Sprite(int _textureID, int _textureIndex, Vector2 _location)
        {
            textureID = _textureID;
            textureIndex = _textureIndex;
            location = _location;
            spriteRectangle = new Rectangle ((int)_location.X,(int)_location.Y, 
                                            LevelDataManager.SpriteWidth(textureID),
                                            LevelDataManager.SpriteHeight(textureID));
        }

        public Sprite(string _type, int _ID, int _index, Rectangle _rect, Color _color, bool _fliph, bool _flipV, bool _awake, bool _visible,
                      bool _collide, int _hitPoints, bool _mobile, float _vel, Vector2 _dir, bool _rotating, float _rotspd, float _totrot, 
                      float _scale, bool _animated, bool _awhilestop, bool _bounce, float _fps,
                      Sprite.Pathing _pathing, int _pathX, int _pathY, int _pathspd, int _pathstart, bool _pathInert, float _timeDelay )
        {
            spriteType = _type;
            textureID = _ID;
            textureIndex = _index;
            SpriteRectangle = _rect; //calls property to also set location
            tintColor = _color;
            IsFlippedHorizontally = _fliph;
            if (!_fliph) IsFlippedVertically = _flipV;
            isAwake = _awake;
            isVisible = _visible;
            isCollidable = _collide;
            hitPoints = _hitPoints;
            isMobile = _mobile;
            velocity = _vel;
            direction = _dir;
            isRotating = _rotating;
            rotationSpeed = _rotspd;
            totalRotation = _totrot;
            scale = _scale;
            isAnimated = _animated;
            isAnimatedWhileStopped = _awhilestop;
            isBounceAnimated = _bounce;
            animationFPS = _fps;
            pathing = _pathing;
            pathingRadiusX = _pathX;
            pathingRadiusY = _pathY;
            pathingSpeed = _pathspd;
            pathingPercentComplete = _pathstart;
            isPathingInertia = _pathInert;
            timeDelay = _timeDelay;
        }

    #endregion


       


        #region UPDATE
        public void Update(GameTime gameTime)
        {
            if (!isAwake) return;

            //if (isMobile) UpdateMotion(gameTime);

            //if (isRotating) UpdateRotation(gameTime);

            if ((isAnimated && isAnimatedWhileStopped) || (isAnimated && isMobile && velocity !=0)) UpdateAnimation(gameTime);

            if (pathing != Pathing.None) UpdatePathing(gameTime);
        }

        private void UpdatePathing(GameTime gameTime)
        {
            if (pathing == Pathing.Linear || pathing == Pathing.Rectangle || pathing == Pathing.Spider || pathing == Pathing.Bat || pathing == Pathing.Bird || pathing == Pathing.Fish)
            {
                float distance = Math.Abs(pathingSpeed) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                float rangeX = pathingPoints[pathingPointsDestinationIndex].X - location.X;
                float rangeY = pathingPoints[pathingPointsDestinationIndex].Y - location.Y;
                float range = (float)Math.Sqrt((double)((rangeX * rangeX) + (rangeY * rangeY)));

                direction = new Vector2(rangeX / range, rangeY / range);

                if (isPathingInertia)
                {
                    if ((range >= (distance * 50f)) && (pathingTravelled >= (distance * 50f)))
                    {
                        location.X += (direction.X * distance);
                        location.Y += (direction.Y * distance);
                        pathingTravelled += distance;
                    }
                    else  //near one end or the pther of path so slow it down
                    {
                        if (range < (distance * 50f)) distance = range / 50f; //if at the end of the leg
                        if (pathingTravelled < (distance * 50f)) distance = Math.Max(pathingTravelled / 50f, 0.1f); //if at the beginning of the leg

                        location.X += (direction.X * distance);
                        location.Y += (direction.Y * distance);
                        pathingTravelled += distance;
                        if (range < 0.1f)
                        {
                            location.X = pathingPoints[pathingPointsDestinationIndex].X;
                            location.Y = pathingPoints[pathingPointsDestinationIndex].Y;
                            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                            if (timer >= timeDelay)
                            {
                                timer = 0f;
                                NextPathingPoint();
                            }
                        }
                    }
                }
                if (!isPathingInertia)
                {
                    if (range >= distance)
                    {
                        location.X += (direction.X * distance);
                        location.Y += (direction.Y * distance);
                    }
                    else
                    {
                        location.X = pathingPoints[pathingPointsDestinationIndex].X;
                        location.Y = pathingPoints[pathingPointsDestinationIndex].Y;
                        timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if (timer >= timeDelay)
                        {
                            timer = 0f;
                            NextPathingPoint();
                        }
                    }
                }

                spriteRectangle.X = (int)location.X;
                spriteRectangle.Y = (int)location.Y;
                return;
            }

            if (pathing == Pathing.Round || pathing == Pathing.Gremlin)
            {
                float distance = pathingSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                pathingTravelled += MathHelper.ToRadians(distance);
                Location = new Vector2(pathingPoints[1].X + (float)(Math.Cos(pathingTravelled) * pathingRadiusX / 2f),
                                        pathingPoints[1].Y + (float)(Math.Sin(pathingTravelled) * pathingRadiusY / 2f));
                if (pathingTravelled > 10f) pathingTravelled -= MathHelper.ToRadians(360);
                if (pathingTravelled < -10f) pathingTravelled += MathHelper.ToRadians(360);
                return;
            }
        }

        private void UpdateMotion(GameTime gameTime)
        {
            if (velocity != 0)
            {
                float distance = velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                location.X += (direction.X * distance);
                location.Y += (direction.Y * distance);
                spriteRectangle.X = (int)location.X;
                spriteRectangle.Y = (int)location.Y;
            }
        }

        private void UpdateRotation(GameTime gameTime)
        {
            if (rotationSpeed != 0)
            {
                totalRotation += (MathHelper.ToRadians(rotationSpeed) * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
        }

        private void UpdateAnimation(GameTime gameTime)
        {
            animationFramePrecise += (float)gameTime.ElapsedGameTime.TotalSeconds*animationFPS;
            if (animationFramePrecise >= 1.0f)
            {
                animationFramePrecise -= 1.0f;
                if (isAnimationDirectionForward)
                {

                    if (currentFrame+1 == LevelDataManager.SpritesInRow(textureID))
                    {
                        if (!isBounceAnimated) currentFrame = 0; //loop if not bounce animated
                        else
                        {
                            isAnimationDirectionForward = false; //send the other direction
                            currentFrame -= 1; //move to frame before 
                        }
                    }
                    else currentFrame += 1;
                }
                else
                {
                    if (currentFrame == 0)
                    {
                        if (!isBounceAnimated) currentFrame = LevelDataManager.SpritesInRow(textureID); //loop if not bounce animated
                        else
                        {
                            isAnimationDirectionForward = true; //send the other direction
                            currentFrame += 1; //move to frame before 
                        }
                    }
                    else currentFrame -= 1;
                }    
            }
        }

        #endregion



        #region DRAW
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!isVisible) return;

            //for rotation the center of the sprite must be added to the draw location since they rotate about the center
            if (isRotating || rotationSpeed != 0 || totalRotation != 0 || scale != 1.0)
            {
                spriteBatch.Draw(Texture,
                    SpriteCenterInWorld,
                    SourceRectangle, tintColor, totalRotation, SpriteOrigin, scale, spriteEffect, 0.0f);
            }
            else
            {
                spriteBatch.Draw(Texture, spriteRectangle, SourceRectangle,
                                 tintColor, 0.0f, Vector2.Zero, spriteEffect, 0.0f);
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 layerParallax)
        {
            if (!isVisible || !Camera.IsObjectVisible(spriteRectangle,layerParallax)) return;

            //for rotation the center of the sprite must be added to the draw location since they rotate about the center
            if (isRotating || rotationSpeed != 0 || totalRotation != 0 || scale != 1.0)
            {
                spriteBatch.Draw(Texture,
                    SpriteCenterInWorld,
                    SourceRectangle, tintColor, totalRotation, SpriteOrigin, scale, spriteEffect, 0.0f);
            }
            else
            {
                spriteBatch.Draw(Texture, spriteRectangle, SourceRectangle,
                                 tintColor, 0.0f, Vector2.Zero, spriteEffect, 0.0f);
            }

        }



        #endregion

        #region  PROPERTIES
        public string SpriteType
        {
            get { return this.spriteType; }
            set { if (value != null) this.spriteType = value; }
        }
        public int TextureID
        {
            get { return this.textureID; }
            set { this.textureID = value; }
        }
        public int TextureIndex
        {
            get { return this.textureIndex; }
            set { this.textureIndex = value; }
        }
        public Rectangle SpriteRectangle
        {
            get { return this.spriteRectangle; }
            set
            { 
                this.spriteRectangle = value;
                this.location = new Vector2 ( (float)spriteRectangle.X,(float)spriteRectangle.Y );
            }
        }
        public int SpriteRectWidth
        {
            get { return this.spriteRectangle.Width; }
            set { this.spriteRectangle.Width = value; }
        }
        public int SpriteRectHeight
        {
            get { return this.spriteRectangle.Height; }
            set { this.spriteRectangle.Height = value; }
        }
        public int TileWidth
        {
            get { return LevelDataManager.levelTextures[textureID].TileWidth; }
        }
        public int TileHeight
        {
            get { return LevelDataManager.levelTextures[textureID].TileHeight; }
        }
        public Vector2 Location
        { 
            get { return this.location; }
            set 
            { 
                this.location = value;
                this.spriteRectangle.X = (int)location.X;
                this.spriteRectangle.Y = (int)location.Y;
            }
        }
        public Color TintColor
        {
            get { return this.tintColor; }
            set 
            { 
                this.tintColor = value;
            }
        }
        public bool IsFlippedHorizontally 
        { 
            get { return this.isFlippedHorizontally; } 
            set 
            { 
                this.isFlippedHorizontally = value;
                if (this.isFlippedHorizontally)
                {
                    this.isFlippedVertically = false;
                    spriteEffect = SpriteEffects.FlipHorizontally;
                }
                if (!this.isFlippedHorizontally) spriteEffect = SpriteEffects.None;
            } 
        }
        public bool IsFlippedVertically 
        { 
            get { return this.isFlippedVertically; }
            set 
            { 
                this.isFlippedVertically = value;
                if (this.isFlippedVertically)
                {
                    this.isFlippedHorizontally = false;
                    spriteEffect = SpriteEffects.FlipVertically;
                }
                if (!this.isFlippedVertically) spriteEffect = SpriteEffects.None;
            } 
        }
        public SpriteEffects SpriteEffect { get { return this.spriteEffect; } set { this.spriteEffect = value; } }
        public bool IsAwake { get { return this.isAwake; } set { this.isAwake = value; } }
        public bool IsVisible { get { return this.isVisible; } set { this.isVisible = value; } }
        public bool IsExpired 
        { 
            get { return this.isExpired; }
            set 
            { 
                IsAwake = false;
                IsVisible = false;
                this.isExpired = value;
            }
        }
        public bool IsHit { get { return this.isHit; } set { this.isHit = value; } }
        public int HitPoints { get { return this.hitPoints; } set { this.hitPoints = value; } }
        public float Timer { get { return this.timer; } set { this.timer = value; } }
        public float TimeDelay { get { return this.timeDelay; } set { this.timeDelay = value; } }
        public bool IsCollidable { get { return this.isCollidable; } set { this.isCollidable = value; } }
        public bool IsMobile{ get { return this.isMobile; } set { this.isMobile = value; } }
        public float Velocity { get { return this.velocity; } set { this.velocity = value; } }
        public Vector2 Direction
        {
            get { return this.direction; }
            set
            {
                this.direction = value;
                if (direction != Vector2.Zero)
                {
                    direction.Normalize();
                }
            }
        }
        public bool IsRotating { get { return this.isRotating; } set { this.isRotating = value; } }
        public float RotationSpeed { get { return this.rotationSpeed; } set { this.rotationSpeed = value; } }
        public float TotalRotation { get { return this.totalRotation; } set { this.totalRotation = value; } }
        public float Scale
        {
            get { return this.scale; }
            set { this.scale = value; }
        }

        //animation
        public bool IsAnimated { get { return this.isAnimated; } set { this.isAnimated = value; } }
        public bool IsAnimatedWhileStopped { get { return this.isAnimatedWhileStopped; } set { this.isAnimatedWhileStopped = value; } }
        public bool IsBounceAnimated { get { return this.isBounceAnimated; } set { this.isBounceAnimated = value; } }
        public int CurrentFrame { get { return this.currentFrame; } set { if (value >= 0) this.currentFrame = value; } }
        public float AnimationFPS { get { return this.animationFPS; } set { this.animationFPS = value; } }

        //Pathing
        public int PathingRadiusX { get { return this.pathingRadiusX; } set { this.pathingRadiusX = value; } }
        public int PathingRadiusY { get { return this.pathingRadiusY; } set { this.pathingRadiusY = value; } }
        public int PathingSpeed { get { return this.pathingSpeed; } set { this.pathingSpeed = value; } }
        public int PathingPercentComplete { get { return this.pathingPercentComplete; } set { this.pathingPercentComplete = value; } }
        public bool IsPathingInertia { get { return this.isPathingInertia; } set { this.isPathingInertia = value; } }



        #endregion

        #region READ ONLY PROPERTIES
        public Texture2D Texture { get { return LevelDataManager.GetSourceTexture(textureID); } }
        public bool[,] GetCollisionData { get { return LevelDataManager.GetCollisionData(textureID, textureIndex); } }

        public Rectangle SourceRectangle { 
            get 
            {
                return LevelDataManager.GetSourceRect(textureID, textureIndex+currentFrame);
            }
        }

        public Vector2 SpriteCenterInWorld
        {
            get 
            { 
                return ( new Vector2 
                    ( location.X + ((spriteRectangle.Width)/2.0f)  , 
                      location.Y + ((spriteRectangle.Height)/2.0f)  ) );
            }
        }

        //Returns a vector represented center of sprite from the top left corner of sprite
        public Vector2 SpriteOrigin
        {
            get
            {
                return (new Vector2( ((spriteRectangle.Width) / 2.0f),((spriteRectangle.Height)/ 2.0f)));
            }
        }


        #endregion

        #region CLONE
        public Sprite Clone()
        {
            Sprite data = new Sprite(this.TextureID,this.textureIndex,this.location);

            data.spriteType = this.spriteType;

            data.textureID = this.textureID;
            data.textureIndex = this.textureIndex;

            data.spriteRectangle = this.spriteRectangle;
            data.location = this.location;
            data.tintColor = this.tintColor;
            data.isFlippedHorizontally = this.isFlippedHorizontally;
            data.isFlippedVertically = this.isFlippedVertically;
            data.SpriteEffect = this.SpriteEffect;

            data.isAwake = this.isAwake;
            data.isVisible = this.isVisible;
            data.isExpired = this.isExpired;
            data.isCollidable = this.isCollidable;
            data.isHit = this.isHit;
            data.hitPoints = this.hitPoints;
            data.timer = this.timer;
            data.timeDelay = this.timeDelay;

            data.isMobile = this.isMobile;
            data.velocity = this.velocity;
            data.direction = this.direction;

            data.isRotating = this.isRotating;
            data.rotationSpeed = this.rotationSpeed;
            data.totalRotation = this.totalRotation;
            data.scale = this.scale;

            data.isAnimated = this.isAnimated;
            data.isAnimatedWhileStopped = this.isAnimatedWhileStopped;
            data.isBounceAnimated = this.isBounceAnimated;
            data.isAnimationDirectionForward = this.isAnimationDirectionForward;
            data.currentFrame = this.currentFrame;
            data.animationFPS = this.animationFPS;
            data.animationFramePrecise = this.animationFramePrecise;

            data.pathing = this.pathing;
            data.pathingRadiusX = this.pathingRadiusX;
            data.pathingRadiusY = this.pathingRadiusY;
            data.pathingSpeed = this.pathingSpeed;
            data.pathingPercentComplete = this.pathingPercentComplete;
            data.pathingPoints = this.pathingPoints;
            data.pathingPointsDestinationIndex = this.pathingPointsDestinationIndex;
            data.isPathingInertia = this.isPathingInertia;


            return data;
        }
#endregion

        #region PHYSICS


        public void UpdateSpriteFromPhysics()
        {
            this.Location = ConvertUnits.ToDisplayUnits(this.spriteBody.Position) - this.SpriteOrigin;
            this.TotalRotation = this.spriteBody.Rotation;
        }

        public void RemoveBody(World world)
        {
            world.RemoveBody(this.spriteBody);
            ActivatePhysics(world);
            return;
        }

        public void ActivatePhysics(World physicsWorld)
        {
            foreach (Body body in physicsWorld.BodyList)
            {
                body.Awake = true;
            }
            return;
        }
        #endregion

        #region PATHING 
        public void InitPathingPoint()
        {
            pathingPoints = new List<Vector2>(1);
            pathingPoints.Add(this.Location);
            return;
        }



        public void InitializePathing()
        {

            if (pathing == Pathing.Linear || pathing == Pathing.Spider || pathing == Pathing.Bat || pathing == Pathing.Bird || pathing == Pathing.Fish)
            {
                pathingSpeed = Math.Abs(pathingSpeed); //pathing speed must be a positive number for this path type

                //set the pathing points for Linear
                if (pathing == Pathing.Linear)
                {
                    pathingPoints = new List<Vector2>(2);
                    pathingPoints.Add(new Vector2(Location.X, Location.Y));
                    pathingPoints.Add(new Vector2(Location.X + (float)pathingRadiusX, Location.Y + (float)pathingRadiusY));
                }

                //set the pathing points for Spider
                //pathingY is the distance and pathingX variable effect set to 0 (spiders only move vertically, and only down then up thus pathingY always positive)
                if (pathing == Pathing.Spider)
                {
                    pathingPoints = new List<Vector2>(2);
                    pathingPoints.Add(new Vector2(Location.X, Location.Y));
                    pathingPoints.Add(new Vector2(Location.X, Location.Y + (float)Math.Abs(pathingRadiusY)));
                }

                //set the pathing points for Bat
                //bats move in linearly (with an erratic off x-axis wobble that will occur at update)         
                if (pathing == Pathing.Bat)
                {
                    pathingPoints = new List<Vector2>(2);
                    pathingPoints.Add(new Vector2(Location.X, Location.Y));
                    pathingPoints.Add(new Vector2(Location.X + (float)pathingRadiusX, Location.Y + (float)pathingRadiusY));
                }

                //set pathting points for Birds and Fish
                //birds move horizontally ( with additional points for swooping ) but is initialized on its horizontal path
                //fish also move horizontally (with additional points for jumping) but initialized on its horizontal path
                if (pathing == Pathing.Bird || pathing == Pathing.Fish)
                {
                    pathingPoints = new List<Vector2>(6);
                    pathingPoints.Add(new Vector2(Location.X, Location.Y));
                    pathingPoints.Add(new Vector2(Location.X + (float)Math.Abs(pathingRadiusX), Location.Y));
                    pathingPoints.Add(new Vector2(Location.X, Location.Y)); //point 3 is top of the oval on the swoop path (as if it were at the vertical position) set at runtime when a swoop is initiated
                    pathingPoints.Add(new Vector2(Location.X, Location.Y + (float)pathingRadiusY / 2f));  //point 4 is the origin of the swoop loop, set values at runtime when swoop starts
                    pathingPoints.Add(new Vector2(pathingRadiusX, 0)); //a place to store original pathing radius when bird swoops (has different pathing), recall when swoop ends 
                    pathingPoints.Add(new Vector2(pathingSpeed, pathingTravelled)); //a place to store original pathing speed and pathing travelled variables while swooping (having different pathing), recall when swoop ends
                }
                
                //set the initial location
                if (pathingPercentComplete < 50)
                {
                    float factor = ((float)pathingPercentComplete) / 50f;
                    Location = new Vector2(pathingPoints[0].X + (factor * (pathingPoints[1].X - pathingPoints[0].X)),
                                            pathingPoints[0].Y + (factor * (pathingPoints[1].Y - pathingPoints[0].Y)));
                }
                else
                {
                    float factor = ((float)(pathingPercentComplete)-50f) / 50f;
                    Location = new Vector2(pathingPoints[1].X + (factor * (pathingPoints[0].X - pathingPoints[1].X)),
                                            pathingPoints[1].Y + (factor * (pathingPoints[0].Y - pathingPoints[1].Y)));
                }   

                //set the destination point
                if (pathingPercentComplete < 50)
                    pathingPointsDestinationIndex = 1;
                else
                    pathingPointsDestinationIndex = 0;

                return;
            }

            //clockwise rectangle
            if (pathing == Pathing.Rectangle && pathingSpeed >= 0)
            {
                //set the pathing points
                pathingPoints = new List<Vector2>(4);
                pathingPoints.Add(new Vector2(Location.X, Location.Y));
                pathingPoints.Add(new Vector2(Location.X + (float)pathingRadiusX, Location.Y ));
                pathingPoints.Add(new Vector2(Location.X + (float)pathingRadiusX, Location.Y + (float)pathingRadiusY));
                pathingPoints.Add(new Vector2(Location.X, Location.Y + (float)pathingRadiusY));

                //set the initial location
                if (pathingPercentComplete < 25)
                {
                    float factor = ((float)pathingPercentComplete) / 25f;
                    Location = new Vector2(pathingPoints[0].X + (factor * (pathingPoints[1].X - pathingPoints[0].X)),
                                            pathingPoints[0].Y + (factor * (pathingPoints[1].Y - pathingPoints[0].Y)));
                    pathingPointsDestinationIndex = 1;
                }
                if (pathingPercentComplete < 50 && pathingPercentComplete >= 25)
                {
                    float factor = ((float)(pathingPercentComplete) - 25f) / 25f;
                    Location = new Vector2(pathingPoints[1].X + (factor * (pathingPoints[2].X - pathingPoints[1].X)),
                                            pathingPoints[1].Y + (factor * (pathingPoints[2].Y - pathingPoints[1].Y)));
                    pathingPointsDestinationIndex = 2;
                }
                if (pathingPercentComplete < 75 && pathingPercentComplete >= 50)
                {
                    float factor = ((float)(pathingPercentComplete) - 50f) / 25f;
                    Location = new Vector2(pathingPoints[2].X + (factor * (pathingPoints[3].X - pathingPoints[2].X)),
                                            pathingPoints[2].Y + (factor * (pathingPoints[3].Y - pathingPoints[2].Y)));
                    pathingPointsDestinationIndex = 3;
                }
                if (pathingPercentComplete < 101 && pathingPercentComplete >= 75)
                {
                    float factor = ((float)(pathingPercentComplete) - 75f) / 25f;
                    Location = new Vector2(pathingPoints[3].X + (factor * (pathingPoints[0].X - pathingPoints[3].X)),
                                            pathingPoints[3].Y + (factor * (pathingPoints[0].Y - pathingPoints[3].Y)));
                    pathingPointsDestinationIndex = 0;
                }

                return;
            }

            if (pathing == Pathing.Rectangle && pathingSpeed < 0)
            {
                //set the pathing points
                pathingPoints = new List<Vector2>(4);
                pathingPoints.Add(new Vector2(Location.X, Location.Y));
                pathingPoints.Add(new Vector2(Location.X, Location.Y + (float)pathingRadiusY));
                pathingPoints.Add(new Vector2(Location.X + (float)pathingRadiusX, Location.Y + (float)pathingRadiusY));
                pathingPoints.Add(new Vector2(Location.X + (float)pathingRadiusX, Location.Y));
                pathingSpeed = Math.Abs(pathingSpeed); //speed has to be positive for runtime on rectangle
                

                //set the initial location
                if (pathingPercentComplete < 25)
                {
                    float factor = ((float)pathingPercentComplete) / 25f;
                    Location = new Vector2(pathingPoints[0].X + (factor * (pathingPoints[1].X - pathingPoints[0].X)),
                                            pathingPoints[0].Y + (factor * (pathingPoints[1].Y - pathingPoints[0].Y)));
                    pathingPointsDestinationIndex = 1;
                }
                if (pathingPercentComplete < 50 && pathingPercentComplete >= 25)
                {
                    float factor = ((float)(pathingPercentComplete) - 25f) / 25f;
                    Location = new Vector2(pathingPoints[1].X + (factor * (pathingPoints[2].X - pathingPoints[1].X)),
                                            pathingPoints[1].Y + (factor * (pathingPoints[2].Y - pathingPoints[1].Y)));
                    pathingPointsDestinationIndex = 2;
                }
                if (pathingPercentComplete < 75 && pathingPercentComplete >= 50)
                {
                    float factor = ((float)(pathingPercentComplete) - 50f) / 25f;
                    Location = new Vector2(pathingPoints[2].X + (factor * (pathingPoints[3].X - pathingPoints[2].X)),
                                            pathingPoints[2].Y + (factor * (pathingPoints[3].Y - pathingPoints[2].Y)));
                    pathingPointsDestinationIndex = 3;
                }
                if (pathingPercentComplete < 101 && pathingPercentComplete >= 75)
                {
                    float factor = ((float)(pathingPercentComplete) - 75f) / 25f;
                    Location = new Vector2(pathingPoints[3].X + (factor * (pathingPoints[0].X - pathingPoints[3].X)),
                                            pathingPoints[3].Y + (factor * (pathingPoints[0].Y - pathingPoints[3].Y)));
                    pathingPointsDestinationIndex = 0;
                }

                return;
            }

            if (pathing == Pathing.Round || pathing == Pathing.Gremlin)
            {
                if (pathing == Pathing.Round)
                {
                    pathingPoints = new List<Vector2>(2);
                    pathingPoints.Add(new Vector2(Location.X, Location.Y)); //point 0 is original location at the vertical on the oval
                    pathingPoints.Add(new Vector2(Location.X, Location.Y + (float)pathingRadiusY / 2f));  //point 1 is the origin about which the object will rotate
                }

                //gremlin initializes and moves in round pattern but will move at the fruit when fired ( via pathing points 3 and 4 linear setting during runtime)
                if (pathing == Pathing.Gremlin)
                {
                    pathingPoints = new List<Vector2>(6);
                    pathingPoints.Add(new Vector2(Location.X, Location.Y)); 
                    pathingPoints.Add(new Vector2(Location.X, Location.Y + (float)pathingRadiusY / 2f)); 
                    pathingPoints.Add(new Vector2(Location.X, Location.Y)); //origin point for linear movement when going after fruit
                    pathingPoints.Add(new Vector2(Location.X, Location.Y)); //destination point for linear movement when going after fruit
                    pathingPoints.Add(new Vector2(pathingRadiusX, pathingRadiusY)); //a place to store original pathing radius, recall when other behaivor ends 
                    pathingPoints.Add(new Vector2(pathingSpeed, pathingTravelled)); //a place to store original pathing speed and pathing travelled variables for recall
                }
                
                //setup starting
                pathingTravelled = MathHelper.ToRadians(-90);  //pathingtraveled converted from % to radians + 90 to put it at top of circle
                if (pathingSpeed < 0)
                {
                    pathingTravelled -= MathHelper.ToRadians(360f * (pathingPercentComplete / 100f));
                }
                if (pathingSpeed >= 0)
                {
                    pathingTravelled += MathHelper.ToRadians(360f * (pathingPercentComplete / 100f));
                }

                Location = new Vector2(pathingPoints[1].X + (float)(Math.Cos(pathingTravelled) * pathingRadiusX / 2f),
                                        pathingPoints[1].Y + (float)(Math.Sin(pathingTravelled) * pathingRadiusY / 2f));
                
                return;
            }

            return;
        }
            
        public void NextPathingPoint()
        {
            pathingTravelled = 0.0f;
            if (pathing == Pathing.Linear || pathing == Pathing.Spider || pathing == Pathing.Bat || pathing == Pathing.Bird || pathing == Pathing.Fish)
            {
                if (pathingPointsDestinationIndex == 1)
                {
                    pathingPointsDestinationIndex = 0;
                    return;
                }
                if (pathingPointsDestinationIndex == 0)
                {
                    pathingPointsDestinationIndex = 1;
                    return;
                }
            }

            if (pathing == Pathing.Rectangle)
            {
                if (pathingPointsDestinationIndex == 0)
                {
                    pathingPointsDestinationIndex = 1;
                    return;
                }
                if (pathingPointsDestinationIndex == 1)
                {
                    pathingPointsDestinationIndex = 2;
                    return;
                }
                if (pathingPointsDestinationIndex == 2)
                {
                    pathingPointsDestinationIndex = 3;
                    return;
                }
                if (pathingPointsDestinationIndex == 3)
                {
                    pathingPointsDestinationIndex = 0;
                    return;
                }
            }
            return;
        }







        #endregion

    }
}
