using System.Diagnostics;
using System.Media;
using System.Windows.Forms;

namespace WinForms_JeuCombat
{
    public partial class Form1 : Form
    {
        List<Button> buttonList = new List<Button>();


        private bool canChange = true;
        private bool choseCharacter = false;
        public bool choseAction = false;

        private Button choiceButton;

        private SoundPlayer sPlayer;
        private SoundPlayer mSoundPlayer;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get half of screen height and width + half of button height and width to find the perfect center of the screen
            PlayButton.Location = new Point((this.Width / 2) - (PlayButton.Width / 2), (this.Height / 2) - (PlayButton.Height / 2));
            QuitButton.Location = new Point((this.Width / 2) - (QuitButton.Width / 2), (this.Height / 2 + 150) - (QuitButton.Height / 2));

            label1.Location = new Point((this.Width / 2) - (label1.Width / 2), 150);

            textBox1.Location = new Point(-1000, 0);

            //Add character choice buttons to list
            buttonList.AddRange(new Button[] { DamagerButton, HealerButton, TankButton, AssasinButton });

        }

        public async void BounceFunction(Control control, Point targetPos, Point targetPos2, int speed)
        {

            while (control.Location.Y > targetPos.Y)//< to end position
            {
                speed += 1;//Incremental speed
                control.Location = new Point(control.Location.X, control.Location.Y - speed);//Change position with speed
                await Task.Delay(20);//Wait 20ms without freezing program
            }

            speed = -10; //Inverse speed to create bounce effect
            while (control.Location.Y < targetPos2.Y)
            {
                speed += 1;
                control.Location = new Point(control.Location.X, control.Location.Y - speed);
                await Task.Delay(20);
            }
            speed = 10;

            //When finished remove menu
            control.Location = targetPos;
            this.Controls.Remove(control);

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //ANimate controls leaving screen
            BounceFunction(PlayButton, new Point(0, 250), new Point(0, 500), 1);
            BounceFunction(QuitButton, new Point(0, 500), new Point(0, 550), 1);
            BounceFunction(label1, new Point(0, 100), new Point(0, 400), 1);

            int buttonOffset = 100;//Offset

            await Task.Delay(2000);//Wait 2 seconds

            //Set all character choice buttons position
            buttonList.Reverse();
            foreach (Button button in buttonList)
            {
                button.Location = new Point((this.Width / 2 + 700) - (PlayButton.Width / 2), (this.Height / 2 - buttonOffset) - (PlayButton.Height / 2));
                buttonOffset += 100;
            }

            //mSoundPlayer.Play();
            textBox1.Location = new Point((this.Width / 2) - (textBox1.Width / 2), 150);
            await Task.Delay(1000);

            //sPlayer.PlayLooping();

            textBox1.Text += "Choisissez un personnage:\r\n1 - Damager\r\n2 - Healer\r\n3 - Tank\r\n4 - Assasin\r\n";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();//Exit the app
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Button clickedButton = sender as Button;

            MainFunction(textBox1, clickedButton);
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            Button cButton = sender as Button;

            Debug.WriteLine($"Clicked button Tag: {cButton.Tag}");

            choiceButton = cButton;

            choseAction = true;
        }



        //Big chunk of code ahead : 
        public enum ActionChoice
        {
            Attack = 1,
            Defend = 2,
            Spell = 3,
        }

        //Dictionnaire contenant données des classes de personnage -> chaque valeur est elle-même un dictionnaire représentant le personnage
        static Dictionary<string, Dictionary<string, object>> character = new Dictionary<string, Dictionary<string, object>>()
        {
            {
                "Damager", new Dictionary<string, object>()
                {
                    { "Name", "Damager" },
                    { "HP", 3 },
                    { "Force", 2 },
                    { "Action", ActionChoice.Defend},
                    { "Poisoned", false}
                }
            },
            {
                "Healer", new Dictionary<string, object>()
                {
                    { "Name", "Healer" },
                    { "HP", 4 },
                    { "Force", 1 },
                    { "Action", ActionChoice.Defend },
                    { "Poisoned", false}
                }
            },
            {
                "Tank", new Dictionary<string, object>()
                {
                    { "Name", "Tank" },
                    { "HP", 5 },
                    { "Force", 1 },
                    { "Action", ActionChoice.Defend },
                    { "Poisoned", false}
                }
            },
            {
                "Assassin", new Dictionary<string, object>()
                {
                    { "Name", "Assassin" },
                    { "HP", 3 },
                    { "Force", 1 },
                    { "Action", ActionChoice.Defend },
                    { "Poisoned", false}
                }
            },
        };

        public void MainFunction(TextBox tBox, Button button)
        {
            //--------- INITIALISATION -----------
            bool isEnd = false;

            Random rnd = new Random();

            // Choix personnage joueur
            Dictionary<string, object> playerCharacter = new Dictionary<string, object>(character[PlayerChooseCharacter(tBox, button)]);

            // Choix personnage AI
            Dictionary<string, object> AICharacter = new Dictionary<string, object>(character[AIChooseCharacter()]);

            //Affichage choix personnages
            tBox.Text += $"\r\nJoueur : {playerCharacter["Name"]}\r\nIA : {AICharacter["Name"]}";

            //------------- BOUCLE DU JEU  ----------------

            //On affiche l'état du jeu(faire fonction)
            DisplayHealth(playerCharacter, AICharacter, tBox);

            while (!isEnd)
            {
                Debug.WriteLine(choseAction);
                while (!choseAction)
                {
                    Application.DoEvents();//Does not freeze the app waiting for the user input
                }

                choseAction = false;

                //Choix adction joueur
                PlayerChooseAction(playerCharacter, tBox, choiceButton);

                //Choix action IA
                AIChooseAction(AICharacter);

                //Combat (round)
                Fight(playerCharacter, AICharacter, tBox);

                //On affiche l'état du jeu
                DisplayHealth(playerCharacter, AICharacter, tBox);
                //Conditions de fin
                isEnd = isEndGame(playerCharacter, AICharacter, tBox);

            }
        }

        //---------------------------------------------


        //Fonction combat appelé à chaque tour
        static void Fight(Dictionary<string, object> player, Dictionary<string, object> ai, TextBox tBox)
        {
            //Si cible empoisonnée au tour préc = - 1 HP et on retire empoisonnement
            if (isPoisoned(player))
            {
                tBox.Text += ("\r\nPoison : - 1 HP"); //pour test
                TakeDamage(player, 1);
                Poisoned(player, false);
            }
            else if (isPoisoned(ai))
            {
                tBox.Text += ("\r\nPoison : - 1 HP"); //pour test
                TakeDamage(ai, 1);
                Poisoned(ai, false);
            }

            //Display
            ShowPlayerAction((ActionChoice)player["Action"], tBox);
            ShowAIAction((ActionChoice)ai["Action"], tBox);

            //Play
            PlayAction(player, ai, true, tBox);
            PlayAction(ai, player, false, tBox);

        }

        //Fonction jouant l'action
        static void PlayAction(Dictionary<string, object> actionPlayer, Dictionary<string, object> otherPlayer, bool isPlayer, TextBox tBox)
        {
            //GET ACTIONS
            ActionChoice actionPlayerChoice = (ActionChoice)actionPlayer["Action"];
            ActionChoice otherPlayerChoice = (ActionChoice)otherPlayer["Action"];

            if (actionPlayerChoice == ActionChoice.Spell) //SPELL
            {
                if ((string)actionPlayer["Name"] == "Healer") //HEAL
                {
                    Heal(actionPlayer, tBox);
                }
                else if ((string)actionPlayer["Name"] == "Assassin") //Dagues empoisonnées
                {
                    //Empoisonne : - 1 HP au prochain tour
                    Poisoned(otherPlayer, true);

                    tBox.Text += ("\r\nAttaque shuriken : - 1 HP, État empoisonnée"); //pour test

                    //Si cible ne défend pas : - 1ptn de dégat sur le moment
                    if (otherPlayerChoice != ActionChoice.Defend)
                    {
                        TakeDamage(otherPlayer, 1);
                    }
                }
                else if ((string)actionPlayer["Name"] == "Tank") //POWERFULL ATTACK
                {
                    //Spell effect (powerfull att)
                    int boostedDamage = (int)actionPlayer["Force"] + 1;
                    actionPlayer["HP"] = (int)actionPlayer["HP"] - 1;

                    //OTHER RAGE
                    if (((string)otherPlayer["Name"] == "Damager") && (otherPlayerChoice == ActionChoice.Spell))
                    {
                        otherPlayer["HP"] = (int)otherPlayer["HP"] - boostedDamage;
                        actionPlayer["HP"] = (int)actionPlayer["HP"] - boostedDamage;

                    }
                    else if (otherPlayerChoice == ActionChoice.Defend) //OTHER DEFEND
                    {
                        otherPlayer["HP"] = (int)otherPlayer["HP"] - (boostedDamage - 1);
                    }
                    else  //REST (Attack, Heal, powerfull attack...)
                    {
                        otherPlayer["HP"] = (int)otherPlayer["HP"] - boostedDamage;
                    }

                }
            }
            else if (actionPlayerChoice == ActionChoice.Attack) //ATTACK
            {
                //Cas où l'autre fait rage (damager)
                if (((string)otherPlayer["Name"] == "Damager") && (otherPlayerChoice == ActionChoice.Spell))
                {
                    otherPlayer["HP"] = (int)otherPlayer["HP"] - ((int)actionPlayer["Force"]);
                    actionPlayer["HP"] = (int)actionPlayer["HP"] - ((int)actionPlayer["Force"]);

                }
                else if (otherPlayerChoice == ActionChoice.Defend) //Cas où l'autre défend
                {
                    return;
                }
                else //le reste (attaque, heal, powerfull attack etc...)
                {
                    otherPlayer["HP"] = (int)otherPlayer["HP"] - ((int)actionPlayer["Force"]);
                }
            }
        }


        //Choix action joueur
        static void PlayerChooseAction(Dictionary<string, object> player, TextBox tBox, Button button)
        {
            int action_player_choice = 0;

            tBox.Text += ("\r\nChoisissez une action:\r\n1 - Attack\r\n2 - Defend\r\n3 - Spell");

            action_player_choice = int.Parse(button.Tag.ToString());

            Debug.WriteLine($"Clicked button Tag: {button.Tag}");
            Debug.WriteLine(action_player_choice);

            player["Action"] = (ActionChoice)action_player_choice;
        }

        //Choix d'action IA
        static void AIChooseAction(Dictionary<string, object> ai)
        {
            Random rand = new Random();
            int choiceNb = Enum.GetValues(typeof(ActionChoice)).Length;

            ai["Action"] = (ActionChoice)rand.Next(1, choiceNb + 1);
        }

        public string PlayerChooseCharacter(TextBox tBox, Button pChoiceButton)
        {
            List<string> classList = new List<string>() { "Damager", "Healer", "Tank", "Assassin" };
            int character_player_choice = 0;
            while (character_player_choice < 1 || character_player_choice > classList.Count)
            {
                //tBox.Text += ("Choisissez un personnage:\r\n1 - Damager\r\n2 - Healer\r\n3 - Tank\r\n4 - Assassin\r\n");

                if (!choseCharacter)
                {
                    character_player_choice = int.Parse(pChoiceButton.Tag.ToString());
                    choseCharacter = true;

                    this.Controls.Remove(DamagerButton);
                    this.Controls.Remove(HealerButton);
                    this.Controls.Remove(TankButton);
                    this.Controls.Remove(AssasinButton);
                }
            }

            return classList[character_player_choice - 1];
        }

        //Choix d'action IA
        static string AIChooseCharacter()
        {
            List<string> classList = new List<string>() { "Damager", "Healer", "Tank", "Assassin" };
            Random rand = new Random();
            int rand_index = rand.Next(0, classList.Count);
            return classList[rand_index];
        }


        //Détecte fin de jeu
        static bool isEndGame(Dictionary<string, object> playerCharacter, Dictionary<string, object> aiCharacter, TextBox tBox)
        {
            //Conditions de fin
            bool playerIsDead = (int)playerCharacter["HP"] <= 0;
            bool AIisDead = (int)aiCharacter["HP"] <= 0;

            if (playerIsDead && AIisDead)
            {
                tBox.Text += ("\r\nEgalité !");
                return true;
            }
            else if (AIisDead)
            {
                tBox.Text += ("\r\nLe joueur a gagné !");
                return true;
            }
            else if (playerIsDead)
            {
                tBox.Text += ("\r\nl'AI a gagné !");
                return true;
            }
            else return false;
        }

        //----- Fonction spell
        static void Heal(Dictionary<string, object> charact, TextBox tBox)
        {
            int _health = (int)charact["HP"] + 2;
            //Vérifie qu'on ne dépasse pas la santé max
            charact["HP"] = Math.Min(_health, (int)character[(string)charact["Name"]]["HP"]);
        }

        //---- Fonction affichage
        static void ShowPlayerAction(ActionChoice action, TextBox tBox)
        {
            tBox.Text += ($"\r\nPlayer choice : {action.ToString()}");
        }

        static void ShowAIAction(ActionChoice action, TextBox tBox)
        {
            tBox.Text += ($"\r\nAI choice : {action.ToString()}");
        }

        static void DisplayHealth(Dictionary<string, object> player, Dictionary<string, object> ai, TextBox tBox)
        {
            tBox.Text += $"\r\nHP joueur : {player["HP"]}/{character[(string)player["Name"]]["HP"]}";
            tBox.Text += $"\r\nHP IA : {ai["HP"]}/{character[(string)ai["Name"]]["HP"]}";
        }

        static void TakeDamage(Dictionary<string, object> character, int damage)
        {
            //Retrait HP
            character["HP"] = (int)character["HP"] - 1;
        }

        static void Poisoned(Dictionary<string, object> character, bool b)
        {
            character["Poisoned"] = b;
        }

        static bool isPoisoned(Dictionary<string, object> character)
        {
            return (bool)character["Poisoned"];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
    }
}
