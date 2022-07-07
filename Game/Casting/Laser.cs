using System;
using System.Collections.Generic;


namespace cse210_10.Game.Casting
{
    /// <summary>
    /// 
    /// </summary>
    public class Laser : Actor
    {
        private static Random random = new Random();

        private Body body;
        private Image image;

        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        public Laser(Body body, Image image, bool debug = false) : base(debug)
        {
            this.body = body;
            this.image = image;
        }

        /// <summary>
        /// Bounces the ball horizontally.
        /// </summary>
        public void BounceX()
        {
            Point velocity = body.GetVelocity();
            double rn = (random.NextDouble() * (1.2 - 0.8) + 0.8);
            double vx = velocity.GetX() * -1;
            double vy = velocity.GetY();
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
        }

        /// <summary>
        /// Bounces the ball vertically.
        /// </summary>
        public void BounceY()
        {
            Point velocity = body.GetVelocity();
            double rn = (random.NextDouble() * (1.2 - 0.8) + 0.8);
            double vx = velocity.GetX();
            double vy = velocity.GetY() * -1;
            Point newVelocity = new Point((int)vx, (int)vy);
            body.SetVelocity(newVelocity);
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
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        public Image GetImage()
        {
            return image;
        }

        /// <summary>
        /// Releases ball in random horizontal direction.
        /// </summary>
        public void Release()
        {
            Point velocity = body.GetVelocity();
            List<int> velocities = new List<int> {Constants.BALL_VELOCITY, Constants.BALL_VELOCITY};
            int index = random.Next(velocities.Count);
            double vx = velocities[index];
            double vy = -Constants.BALL_VELOCITY;
            // changed so laser goes straight up when launched
            Point newVelocity = new Point(0, (int)vy);
            body.SetVelocity(newVelocity);
        }

        // Class to move body to new position

        public void setBody(Point point)
        {
            body.SetPosition(point);

        }
    }
}