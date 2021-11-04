using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FootballManager2021
{
    public class CreatClubs
    {
        //Wenn neues Spiel geklickt wird sollen die Teams einmal erstellt werden und dann gespeichert werden,
        //bei jedem neuen spiel wird die vorhandene datei überschrieben oder in eine neue datei gelegt
        //England
      
        Player player;
        Random rndForeNames;
        Random rndSureNames;
        Random rndFoot;
        Random random = new Random();
        List<Player> manU, lndonClocks;
        List<Club> league;
        CreatClubs creat;
        Club club;
        public CreatClubs()
        {
            manU = new List<Player>();
            lndonClocks = new List<Player>();
            rndSureNames = new Random();
            rndForeNames = new Random();
            rndFoot = new Random();
            league = new List<Club>();
            club = new Club();
        }
        private string SetFoot()
        {
            string foot = string.Empty;
            string[] leftRigthBoth = { "Rechts", "Links", "Beide" };
            foot = leftRigthBoth[rndFoot.Next(0, leftRigthBoth.Length)];
            return foot;
        }
        private string GetAvatar()
        {
            string avatar = string.Empty;
            string[] avatarArray = { "pics/avataaars.png", "pics/BlackRed.png", "pics/BlondRed.png", "pics/WhiteRed.png","pics/GoldRed.png", "pics/RedRed.png", "pics/GrausRed.png", "pics/BlackKurzRed.png"};
            avatar = avatarArray[random.Next(0, avatarArray.Length)];
            return avatar;
        }
        private string GetEnglishForeName()
        {
           
            string name = string.Empty;
            string[] forenames = {"Oliver", "George", "Noah", "Arthur", "Harry", "Leo", "Muhammad", "Jack", "Charlie", "Oscar", "Jacob", "Henry", "Thomas", "Freddie", "Alfie", "Theo", "William",
                                  "Theodore", "Archie", "Joshua", "Alexander", "James", "Isaac", "Edward", "Lucas", "Tommy", "Finley", "Max", "Logan", "Ethan", "Mohammed", "Teddy", "Benjamin",
                                  "Arlo", "Joseph", "Sebastian", "Harrison", "Elijah", "Adam", "Daniel", "Samuel", "Louie", "Mason", "Reuben", "Albie", "Rory", "Jaxon", "Hugo", "Luca",
                                  "Dylan", "Albert", "David", "Jude", "Frankie", "Roman", "Ezra", "Toby", "Riley", "Carter", "Ronnie", "Frederick", "Gabriel", "Stanley", "Bobby", "Jesse",
                                  "Michael", "Elliot", "Grayson", "Mohammad", "Liam", "Jenson", "Ellis", "Harley", "Harvey", "Jayden", "Jake", "Ralph", "Rowan", "Jasper", "Ollie", "Charles",
                                  "Finn", "Felix", "Caleb", "Chester", "Jackson", "Hudson", "Leon", "Ibrahim", "Ryan", "Blake", "Alfred", "Oakley", "Matthew", "Luke", "Abdoulaye", "Adama", "Cheikhou",
                                  "Diafra", "Idrissa", "Kalidou", "Keita", "Mame", "M´Baye", "Moussa", "Salif", "Youssouf", "Alejandro", "Pablo", "Marcos", "Thiago", "Javier", "Antonio", "Jose"};
            name = forenames[rndForeNames.Next(0, forenames.Length)];
            return name;
        }
        private string GetEnglishSureName()
        {
            
            string name = string.Empty;
            string[] surenames = {"Smith", "Jones", "Taylor", "Williams", "Brown", "Davies", "Evans", "Wilson", "Thomas", "Roberts", "Johnson", "Lewis", "Walker", "Robinson", "Wood", "Thompson",
                                  "White", "Watson", "Jackson", "Wright", "Green", "Harris", "Cooper", "King", "Lee", "Martin", "Clarke", "James", "Morgan", "Hughes", "Edwards", "Hill", "Moore",
                                  "Clark", "Harrison", "Scott", "Young", "Morris", "Hall", "Ward", "Turner", "Carter", "Phillips", "Mitchell", "Patel", "Adams", "Campell", "Anderson", "Allen", "Cook",
                                  "Boubacar", "Camara", "Ceesay", "Coulibaly", "Demba", "Diakhate", "Diarra", "Diop", "Sonko", "Fernandez", "Herrera", "Louis", "Juarez", "Suarez", "Juan"};
            name = surenames[rndSureNames.Next(0, surenames.Length)];
            return name;
        }
        
        public void CreatNewFileEngland(string filename)
        {

            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.ASCII))
            {
                creat = new CreatClubs();
                manU = creat.CreateManU();
                lndonClocks = creat.CreateLondon();


                foreach (var player in manU)
                {
                     sw.WriteLine(player.ActualClub + " " + player.Age + " " + player.Position + " " + player.GoalKeeping + " " + player.Attack + " " + player.Defense + " " + player.Midfield + " " +
                             player.Forename + " " + player.Surname + " " + player.Form + " " + player.Size + " " + player.Weigth + " " + player.Talent + " " + player.Moral + " " +
                             player.BodyStrength + " " + player.Fitness + " " + player.Flanks + " " + player.Header + " " + player.Passing + " " + player.Speed + " " + player.Tactical + " " +
                             player.Shooting + " " + player.TechnicSkill + " " + player.Foot + " " + player.Strength + " " + player.Avatar);
                }
                foreach (var player in lndonClocks)
                {

                    sw.WriteLine(player.ActualClub + " " + player.Age + " " + player.Position + " " + player.GoalKeeping + " " + player.Attack + " " + player.Defense + " " + player.Midfield + " " +
                             player.Forename + " " + player.Surname + " " + player.Form + " " + player.Size + " " + player.Weigth + " " + player.Talent + " " + player.Moral + " " +
                             player.BodyStrength + " " + player.Fitness + " " + player.Flanks + " " + player.Header + " " + player.Passing + " " + player.Speed + " " + player.Tactical + " " +
                             player.Shooting + " " + player.TechnicSkill + " " + player.Foot + " " + player.Strength + " " + player.Avatar);
                }

            }



        }
        
        public List<Club> LoadFileEngland(string filename)
        {
            manU.Clear();
            lndonClocks.Clear();

            using (StreamReader sr = new StreamReader(filename))
            {
                Player player = new Player();

                string newplayer;
               
                while (!sr.EndOfStream)
                {

                    newplayer = sr.ReadLine();
                    string[] sv = newplayer.Split(' ');
                    player = new Player { ActualClub = sv[0] + " " + sv[1], Age = Convert.ToInt32(sv[2]), Position = sv[3], GoalKeeping = Convert.ToInt32(sv[4]), Attack = Convert.ToInt32(sv[5]),
                                          Defense = Convert.ToInt32(sv[6]), Midfield = Convert.ToInt32(sv[7]), Forename = sv[8], Surname = sv[9], Form = Convert.ToInt32(sv[10]), Size = Convert.ToDouble(sv[11]),
                                          Weigth = Convert.ToInt32(sv[12]), Talent = Convert.ToInt32(sv[13]), Moral = Convert.ToInt32(sv[14]), BodyStrength = Convert.ToInt32(sv[15]), Fitness = Convert.ToInt32(sv[16]),
                                          Flanks = Convert.ToInt32(sv[17]), Header = Convert.ToInt32(sv[18]), Passing = Convert.ToInt32(sv[19]), Speed = Convert.ToInt32(sv[20]), Tactical = Convert.ToInt32(sv[21]), 
                                          Shooting = Convert.ToInt32(sv[22]), TechnicSkill = Convert.ToInt32(sv[23]), Foot = sv[24], Strength = Convert.ToInt32(sv[25]), Avatar = sv[26] };
                    if (player.ActualClub == "Manchester Devils")
                        manU.Add(player);
                    if (player.ActualClub == "London Clocks")
                        lndonClocks.Add(player);
                }
            }
            //die Englische Liga erzeugen, mit allen teams, daten und Spielern
            //um die Teams aufzurufen und änderungen daran durchzuführen muss das über die league Liste erfolgen
            club = new Club { TeamPlayer = manU, ClubName = "Manchester Devils", ClubLeague = "England", ClubStrength = club.GetClubStrength(manU), FansCount = 50000, FansLoyality = 3, ClubColorMain = Brushes.Red, ClubColorSec = Brushes.Black, ClubColorThird = Brushes.Blue };
            league.Add(club);
            club = new Club { TeamPlayer = lndonClocks, ClubName = "London Clocks", ClubLeague = "England", ClubStrength = club.GetClubStrength(lndonClocks), FansCount = 40000, FansLoyality = 3, ClubColorMain = Brushes.Red, ClubColorSec = Brushes.White, ClubColorThird = Brushes.Gold };
            league.Add(club);
            return league;
        }
        public List<Player> CreateManU()
        {
           


            for (int i = 0; i < 23; i++)
            {
                string forename = string.Empty;
                string surename = string.Empty;
                string position = string.Empty;
                int defense = random.Next(30, 50);
                int midfield = random.Next(30, 50);
                int attack = random.Next(30, 50);
                int goalkeeping = random.Next(15, 50);
                int bodystrength = random.Next(50, 90);
                int tactical = random.Next(60, 99);
                int technicskills = random.Next(50, 70);
                int header = random.Next(40, 70);
                int shooting = random.Next(30, 50);
                int flanks = random.Next(30, 50);
                int passing = random.Next(50, 99);
                int speed = random.Next(50, 99);
                int moral = random.Next(50, 99);
                int talent = random.Next(5, 10);
                int fitness = random.Next(50, 99);
                int form = random.Next(60, 99);
                double size = random.NextDouble() * (2.00 - 1.65) + 1.65;
                size = Math.Round(size, 2);
                int weigth = random.Next(65, 85);
                int age = random.Next(16, 35);
                string foot = SetFoot();
                string avatar = GetAvatar();
                if (i >= 0 && i <= 3)
                {
                    position = "TW";
                    goalkeeping = random.Next(70, 99);
                    tactical = random.Next(70, 99);
                }

                if (i > 3 && i <= 11)
                {
                    position = "V";
                    header = random.Next(70, 90);
                    defense = random.Next(70, 99);
                    tactical = random.Next(70, 99);
                    bodystrength = random.Next(70, 99);
                }


                if (i > 11 && i <= 17)
                {
                    position = "MF";
                    midfield = random.Next(70, 99);
                    tactical = random.Next(70, 99);
                    technicskills = random.Next(70, 99);
                    passing = random.Next(70, 99);
                    shooting = random.Next(70, 90);
                    speed = random.Next(70, 99);
                    flanks = random.Next(70, 99);
                }
                if (i > 17 && i <= 22)
                {
                    position = "ST";
                    attack = random.Next(70, 99);
                    tactical = random.Next(70, 99);
                    shooting = random.Next(75, 99);
                    header = random.Next(70, 99);
                    speed = random.Next(70, 99);
                    passing = random.Next(60, 90);
                }
                forename = GetEnglishForeName();
                surename = GetEnglishSureName();
                if (forename == "Boubacar" || forename == "Camara" || forename == "Ceesay" || forename == "Coulibaly" || forename == "Demba" || forename == "Diakhate" || forename == "Diarra"
                    || forename == "Diop" || forename == "Sonko")
                {
                    avatar = "pics/BlackRed.png";
                }
                player = new Player { ActualClub = "Manchester Devils", Age = age, Position = position, GoalKeeping = goalkeeping, Attack = attack, Defense = defense, Midfield = midfield, Forename = forename, Surname = surename, Form = form, Size = size, Weigth = weigth, Talent = talent, Moral = moral, BodyStrength = bodystrength, Fitness = fitness, Flanks = flanks, Header = header, Passing = passing, Speed = speed, Tactical = tactical, Shooting = shooting, TechnicSkill = technicskills, Foot = foot, Avatar = avatar};
                player.Strength = player.OverallStrength();
                manU.Add(player);
            }
            return manU;
        }
        
        public List<Player> CreateLondon()
        {
          


            for (int i = 0; i < 23; i++)
            {
                string forename = string.Empty;
                string surename = string.Empty;
                string position = string.Empty;
                int defense = random.Next(30, 50);
                int midfield = random.Next(30, 50);
                int attack = random.Next(30, 50);
                int goalkeeping = random.Next(15, 50);
                int bodystrength = random.Next(50, 90);
                int tactical = random.Next(60, 99);
                int technicskills = random.Next(50, 70);
                int header = random.Next(40, 70);
                int shooting = random.Next(30, 50);
                int flanks = random.Next(30, 50);
                int passing = random.Next(50, 99);
                int speed = random.Next(50, 99);
                int moral = random.Next(50, 99);
                int talent = random.Next(5, 10);
                int fitness = random.Next(50, 99);
                int form = random.Next(60, 99);
                double size = random.NextDouble() * (2.00 - 1.65) + 1.65;
                size = Math.Round(size, 2);
                int weigth = random.Next(65, 85);
                int age = random.Next(16, 35);
                string foot = SetFoot();
                string avatar = GetAvatar();
                if (i >= 0 && i <= 3)
                {
                    position = "TW";
                    goalkeeping = random.Next(70, 99);
                    tactical = random.Next(70, 99);
                }

                if (i > 3 && i <= 11)
                {
                    position = "V";
                    header = random.Next(70, 90);
                    defense = random.Next(70, 99);
                    tactical = random.Next(70, 99);
                    bodystrength = random.Next(70, 99);
                }


                if (i > 11 && i <= 17)
                {
                    position = "MF";
                    midfield = random.Next(70, 99);
                    tactical = random.Next(70, 99);
                    technicskills = random.Next(70, 99);
                    passing = random.Next(70, 99);
                    shooting = random.Next(70, 90);
                    speed = random.Next(70, 99);
                }
                if (i > 17 && i <= 22)
                {
                    position = "ST";
                    attack = random.Next(70, 99);
                    tactical = random.Next(70, 99);
                    shooting = random.Next(75, 99);
                    header = random.Next(70, 99);
                    speed = random.Next(70, 99);
                    passing = random.Next(60, 90);
                }
                forename = GetEnglishForeName();
                surename = GetEnglishSureName();
                if (forename == "Boubacar" || forename == "Camara" || forename == "Ceesay" || forename == "Coulibaly" || forename == "Demba" || forename == "Diakhate" || forename == "Diarra"
                   || forename == "Diop" || forename == "Sonko")
                {
                    avatar = "pics/BlackRed.png";
                }
                player = new Player { ActualClub = "London Clocks", Age = age, Position = position, GoalKeeping = goalkeeping, Attack = attack, Defense = defense, Midfield = midfield, Forename = forename, Surname = surename, Form = form, Size = size, Weigth = weigth, Talent = talent, Moral = moral, BodyStrength = bodystrength, Fitness = fitness, Flanks = flanks, Header = header, Passing = passing, Speed = speed, Tactical = tactical, Shooting = shooting, TechnicSkill = technicskills, Foot = foot, Avatar = avatar };
                player.Strength = player.OverallStrength();
                lndonClocks.Add(player);
            }

            return lndonClocks;
        }
    }
}
