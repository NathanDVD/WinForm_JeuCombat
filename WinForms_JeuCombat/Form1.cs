using System.Diagnostics;
using System.Media;
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
        public bool isActive = false;

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

        //Class wich define a character
        public class Characters
        {
            public CharacterClass characterClass;
            public string name;
            public int curHealth;
            public int maxHealth;
            public int damage;
            public bool isPoisoned;
            public ActionChoice action;

            public Image idle_frame;
            //public Image attack_frame_1;
            //public Image attack_frame_2;
            //public Image spell_frame_1;
            //public Image spell_frame_2;

            //Constructor base
            public Characters(CharacterClass characterClass, string name, int curHealth, int maxHealth, int damage, ActionChoice action, bool isPoisoned)
            {
                this.characterClass = characterClass;
                this.name = name;
                this.curHealth = curHealth;
                this.maxHealth = maxHealth;
                this.damage = damage;
                this.isPoisoned = isPoisoned;
                this.action = action;

                //GET IMAGES
                this.idle_frame = Image.FromFile($"./Images/{name}/{name}_Idle.png");
                //this.attack_frame_1 = Image.FromFile($"./Images/{name}/{name}Attack_1.png");
                //this.attack_frame_2 = Image.FromFile($"./Images/{name}/{name}Attack_2.png");
                //this.spell_frame_1 = Image.FromFile($"./Images/{name}/{name}Spell_1.png");
                //this.spell_frame_2 = Image.FromFile($"./Images/{name}/{name}Spell_2.png");

            }

            //Constructor copy
            public Characters(Characters characterToCopy)
            {
                characterClass = characterToCopy.characterClass;
                name = characterToCopy.name;
                curHealth = characterToCopy.curHealth;
                maxHealth = characterToCopy.maxHealth;
                damage = characterToCopy.damage;
                action = characterToCopy.action;
                idle_frame = characterToCopy.idle_frame;
                //attack_frame_1 = characterToCopy.attack_frame_1;
                //attack_frame_2 = characterToCopy.attack_frame_2;
                //spell_frame_1 = characterToCopy.spell_frame_1;
                //spell_frame_2 = characterToCopy.spell_frame_2;
            }

            //Inflict damage to character
            public void TakeDamage(int _damage)
            {
                int res = curHealth - damage;
                if (res < 0) { res = 0; }
                curHealth = res;
            }
            //Poison damages
            public void Poisoned(int damagePtn)
            {
                curHealth -= damagePtn;
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

        //--------------------- END OF VARIABLES ---------------------//



        public Form1()
        {
            InitializeComponent();//Start the WinForm

            this.MinimumSize = new Size(1920, 1080);

            this.BackgroundImage = Image.FromFile("./Images/Back1.png");

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

            ImageLogo.Location = new Point((this.Width / 2) - (ImageLogo.Width / 2), 50);

            TextBox.Location = new Point(-1000, 0);

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

            //Player choice
            TextBox.Text = ("Choisissez un personnage:\r\n1 - Damager\r\n2 - Healer\r\n3 - Tank\r\n4 - Rogue\r\n");
        }

        //BUTTON START
        private async void menuButton_Click(object sender, EventArgs e)
        {


            if (!isActive)
            {
                mSoundPlayer.Play();//Play sound
                isActive = true;
                //Animate controls leaving screen
                //PlayButton.Enabled = false;
                //QuitButton.Enabled = false;
                AnimationClass.BounceFunction(ImageLogo, new Point(0, 100), new Point(0, 400), 11);
                await Task.Delay(1120);//Wait because it makes the movements laggy and looks like a slide show
                AnimationClass.BounceFunction(PlayButton, new Point(0, 300), new Point(0, 500), 11);
                await Task.Delay(100);//Small delay for the button to not overlap
                AnimationClass.BounceFunction(QuitButton, new Point(0, 450), new Point(0, 500), 11);
            }


            buttonOffset = 0;//Offset

            await Task.Delay(2400);//Wait 2 seconds

            //Set all character choice buttons position
            foreach (Button button in characterSelectionButtonList)
            {
                button.Size = new Size(356, 496);//Set the button size to the image's
                button.Image = imageList[int.Parse(button.Tag.ToString()) - 1];//Select image according to button tag
                button.Location = new Point((this.Width / 5 + buttonOffset) - (button.Width / 2), (this.Height / 2 + 100) - (button.Height / 2));
                buttonOffset += 400;//Add offset between images
            }

            TextBox.Location = new Point((this.Width / 2) - (TextBox.Width / 2), 150);

            this.BackgroundImage = Image.FromFile("./Images/background_menu.png");

            await Task.Delay(1000);

            //sPlayer.PlayLooping();//Loops the song selected  (A REMETTRE)
        }


        //If clicked exit the app
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();//Exit the app
        }

        //If clicked character selection button
        private void characterChoice_Click(object sender, EventArgs e)
        {
            buttonOffset = 2;
            //Move the buttons on the window
            foreach (Button button in optionButtonList)
            {
                button.Location = new Point((this.Width / 6 * buttonOffset) - (button.Width / 2), (this.Height / 10 * 9) - (button.Height / 2));
                buttonOffset++;
            }

            Button clickedButton = sender as Button;//Button clicked that sent triggered the event

            MainFunction(TextBox, clickedButton);//Launch main function
        }

        private async void actionChoice_Click(object sender, EventArgs e)
        {
            if (canPlay)//Spam proof now
            {
                canPlay = false;
                choseAction = true;

                Button cButton = sender as Button;

                choiceButton = cButton;

                await Task.Delay(1000);
                canPlay = true;
            }
        }


        //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<------------------------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //
        //Here ends the form section, no more Form controls (buttons, label, textbox ect...)
        //The following code is the logic of the game, featuring the main function, game loop, win conditions ...
        //
        //Big chunk of code ahead : 


        public async void MainFunction(Label tBox, Button playerSelectionButton)//here, button = character selection button
        {
            //--------- INITIALIZATION -----------
            bool isEnd = false;

            Random rnd = new Random();//New random

            //Create the possible classes with their stats
            Characters damager = new Characters(CharacterClass.Damager, "Damager", 3, 3, 2, ActionChoice.Defend, false);
            Characters healer = new Characters(CharacterClass.Healer, "Healer", 4, 4, 1, ActionChoice.Defend, false);
            Characters tank = new Characters(CharacterClass.Tank, "Tank", 5, 5, 1, ActionChoice.Defend, false);
            Characters assassin = new Characters(CharacterClass.Assassin, "Rogue", 3, 3, 1, ActionChoice.Defend, false);

            //Create a list of the possible characters
            classList = new List<Characters> { damager, healer, tank, assassin };

            //Initial sprites placement (characters selected)
            PlayerImage.Location = new Point((this.Width / 2-250) - (PlayerImage.Width / 2), (this.Height / 2+350) - (PlayerImage.Height / 2));
            ComputerImage.Location = new Point((this.Width / 2+250) - (ComputerImage.Width / 2), (this.Height / 2+350) - (ComputerImage.Height / 2));

            Characters playerCharacter = PlayerChooseCharacter(tBox, playerSelectionButton, PlayerImage);

            //Display character choice
            tBox.Text = $"\r\nJoueur : {playerCharacter.name}";

            //AI's choice
            Characters AICharacter = new Characters(AIChooseCharacter(ComputerImage));

            //Display character choice
            tBox.Text += $"\r\nAI : {AICharacter.name}";

            //Display health
            DisplayHealth(playerCharacter, AICharacter, tBox);


            //----------------------------------------------------------------------------------//
            //                      ------------- GAME LOOP  ----------------                   //
            //__________________________________________________________________________________//


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
                PlayerChooseAction(playerCharacter, tBox, choiceButton, PlayerImage);

                //Choose ai action
                AIChooseAction(AICharacter, ComputerImage);

                //Combat (round)
                Fight(playerCharacter, AICharacter, tBox);

                //Show game state
                DisplayHealth(playerCharacter, AICharacter, tBox);

                //Win conditions
                isEnd = isEndGame(playerCharacter, AICharacter, tBox);

            }
        }

        //---------------------------------------------//


        //Function called every turn, 
        static void Fight(Characters player, Characters ai, Label tBox)
        {
            //If poisonned last round then - 1 HP and remove poison
            if (isPoisoned(player))
            {
                tBox.Text += ("\r\nPoison : - 1 HP");
                player.TakeDamage(1);
                Poisoned(player, false);
            }
            else if (isPoisoned(ai))
            {
                tBox.Text += ("\r\nPoison : - 1 HP");
                ai.TakeDamage(1);
                Poisoned(ai, false);

            }

            //Display
            ShowPlayerAction(player.action, tBox);
            ShowAIAction(ai.action, tBox);

            //Play
            PlayAction(player, ai, true, tBox);
            PlayAction(ai, player, false, tBox);

        }

        //Function playing the chosen action
        static void PlayAction(Characters actionPlayer, Characters otherPlayer, bool isPlayer, Label tBox)
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
        static void PlayerChooseAction(Characters player, Label tBox, Button button, PictureBox plrBox)
        {
            int action_player_choice = 0;

            tBox.Text = ("\r\nChoisissez une action:\r\n1 - Attack\r\n2 - Defend\r\n3 - Spell");

            action_player_choice = int.Parse(button.Tag.ToString());

            player.action = (ActionChoice)action_player_choice;

            //----------------------------------------------------------------------------------------------
            AnimationClass.CharacterAnim(player, plrBox, 1, player.action);
        }


        //AI action choice
        static async void AIChooseAction(Characters ai, PictureBox compBox)
        {
            Random rand = new Random();
            int choiceNb = Enum.GetValues(typeof(ActionChoice)).Length;

            ai.action = (ActionChoice)rand.Next(1, choiceNb + 1);

            await Task.Delay(500);

            //----------------------------------------------------------------------------------------------
            AnimationClass.CharacterAnim(ai, compBox, -1, ai.action);
        }


        public Characters PlayerChooseCharacter(Label tBox, Button playerChoiceButton, PictureBox plrBox)
        {
            int character_player_choice = 1;

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

            //Buttons remove (card and select for each)
            this.Controls.Remove(DamagerButton);
            this.Controls.Remove(HealerButton);
            this.Controls.Remove(TankButton);
            this.Controls.Remove(AssasinButton);

            //Get player's choice
            Characters _playerChoice = new Characters(classList[character_player_choice - 1]);

            //Update player sprite (Idle)
            plrBox.Image = _playerChoice.idle_frame;

            //Return player's choice
            return classList[character_player_choice - 1];

        }


        //AI character choice
        public Characters AIChooseCharacter(PictureBox compBox)
        {
            Random rand = new Random();
            int rand_index = rand.Next(0, classList.Count);

            //Get AI choice
            Characters _aiCharacter = new Characters(classList[rand_index]);

            //Update AI sprite (Idle)
            compBox.Image = _aiCharacter.idle_frame;
            compBox.Image.RotateFlip(RotateFlipType.Rotate180FlipY);

            //Return AI choice
            return _aiCharacter;
        }


        //End game conditions
        static bool isEndGame(Characters playerCharacter, Characters aiCharacter, Label tBox)
        {
            //Conditions de fin
            bool playerIsDead = playerCharacter.curHealth <= 0;
            bool AIisDead = aiCharacter.curHealth <= 0;

            if (playerIsDead && AIisDead)
            {
                tBox.Text = ("\r\nEgalité !");
                return true;
            }
            else if (AIisDead)
            {
                tBox.Text = ("\r\nLe joueur a gagné !");
                return true;
            }
            else if (playerIsDead)
            {
                tBox.Text = ("\r\nl'IA a gagné !");
                return true;
            }
            else return false;
        }

        //----- Function spell
        static void Heal(Characters charact, Label tBox)
        {
            int _health = (int)charact.curHealth + 2;
            //Check if not going outside health limits
            charact.curHealth = Math.Min(_health, charact.curHealth);
        }

        //---- Display functions
        static void ShowPlayerAction(ActionChoice action, Label tBox)
        {
            tBox.Text = ($"\r\nPlayer choice : {action.ToString()}");
        }

        static void ShowAIAction(ActionChoice action, Label tBox)
        {
            tBox.Text += ($"\r\nAI choice : {action.ToString()}");
        }

        static void DisplayHealth(Characters player, Characters ai, Label tBox)
        {
            tBox.Text += $"\r\nHP joueur : {player.curHealth}/{player.maxHealth}";
            tBox.Text += $"\r\nHP IA : {ai.curHealth}/{ai.maxHealth}";
        }

        static void Poisoned(Characters character, bool b)
        {
            character.isPoisoned = b;
        }

        static bool isPoisoned(Characters character)
        {
            return (bool)character.isPoisoned;
        }
    }
}
