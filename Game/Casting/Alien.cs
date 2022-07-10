namespace cse210_10.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Alien : Actor
    {
        private Body body;
        private Animation animation;
        private int points;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Alien(Body body, Animation animation, int points, bool debug) : base(debug)
        {
            this.body = body;
            this.animation = animation;
            this.points = points;
            InitialVelocity();
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <returns>The animation.</returns>
        public Animation GetAnimation()
        {
            return animation;
        }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }

        /// <summary>
        /// Gets the points.
        /// </summary>
        /// <returns>The points.</returns>
        public int GetPoints()
        {
            return points;
        }

        /// <summary>
        /// Negates current velocity in the x direction.
        /// </summary>
        public void BounceXForEach(Cast cast)
        {
            List<Actor> aliens = cast.GetActors(Constants.BRICK_GROUP);
            foreach (Alien alien in aliens)
            {

            Point velocity = body.GetVelocity();
            int vx = velocity.GetX() * -1;
            int vy = velocity.GetY();
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
            }

        }
        public void BounceX()
        {
            Point velocity = body.GetVelocity();
            int vx = velocity.GetX() * -1;
            int vy = velocity.GetY();
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Sets the initial velocity
        /// </summary>
        private void InitialVelocity() {
            Point velocity = body.GetVelocity();
            Point newVelocity = new Point(Constants.ALIEN_X_VELOCITY, 0);
            body.SetVelocity(newVelocity);
        }

        public void moveDown()
        {
            
            Point oldposition = body.GetPosition();
            int x = oldposition.GetX();
            int y = oldposition.GetY();
            Point newPosition = new Point(x, y + Constants.BRICK_HEIGHT);
            body.SetPosition(newPosition);
        }
    }
}