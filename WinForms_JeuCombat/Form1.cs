using System.Diagnostics;
using System.Media;
using System.Numerics;
namespace WinForms_JeuCombat
{
    public partial class Form1 : Form
    {

        //------------------- VARIABLES -------------------//


        List<Button> characterSelectionButtonList = new List<Button>();
        List<Button> optionButtonList = new List<Button>();
        List<Image> imageList = new List<Image>();

        private bool canChange = true;
        private bool choseCharacter = false;
        private bool canPlay = true;
        public bool choseAction = false;

        private int buttonOffset = 0;

        private Button choiceButton;

        private SoundPlayer sPlayer;
        private SoundPlayer mSoundPlayer;

        public static List<Characters> classList = new List<Characters>();

        //Character types
        public enum CharacterClass
        {
            Damager = 1,
            Healer = 2,
            Tank = 3,
            Assassin = 4,
        }


        //------------------------------------------------------------//
        //--------------------- CHARACTER CLASS ----------------------//
        //------------------------------------------------------------//
        //
        public class Characters
        {
            public CharacterClass characterClass;
            public string name;
            public int curHealth;
            public int maxHealth;
            public int damage;
            public bool isPoisoned;
            public ActionChoice action;
            public bool isPlayer;

            public Image idle_frame;
            public Image attack_frame;
            public Image spell_frame;

            //Base constructor
            public Characters(CharacterClass characterClass, string name, int curHealth, int maxHealth, int damage, ActionChoice action, bool isPoisoned, bool isPlayer)
            {
                this.characterClass = characterClass;
                this.name = name;
                this.curHealth = curHealth;
                this.maxHealth = maxHealth;
                this.damage = damage;
                this.isPoisoned = isPoisoned;
                this.action = action;
                this.isPlayer = isPlayer;

                //Get the images by the name of the character chosen later
                this.idle_frame = Image.FromFile($"./Images/{name}/{name}_Idle.png");
                this.attack_frame = Image.FromFile($"./Images/{name}/{name}_Attack.png");
                this.spell_frame = Image.FromFile($"./Images/{name}/{name}_Spell.png");
            }

            //Copy the constructor
            public Characters(Characters characterToCopy)
            {
                characterClass = characterToCopy.characterClass;
                name = characterToCopy.name;
                curHealth = characterToCopy.curHealth;
                maxHealth = characterToCopy.maxHealth;
                damage = characterToCopy.damage;
                action = characterToCopy.action;
                idle_frame = characterToCopy.idle_frame;
                attack_frame = characterToCopy.attack_frame;
                spell_frame = characterToCopy.spell_frame;
                isPlayer = characterToCopy.isPlayer;

            }

            //Inflict damage to character
            public void TakeDamage(int _damage)
            {
                int result = curHealth - _damage;//Remove damage value from health
                if (result < 0) { result = 0; }//If lower than 0, make it 0
                curHealth = result;
            }

            //Poisonned function
            public void Poisoned(int damagePtn)
            {
                curHealth -= damagePtn;//Make the poison "effect"
                isPoisoned = true;
            }
        }

        //Possible actions
        public enum ActionChoice
        {
            Attack = 1,
            Defend = 2,
            Spell = 3,
        }

        //------------------------------------------------------------//
        //--------------------- END OF VARIABLES ---------------------//
        //------------------------------------------------------------//



        //Use those functions to show and update the health visuals(hearts) and the power visuals(fists)
        //Heart & power icons system
        //Uses list to hide hearts that the player lost or doesn't have
        void Power(Characters player, Characters ai)
        {
            //Get power visuals form ai and player
            List<PictureBox> PowerPlayer = new List<PictureBox> { Power1Player, Power2Player };
            List<PictureBox> PowerAI = new List<PictureBox> { Power1AI, Power2AI };

            //Hide the PictureBox (fists)
            for (int i = 0; i < PowerAI.Count; i++)
            {
                PowerPlayer[i].Visible = false;
                PowerAI[i].Visible = false;
            }
            //Get the damage the player and ai can do
            int nb_of_power_player = player.damage;
            int nb_of_power_ai = ai.damage;
            //Set the player power location and make it visible
            PowerPlayer[0].Location = new Point(100, 200);
            PowerPlayer[0].Visible = true;
            //Set the computer power location and make it visible
            PowerAI[0].Location = new Point(this.Width - 175, 200);
            PowerAI[0].Visible = true;

            //IDKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK
            if (player.name == "Damager")
            {
                PowerPlayer[1].Location = new Point(175, 200);
                PowerPlayer[1].Visible = true;
            }
            if (ai.name == "Damager")
            {
                PowerAI[1].Location = new Point(this.Width - 250, 200);
                PowerAI[1].Visible = true;
            }
        }
        void DisplayHeart(Characters player, Characters ai)
        {
            //Get all the hearts
            List<PictureBox> HeartsPlayer = new List<PictureBox> { Heart1Player, Heart2Player, Heart3Player, Heart4Player, Heart5Player };
            List<PictureBox> HeartsAI = new List<PictureBox> { Heart1AI, Heart2AI, Heart3AI, Heart4AI, Heart5AI };
            //Get the number of heart for the player and the ai with the current health
            int nb_of_health_player = player.curHealth;
            int nb_of_health_ai = ai.curHealth;
            //Hide all hearts
            for (int i = 0; i < HeartsPlayer.Count; i++)
            {
                HeartsPlayer[i].Visible = false;
                HeartsAI[i].Visible = false;
            }
            //If not dead
            if (nb_of_health_ai > 0 && nb_of_health_player > 0)
            {
                //Set new location and visibility for the hearts
                HeartsPlayer[0].Location = new Point(100, 100);
                HeartsPlayer[0].Visible = true;
                HeartsAI[0].Location = new Point(this.Width - 181, 100);
                HeartsAI[0].Visible = true;
                for (int i = 1; i < nb_of_health_player; i++)
                {
                    //Add an offset to the hearts so they don't overlap while the player has more than 1 heart
                    HeartsPlayer[i].Location = new Point(HeartsPlayer[i - 1].Location.X + 120, 100);
                    HeartsPlayer[i].Visible = true;
                }
                for (int i = 1; i < nb_of_health_ai; i++)
                {
                    //Add an offset to the hearts so they don't overlap while the ai has more than 1 heart
                    HeartsAI[i].Location = new Point(HeartsAI[i - 1].Location.X - 100, 100);
                    HeartsAI[i].Visible = true;
                }
            }
        }



        //------------------------------------------------------------//
        //-------------------- FORM INITIALIZATION -------------------//
        //------------------------------------------------------------//

        public Form1()
        {
            InitializeComponent();//Start the WinForm

            //Load the sounds and songs (main theme)
            sPlayer = new SoundPlayer("./Sounds/8-Bit_FightingGame_Music.wav");
            sPlayer.Load();
            //Here too (sound effect)
            mSoundPlayer = new SoundPlayer("./Sounds/Game_Start.wav");
            mSoundPlayer.Load();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //Get half of screen height and width + half of button height and width to find the center of screen + offset
            PlayButton.Location = new Point((this.Width / 2) - (PlayButton.Width / 2), (this.Height / 2) - (PlayButton.Height / 2));
            QuitButton.Location = new Point((this.Width / 2) - (QuitButton.Width / 2), (this.Height / 2 + 150) - (QuitButton.Height / 2));

            ImageLogo.Location = new Point((this.Width / 2) - (ImageLogo.Width / 2), 150);

            textBox1.Location = new Point(-1000, 0);

            //Add character choice buttons to list
            characterSelectionButtonList.AddRange(new Button[] { DamagerButton, HealerButton, TankButton, AssasinButton });
            //Set all the images for the buttons
            imageList.AddRange(new List<Image>() {
                Image.FromFile("./Images/damager_selection.png"),
                Image.FromFile("./Images/healer_selection.png"),
                Image.FromFile("./Images/tank_selection.png"),
                Image.FromFile("./Images/assassin_selection.png")
            });

            //List of all the option buttons to display later
            optionButtonList.AddRange(new Button[] { AttackButton, DefendButton, SpellButton });
        }


        public void DisplayText(string text)
        {
            if (text == "hide")
            {
                MessageText.Visible = false;
            }
            if (text == "selection")
            {
                MessageText.Location = new Point((this.Width / 5) - 250, 200);
                MessageText.Image = Image.FromFile("./Images/UIElements/select_character.png");
                MessageText.Visible = true;
            }
            if (text == "win")
            {
                MessageText.Location = new Point((this.Width / 5) - 250, 500);
                MessageText.Image = Image.FromFile("./Images/UIElements/you_win.png");
                MessageText.Visible = true;
            }
            if (text == "lose")
            {
                MessageText.Location = new Point((this.Width / 5) - 250, 500);
                MessageText.Image = Image.FromFile("./Images/UIElements/you_lose.png");
                MessageText.Visible = true;
            }
            if (text == "nowinner")
            {
                MessageText.Location = new Point((this.Width / 5) - 250, 500);
                MessageText.Image = Image.FromFile("./Images/UIElements/no_winner.png");
                MessageText.Visible = true;
            }
        }

        //------------------------------------------------------------//
        //-------------------- FORM CONTROLS/EVENTS ------------------//
        //------------------------------------------------------------//
        private async void button1_Click(object sender, EventArgs e)
        {
            mSoundPlayer.Play();//Play sound

            //Animate controls leaving screen
            AnimationClass.BounceFunction(ImageLogo, new Point(0, 100), new Point(0, 400), 11);
            await Task.Delay(2000);
            AnimationClass.BounceFunction(PlayButton, new Point(0, 300), new Point(0, 500), 11);
            await Task.Delay(100);
            AnimationClass.BounceFunction(QuitButton, new Point(0, 450), new Point(0, 500), 11);



            buttonOffset = 0;//Offset

            await Task.Delay(2000);//Wait 2 seconds

            //Set all character choice button positions
            DisplayText("selection");
            foreach (Button button in characterSelectionButtonList)
            {
                button.Size = new Size(356, 496);//Set the button size to the image's
                button.Image = imageList[int.Parse(button.Tag.ToString()) - 1];//Select image according to button tag
                button.Location = new Point((this.Width / 5 + buttonOffset) - (button.Width / 2), (this.Height / 2 + 50) - (button.Height / 2));
                buttonOffset += 400;//Add offset between images(400pixels)
            }

            textBox1.Location = new Point(5, this.Height + 100);//Move the textBox on the screen

            this.BackgroundImage = Image.FromFile("./Images/background_menu.png");//Set the background image

            await Task.Delay(1000);

            sPlayer.PlayLooping();//Loops the song selected

            //Ask the player to chose a character
            textBox1.Text += "Choisissez un personnage:\r\n1 - Damager\r\n2 - Healer\r\n3 - Tank\r\n4 - Assasin\r\n";
        }


        //If clicked exit the app
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();//Exit the app
        }

        //Function to get the user Character choice by clicking the buttons linked to this one
        private void characterChoice_Click(object sender, EventArgs e)
        {
            buttonOffset = 100;//Start offset
            //Move the buttons on the window
            foreach (Button button in optionButtonList)
            {
                button.Location = new Point((this.Width / 3 + buttonOffset) - (button.Width / 2), (this.Height / 2 + 500) - (button.Height / 2));
                buttonOffset += 200;//Add offset between buttons
            }

            Button clickedButton = sender as Button;//Button clicked that sent triggered the event

            MainFunction(textBox1, clickedButton);//Launch main function
        }

        //Select the user Action choice according to the button clicked
        private async void actionChoice_Click(object sender, EventArgs e)
        {
            if (canPlay)//Spam proof
            {
                canPlay = false;
                choseAction = true;

                Button cButton = sender as Button;

                choiceButton = cButton;

                await Task.Delay(1000);
                canPlay = true;
            }
        }

        //When text is added or removed in the textBox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.TextLength;//Set text start(the first line to show
            textBox1.ScrollToCaret();//Scroll to bottom
        }



        //------------------------------------------------------------//
        //-------------------- FORM CONTROLS/EVENTS ------------------//
        //------------------------------------------------------------//

        //---------------------------------------------------------------------------------------------------------//
        //
        //Here ends the form section, no more Form controls (buttons, label, textbox ect...)
        //The following code is the logic of the game, featuring the main function, game loop, win conditions ...
        //
        //Big chunk of code ahead :
        //---------------------------------------------------------------------------------------------------------//

        public async void MainFunction(TextBox tBox, Button playerSelectionButton)//here, button = character selection button
        {
            //--------- INITIALIZATION -----------
            bool isEnd = false;

            Random rnd = new Random();//Create a new random

            //Create all the different character with the class
            Characters damager = new Characters(CharacterClass.Damager, "Damager", 3, 3, 2, ActionChoice.Defend, false, false);
            Characters healer = new Characters(CharacterClass.Healer, "Healer", 4, 4, 1, ActionChoice.Defend, false, false);
            Characters tank = new Characters(CharacterClass.Tank, "Tank", 5, 5, 1, ActionChoice.Defend, false, false);
            Characters assassin = new Characters(CharacterClass.Assassin, "Rogue", 3, 3, 1, ActionChoice.Defend, false, false);

            //List of all the characters possible
            classList = new List<Characters> { damager, healer, tank, assassin };

            //Initial sprites placement (characters selected)
            PlayerBox.Location = new Point((this.Width / 2 - 150) - (PlayerBox.Width / 2), (this.Height / 2 + 350) - (PlayerBox.Height / 2));
            ComputerBox.Location = new Point((this.Width / 2 + 150) - (ComputerBox.Width / 2), (this.Height / 2 + 350) - (ComputerBox.Height / 2));

            //Player choice
            tBox.Text += ("Choisissez un personnage:\r\n1 - Damager\r\n2 - Healer\r\n3 - Tank\r\n4 - Rogue\r\n");
            Characters playerCharacter = PlayerChooseCharacter(tBox, playerSelectionButton, PlayerBox);

            //Display character choice
            tBox.Text += $"\r\nJoueur : {playerCharacter.name}";

            //AI's choice
            Characters AICharacter = new Characters(AIChooseCharacter(ComputerBox));

            //Display character choice
            tBox.Text += $"\r\nAI : {AICharacter.name}";

            //Display health
            DisplayHealth(playerCharacter, AICharacter, tBox);

            //Update health and power(fist)
            DisplayText("hide");
            DisplayHeart(playerCharacter, AICharacter);
            Power(playerCharacter, AICharacter);

            //Place poison state icon (for player and AI)
            //playerPoisonStateBox.Location = new Point(Heart2Player.Location.X, Heart2Player.Location.Y - 60); //en cours
            playerPoisonStateBox.Location = new Point(PlayerBox.Location.X + 50, PlayerBox.Location.Y - 100);

            aiPoisonStateBox.Location = new Point(ComputerBox.Location.X + 50, ComputerBox.Location.Y - 100);


            //------------- GAME LOOP  ----------------
            while (!isEnd)
            {
                Debug.WriteLine(choseAction);
                while (!choseAction)
                {
                    await Task.Delay(100);
                    Application.DoEvents();//Does not freeze the app waiting for the user input
                }

                choseAction = false;

                //Choose player action
                PlayerChooseAction(playerCharacter, tBox, choiceButton, PlayerBox);

                //Choose ai action
                AIChooseAction(AICharacter, ComputerBox);

                //Combat (round)
                Fight(playerCharacter, AICharacter, tBox, playerPoisonStateBox, aiPoisonStateBox);

                //Update health
                DisplayHeart(playerCharacter, AICharacter);
                Power(playerCharacter, AICharacter);

                //Show game state
                DisplayHealth(playerCharacter, AICharacter, tBox);

                //Win conditions
                isEnd = isEndGame(playerCharacter, AICharacter, tBox);

            }
        }



        //Function called every turn, 
        static void Fight(Characters player, Characters ai, TextBox tBox, PictureBox playerPoisonStateBox, PictureBox aiPoisonStateBox)
        {
            //If poisonned last round then - 1 HP and remove poison
            if (isPoisoned(player))
            {
                tBox.Text += ("\r\nPoison : - 1 HP");   
                player.TakeDamage(1);
                Poisoned(player, false);
                playerPoisonStateBox.Visible = false; //Disable poison icon (player)
            }
            else if (isPoisoned(ai))
            {
                tBox.Text += ("\r\nPoison : - 1 HP");
                ai.TakeDamage(1);
                Poisoned(ai, false);
                aiPoisonStateBox.Visible = false; //Disable poison icon (player)
            }
            //Display
            ShowPlayerAction(player.action, tBox);
            ShowAIAction(ai.action, tBox);

            //Play
            PlayAction(player, ai, true, tBox, playerPoisonStateBox, aiPoisonStateBox);
            PlayAction(ai, player, false, tBox, playerPoisonStateBox, aiPoisonStateBox);

        }

        //Function playing the chosen action
        static void PlayAction(Characters actionPlayer, Characters otherPlayer, bool isPlayer, TextBox tBox, PictureBox playerPoisonStateBox, PictureBox aiPoisonStateBox)
        {
            //GET ACTIONS
            ActionChoice actionPlayerChoice = actionPlayer.action;
            ActionChoice otherPlayerChoice = otherPlayer.action;

            if (actionPlayerChoice == ActionChoice.Spell) //SPELL
            {
                if (actionPlayer.name == "Healer") //HEAL
                {
                    Heal(actionPlayer, tBox);
                }
                else if (actionPlayer.name == "Rogue") //Poisonned daggers
                {
                    //Active poison icon (for player or AI)
                    if (actionPlayer.isPlayer)
                    {
                        aiPoisonStateBox.Visible = true;
                    }
                    else playerPoisonStateBox.Visible = true;

                    //Poisonned - 1 HP next round
                    Poisoned(otherPlayer, true);

                    tBox.Text += ("\r\nPoisoned attack : - 1 HP | Poisoned state");

                    //If not defending then - 1 damage point
                    if (otherPlayerChoice != ActionChoice.Defend)
                    {
                        otherPlayer.TakeDamage(1);
                    }
                }
                else if (actionPlayer.name == "Tank")//POWERFULL ATTACK
                {
                    //Spell effect (powerfull att)
                    int boostedDamage = actionPlayer.damage + 1;
                    actionPlayer.TakeDamage(1);

                    //OTHER RAGE
                    if ((otherPlayer.characterClass == CharacterClass.Damager) && (otherPlayerChoice == ActionChoice.Spell))
                    {
                        otherPlayer.TakeDamage(boostedDamage);
                        actionPlayer.TakeDamage(boostedDamage);

                    }
                    else if (otherPlayerChoice == ActionChoice.Defend) //OTHER DEFEND
                    {
                        otherPlayer.TakeDamage(boostedDamage - 1);
                    }
                    else  //REST (Attack, Heal, powerfull attack...)
                    {
                        otherPlayer.TakeDamage(boostedDamage);
                    }

                }
            }
            else if (actionPlayerChoice == ActionChoice.Attack) //ATTACK
            {
                //If spell is Rage (damager)
                if ((otherPlayer.characterClass == CharacterClass.Damager) && (otherPlayerChoice == ActionChoice.Spell))
                {
                    otherPlayer.TakeDamage(actionPlayer.damage);
                    actionPlayer.TakeDamage(actionPlayer.damage);
                }
                else if (otherPlayerChoice == ActionChoice.Defend) //If defending
                {
                    return;
                }
                else //REST (attack, heal, powerfull attack etc...)
                {
                    otherPlayer.TakeDamage(actionPlayer.damage);
                }
            }
        }


        //Player action choice
        static void PlayerChooseAction(Characters player, TextBox tBox, Button button, PictureBox plrBox)
        {
            int action_player_choice = 0;

            tBox.Text += ("\r\nChoisissez une action:\r\n1 - Attack\r\n2 - Defend\r\n3 - Spell");

            action_player_choice = int.Parse(button.Tag.ToString());

            player.action = (ActionChoice)action_player_choice;

            AnimationClass.CharacterAnim(player, plrBox, 1, player.action);
        }


        //AI action choice
        static async void AIChooseAction(Characters ai, PictureBox compBox)
        {
            Random rand = new Random();

            //Get lenght of ActionChoice
            int choiceNb = Enum.GetValues(typeof(ActionChoice)).Length;

            //Random action for computer
            ai.action = (ActionChoice)rand.Next(1, choiceNb + 1);

            await Task.Delay(500);

            //Animate the character using this function
            AnimationClass.CharacterAnim(ai, compBox, -1, ai.action);
        }

        //Find / Get the player choice
        public Characters PlayerChooseCharacter(TextBox tBox, Button playerChoiceButton, PictureBox plrBox)
        {
            int character_player_choice = 1;//If for some reason the character is not manually chosen, there is a default one

            //If tag not null
            if (playerChoiceButton.Tag != null)
            {
                //Get + conversion
                int.TryParse(playerChoiceButton.Tag.ToString(), out character_player_choice);

                //Security(if tag not correct)
                if (character_player_choice < 1 || character_player_choice > classList.Count)
                {
                    character_player_choice = 1;
                }
            }

            //Buttons remove (Character choice cards)
            this.Controls.Remove(DamagerButton);
            this.Controls.Remove(HealerButton);
            this.Controls.Remove(TankButton);
            this.Controls.Remove(AssasinButton);

            //Get player choice
            Characters _playerChoice = new Characters(classList[character_player_choice - 1]);

            //Update player sprite (Idle)
            plrBox.BackgroundImage = _playerChoice.idle_frame;

            _playerChoice.isPlayer = true;

            //Return player choice
            return _playerChoice;

        }


        //AI character choice
        public Characters AIChooseCharacter(PictureBox compBox)
        {
            Random rand = new Random();

            int rand_index = rand.Next(0, classList.Count);

            //Get AI choice
            Characters _aiCharacter = new Characters(classList[rand_index]);
            _aiCharacter.isPlayer = false;

            _aiCharacter.idle_frame = (Image)_aiCharacter.idle_frame.Clone();

            //Update AI sprite (Idle) with cloned image
            compBox.BackgroundImage = _aiCharacter.idle_frame;

            //Flip cloned image on Y axis
            _aiCharacter.idle_frame.RotateFlip(RotateFlipType.Rotate180FlipY);

            //Return AI choice
            return _aiCharacter;
        }


        //End game conditions
         bool isEndGame(Characters playerCharacter, Characters aiCharacter, TextBox tBox)
        {
            //Set player and ai death condition(if health is = or < 0)
            bool playerIsDead = playerCharacter.curHealth <= 0;
            bool AIisDead = aiCharacter.curHealth <= 0;

            //Show the winner and leave the loop
            if (playerIsDead && AIisDead)
            {
                DisplayText("nowinner");
                return true;
            }
            else if (AIisDead)
            {
                DisplayText("win");
                return true;
            }
            else if (playerIsDead)
            {
                DisplayText("lose");
                return true;
            }
            else return false;
        }

        //----- Fonction spell
        static void Heal(Characters charact, TextBox tBox)
        {
            int _health = (int)charact.curHealth + 2;
            //Verify if health is not going over the maximum health
            charact.curHealth = _health;
            if (charact.curHealth > charact.maxHealth)
            {
                charact.curHealth = charact.maxHealth;//Set health to max health if going over max health
            }
        }

        //------------------ Display functions -----------------
        static void ShowPlayerAction(ActionChoice action, TextBox tBox)
        {
            //Show player action
            tBox.Text += ($"\r\nPlayer choice : {action.ToString()}");
        }

        static void ShowAIAction(ActionChoice action, TextBox tBox)
        {
            //Show ai action
            tBox.Text += ($"\r\nAI choice : {action.ToString()}");
        }

        static void DisplayHealth(Characters player, Characters ai, TextBox tBox)
        {
            //Show player and ai health
            tBox.Text += $"\r\nHP joueur : {player.curHealth}/{player.maxHealth}";
            tBox.Text += $"\r\nHP IA : {ai.curHealth}/{ai.maxHealth}";
        }

        //--------------- Poison functions ------------------
        static void Poisoned(Characters character, bool b)
        {
            //Apply poison effect
            character.isPoisoned = b;
        }

        static bool isPoisoned(Characters character)
        {
            //Check if a character is poisoned
            return (bool)character.isPoisoned;
        }
    }
}
