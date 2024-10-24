using System.Diagnostics;

namespace WinForms_JeuCombat
{
    internal class AnimationClass
    {
        private static float speed;



        //<<<<<<<<<<<<<<<<<<<<<<<<<<----------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        //Bounce function used primarily for the menu buttons. Needs a Control, 2 target locations and a float to control the movement speed.
        //The function will loop until the 1st destination is reached (adding more speed), it also converts a PointF(float) into a Point(int), then
        //go in the other direction (2nd destination) to create this "bounce" effect, then will continue in the primary direction.
        //
        //___________________________________________________________________________________________________________
        public static async void BounceFunction(Control control, PointF targetPos, PointF targetPos2, float speed)
        {
            // Move upwards until reaching the target position (bounce start)
            while (control.Location.Y > targetPos.Y)
            {
                speed += 0.5f;
                float newY = control.Location.Y - speed;

                control.Location = new Point(control.Location.X, (int)newY);//Convert to integer Point
                await Task.Delay(20); //Wait
            }

            //Reverse speed to create bounce effect
            speed = -11;
            while (control.Location.Y < targetPos2.Y)
            {
                speed += 1.1f;
                float newY = control.Location.Y - speed;
                control.Location = new Point(control.Location.X, (int)newY); // Convert to integer Point
                await Task.Delay(20);
            }
            speed = 10;//Reset speed
        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<----------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        //Uses the XMovement function to move the character according to the action that was chosen.
        //Character animations  --> Faire ici le chagement de frame
        //
        //___________________________________________________________________________________________________________
        public static async void CharacterAnim(Form1.Characters character, PictureBox characterImage, int xDirection, Form1.ActionChoice action)
        {
            Image baseImage = character.idle_frame;

            if (action == Form1.ActionChoice.Attack)  //MOVEMENT
            {
                //XMovement(characterImage, xDirection);//XMovement one way (positive X)

                //Setup the image to use
                characterImage.Image = character.attack_frame;//Switch(-> attack frame)
                if (characterImage.Name == "ComputerBox") { characterImage.Image.RotateFlip(RotateFlipType.Rotate180FlipY); } //AI Flip

                await Task.Delay(500);//Wait (delay between frames)

                //Go back to base frame
                characterImage.Image = baseImage; //Switch(-> idle frame)

                //XMovement(characterImage, -xDirection);//Reverse XMovement (negative X)
            }
            else if (action == Form1.ActionChoice.Defend)
            {
                //Defend action, maybe pass (useless for moment)
            }
            else if (action == Form1.ActionChoice.Spell)
            {

                //Setup the image to use
                characterImage.BackgroundImage = character.spell_frame;//"Play" attack animation
                if (characterImage.Name == "ComputerBox") { characterImage.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY); }

                await Task.Delay(500);

                //Go back to base frame
                characterImage.BackgroundImage = baseImage;
            }
        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<----------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        //Movement logic :
        //Take image location, set a new location every 20ms by the chosen offset multiplied by the speed(which is incremental)
        //in the chosen direction, only if the xDirection is not 0.
        //It also works with anything that has a location parameter, you just need to change PictureBox to Control.
        //
        //___________________________________________________________________________________________________________
        public async static void XMovement(PictureBox characterImage, int xDirection)
        {
            Point startLocation = characterImage.Location;//Set start location

            int targetX = startLocation.X + (xDirection * 200);//Calculate end locations

            int speed = 0;//Reset speed

            if (xDirection != 0)
            {
                //While loop to move the image until it reaches the set destination (for the X axis)
                while ((xDirection == 1 && startLocation.X < targetX) || (xDirection == -1 && startLocation.X > targetX))
                {
                    speed += 2;//Incremental speed
                    startLocation.X += xDirection * speed;//Move in the direction based on xDirection (-1 to 1) multiplied by speed
                    characterImage.Location = new Point(startLocation.X, startLocation.Y);
                    await Task.Delay(20);//Wait
                }
            }
        }
    }
}
